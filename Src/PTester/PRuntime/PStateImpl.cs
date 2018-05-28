using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace P.Runtime
{

    public abstract class StateImpl : ICloneable
    {

#region Constructors
        /// <summary>
        /// This function is called when the stateimp is loaded first time.
        /// </summary>
        protected StateImpl()
        {
            implMachines = new List<PrtImplMachine>();
            specMachinesMap = new Dictionary<string, PrtSpecMachine>();
            exception = null;
            currentVisibleTrace = new VisibleTrace();
            errorTrace = new StringBuilder();
        }
#endregion

#region Fields

        /// <summary>
        /// Map from the statemachine id to the instance of the statemachine.
        /// </summary>
        private List<PrtImplMachine> implMachines;

        public List<PrtImplMachine> ImplMachines
        {
            get
            {
                return implMachines;
            }
        }

        public List<PrtImplMachine> EnabledMachines
        {
            get
            {
                return implMachines.Where(m => m.currentStatus == PrtMachineStatus.Enabled).ToList();
            }
        }
        /// <summary>
        /// List of spec machines
        /// </summary>
        private Dictionary<string, PrtSpecMachine> specMachinesMap;

        public void DbgCompare(StateImpl state)
        {
            Debug.Assert(implMachines.Count == state.implMachines.Count);
            for (int i = 0; i < implMachines.Count; i++)
            {
                implMachines[i].DbgCompare(state.implMachines[i]);
            }

            Debug.Assert(specMachinesMap.Count == state.specMachinesMap.Count);
            foreach (var tup in specMachinesMap)
            {
                Debug.Assert(state.specMachinesMap.ContainsKey(tup.Key));
                tup.Value.DbgCompare(state.specMachinesMap[tup.Key]);
            }

            Debug.Assert(GetHashCode() == state.GetHashCode());
        }

        /// <summary>
        /// Stores the exception encountered during exploration.
        /// </summary>
        private Exception exception;

        public static bool invariants = false;

        public static int succHash = 0; // we assume 0 is not a valid state hash (:-(
        public static int predHash = 0;

        public static bool FileDump = false;

        public VisibleTrace currentVisibleTrace;
        public StringBuilder errorTrace;
        public static List<string> visibleEvents = new List<string>();
        public static List<string> visibleInterfaces = new List<string>();
        public delegate PrtImplMachine CreateMachineDelegate(StateImpl application, PrtValue payload);
        public delegate PrtSpecMachine CreateSpecDelegate(StateImpl application);
        public static Dictionary<string, Dictionary<string, string>> linkMap = new Dictionary<string, Dictionary<string, string>>();
        public static Dictionary<string, string> machineDefMap = new Dictionary<string, string>();
        public static Dictionary<string, bool> isSafeMap = new Dictionary<string, bool>();
        public static Dictionary<string, List<string>> specMachineMap = new Dictionary<string, List<string>>();
        public static Dictionary<string, CreateMachineDelegate> createMachineMap = new Dictionary<string, CreateMachineDelegate>();
        public static Dictionary<string, CreateSpecDelegate> createSpecMap = new Dictionary<string, CreateSpecDelegate>();
        public static Dictionary<string, List<PrtEventValue>> interfaceMap = new Dictionary<string, List<PrtEventValue>>();

        public delegate bool GetBooleanChoiceDelegate();
        public GetBooleanChoiceDelegate UserBooleanChoice = null;

        public delegate void CreateMachineCallbackDelegate(PrtImplMachine machine);
        public CreateMachineCallbackDelegate CreateMachineCallback = null;

        public delegate void DequeueCallbackDelegate(PrtImplMachine machine, string evName, string senderMachineName, string senderMachineStateName);
        public DequeueCallbackDelegate DequeueCallback = null;

        public delegate void StateTransitionCallbackDelegate(PrtImplMachine machine, PrtState from, PrtState to, string reason);
        public StateTransitionCallbackDelegate StateTransitionCallback = null;

#endregion

#region Getters and Setters
        public bool Deadlock
        {
            get
            {
                bool enabled = false;
                foreach (var x in implMachines)
                {
                    if (enabled) break;
                    enabled = enabled || (x.currentStatus == PrtMachineStatus.Enabled);
                }
                bool hot = false;
                foreach (var x in specMachinesMap.Values)
                {
                    if (hot) break;
                    hot = hot || x.currentTemperature == StateTemperature.Hot;
                }
                return (!enabled && hot);
            }
        }

        public Exception Exception
        {
            get { return exception; }
            set { exception = value; }
        }


#endregion

#region Clone Function
        public abstract StateImpl MakeSkeleton();

        public object Clone()
        {
            var clonedState = MakeSkeleton();
            //clone all the fields
            clonedState.implMachines = new List<PrtImplMachine>();
            foreach (var machine in implMachines)
            {
                clonedState.implMachines.Add(machine.Clone(clonedState));
            }

            clonedState.specMachinesMap = new Dictionary<string, PrtSpecMachine>();
            foreach (var specMachine in specMachinesMap)
            {
                clonedState.specMachinesMap.Add(specMachine.Key, (specMachine.Value).Clone(clonedState));
            }

            clonedState.exception = this.exception;

            clonedState.currentVisibleTrace = new VisibleTrace();
            foreach (var item in currentVisibleTrace.Trace)
            {
                clonedState.currentVisibleTrace.Trace.Add(item);
            }

            clonedState.errorTrace = new StringBuilder(errorTrace.ToString());

            clonedState.Resolve();

            return clonedState;

        }

        public void Resolve()
        {
            foreach (var m in implMachines)
            {
                m.Resolve(this);
            }

            foreach (var m in specMachinesMap.Values)
            {
                m.Resolve(this);
            }
        }
#endregion

        public void abstract_me()
        {
            foreach (var m in ImplMachines)
                m.abstract_me();
        }

        public void collect_abstract_successors(HashSet<int> abstract_succs, StreamWriter abstract_succs_SW)
        {
            for (int currIndex = 0; currIndex < ImplMachines.Count; ++currIndex)
            {
                PrtImplMachine m = ImplMachines[currIndex];
                List<PrtEventNode> m_q = m.eventQueue.events;

                // reject disabled machines
                if (!(m.currentStatus == PrtMachineStatus.Enabled))
                    continue;

                // reject machines not dequeing or receiving. I assume these are the only two that can lead to a call to PrtDequeueEvent
                if (!(m.nextSMOperation == PrtNextStatemachineOperation.DequeueOperation ||
                      m.nextSMOperation == PrtNextStatemachineOperation.ReceiveOperation))
                    continue;

                if (m.eventQueue.Empty()) // apparently enabled machines whose next SM op is dequeue or receive may have still an empty queue
                    continue;

                if (PrtEventBuffer.qt == PrtEventBuffer.Queue_Type.list)
                    collect_abstract_successors_from_list(currIndex, abstract_succs, abstract_succs_SW);
                else
                    collect_abstract_successors_from_set (currIndex, abstract_succs, abstract_succs_SW);
            }
        }

        // for queue-list abstraction:
        void collect_abstract_successors_from_list(int currIndex, HashSet<int> abstract_succs, StreamWriter abstract_succs_SW)
        {
            PrtImplMachine m = ImplMachines[currIndex];
            List<PrtEventNode> m_q = m.eventQueue.events;

            var ChoiceVector = new List<bool>();
            bool more;
            do
            {
                StateImpl          succ     = (StateImpl)Clone();
                PrtImplMachine     succ_m   = succ.ImplMachines[currIndex];
                List<PrtEventNode> succ_m_q = succ_m.eventQueue.events;
                more = succ_m.PrtRunStateMachine_next_choice(ChoiceVector);
                if (succ_m_q.Count == m_q.Count || succ.CheckFailure(0)) // if dequeing was unsuccessful, i.e. no event was dequeued at all
                    return;                                              // then there is nothing left to do. No more nondet choices to try
                Debug.Assert(succ_m_q.Count == m_q.Count - 1); // we have dequeued exactly one event
                Debug.Assert(PrtEventBuffer.last_ev_dequeued <= succ_m_q.Count);
                if (PrtEventBuffer.last_ev_dequeued < PrtEventBuffer.p) // if a prefix element was dequeued
                {
                    if (m_q.Count <= PrtEventBuffer.p) // if there was no suffix to begin with
                    {
                        succ.add_to_succs_if_inv(currIndex, this, abstract_succs, abstract_succs_SW);
                        continue;
                    }
                    // the new prefix is already correct: the first suffix element transited to the end of the prefix. But we don't know the multiplicity of it in the suffix
                    PrtEventBuffer.last_ev_dequeued = PrtEventBuffer.p; // we abuse the PrtEventBuffer.last_ev_dequeued variable to point to the index of the element we may need to re-insert in the suffix
                }
                // (else) if a suffix element was deqeued, then PrtEventBuffer.last_ev_dequeued already points to the right index, namely that one
                PrtEventNode moved_from_suff = m_q[PrtEventBuffer.last_ev_dequeued];
                Debug.Assert(succ_m_q.FindLastIndex(ev => ev.Equals(moved_from_suff)) < PrtEventBuffer.p); // we just removed it from the suffix, and the suffix contains no duplicates

                // choice 1: moved_from_suff existed exactly once in the concrete suffix. Then it is gone after the dequeue, in both abstract and concrete. The new state abstract is valid.
                succ.add_to_succs_if_inv(currIndex, this, abstract_succs, abstract_succs_SW);

                // choice 2: removed_from_suff existed >= twice in concrete suffix. We need to find the positions where to re-introduce it in the abstract, and try them all non-deterministically
                for (int j = PrtEventBuffer.last_ev_dequeued; j < succ_m_q.Count; ++j)
                {
                    // insert removed_from_suff at position j (push the rest to the right)
                    succ_m_q.Insert(j, moved_from_suff);
                    succ.add_to_succs_if_inv(currIndex, this, abstract_succs, abstract_succs_SW);
                    succ_m_q.RemoveAt(j); // restore previous state
                }
                succ_m_q.Add(moved_from_suff); // finally, insert removed_from_suff at end
                succ.add_to_succs_if_inv(currIndex, this, abstract_succs, abstract_succs_SW);
            } while (more);
        }

        // for queue-set abstraction:
        void collect_abstract_successors_from_set(int currIndex, HashSet<int> abstract_succs, StreamWriter abstract_succs_SW)
        {
            // the collection function is too complicated for the set abstraction with the current data structures.
            // For set abstraction, we need to split the queue into a list for the unabstracted prefix, and a proper (Hash)set for the suffix.
            // The current implementation works only for p=0 (all of the queue is abstracted into a set)
            if (PrtEventBuffer.p > 0)
                throw new NotImplementedException("StateImpl.collect_abstract_successors_from_set: the method is implemented only for queue-prefix == 0 at the moment");

            PrtImplMachine m = ImplMachines[currIndex];
            List<PrtEventNode> m_q = m.eventQueue.events;

            StateImpl empty = (StateImpl)Clone();
            empty.ImplMachines[currIndex].eventQueue.events.Clear();

            foreach (PrtEventNode ev in m_q)
            {
                StateImpl single = (StateImpl)empty.Clone();
                single.ImplMachines[currIndex].eventQueue.events.Add(ev.Clone_Resolve(single));
                var ChoiceVector = new List<bool>();
                bool more;
                do
                {
                    StateImpl          succ     = (StateImpl)single.Clone();
                    PrtImplMachine     succ_m   = succ.ImplMachines[currIndex];
                    List<PrtEventNode> succ_m_q = succ_m.eventQueue.events;
                    more = succ_m.PrtRunStateMachine_next_choice(ChoiceVector);
                    if (!succ_m.eventQueue.Empty() || succ.CheckFailure(0)) // if dequeing was unsuccessful
                        goto Next_Event;
                    succ_m.eventQueue = m.eventQueue.Clone_Resolve(succ); // restore whole event queue (as a set)
                    // choice 1: ev existed >= twice in concrete m_q. No change in queue set abstraction
                    succ.add_to_succs_if_inv(currIndex, this, abstract_succs, abstract_succs_SW);
                    // choice 2: ev existed once in m_q, so after the dequeue it is gone
                    succ_m_q.Remove(ev);
                    succ.add_to_succs_if_inv(currIndex, this, abstract_succs, abstract_succs_SW);
                } while (more);
            Next_Event:
                ;
            }
        }

        public class SuccessorFound : System.Exception {
            public SuccessorFound() {}
            public SuccessorFound(StateImpl a, StateImpl ap)
            {
                Console.WriteLine("Found abstract pair (a,a') such that a' is the abstract successor state of a identified in previous run.");
                string  a_f =  "a.txt";
                string ap_f = "ap.txt";
                StreamWriter  a_SW = new StreamWriter( a_f);  a_SW.WriteLine(a .ToPrettyString());  a_SW.Close();
                StreamWriter ap_SW = new StreamWriter(ap_f); ap_SW.WriteLine(ap.ToPrettyString()); ap_SW.Close();
                throw new SuccessorFound();
            }
        };

        void add_to_succs_if_inv(int currIndex, StateImpl pred, HashSet<int> abstract_succs, StreamWriter abstract_succs_SW)
        {
            int phash = pred.GetHashCode(); if (phash == 0) throw new NotImplementedException("Need to redesign this if state hashes can be 0");
            int hash  =      GetHashCode(); if ( hash == 0) throw new NotImplementedException("Need to redesign this if state hashes can be 0");

            if (succHash != 0) // if we are in successor finding mode
                if (succHash == hash)
                {
                    predHash = phash;
                    throw new SuccessorFound(pred, this);
                }

            if ( invariants ? Check_state_invariant(currIndex) && Check_trans_invariant(currIndex, pred) : true )
            {
                if (abstract_succs.Add(hash))
                    if (FileDump)
                    {
                        abstract_succs_SW.Write(ToPrettyString());
                        abstract_succs_SW.WriteLine("==================================================");
                    }
            } 
        }

        public bool CheckFailure(int depth)
        {
            //if (UseDepthBounding && depth > DepthBound)    // ignore this for now. These parameters are part of class DfsExploration, so can't use here
            //{
            //    return true;
            //}

            if (Exception == null)
            {
                return false;
            }


            if (Exception is PrtAssumeFailureException)
            {
                return true;
            }
            else if (Exception is PrtException)
            {
                Console.WriteLine(errorTrace.ToString());
                Console.WriteLine("ERROR: {0}", Exception.Message);
                Environment.Exit(-1);
            }
            else
            {
                Console.WriteLine(errorTrace.ToString());
                Console.WriteLine("[Internal Exception]: Please report to the P Team");
                Console.WriteLine(Exception.ToString());
                Environment.Exit(-1);
            }
            return false;
        }

        // this is like a typedef and must, unfortunately, pollute the global scope. Should be inside below function def.
        delegate bool Event_is_and_queue_contains(PrtImplMachine m, string s);

        // STATE AND TRANSITION INVARIANTS.

        // This is application dependent, so eventually this needs to be done differently.

        // 1. STATE INVARIANTS

        // Abstract states obtained by abstraction from a reachable concrete state satisfy all invariants by construction.
        // But abstract states are also obtained via the succesor function from another abstract state. This function must overapproximate and may therefore violate some invariant.
        public bool Check_state_invariant(int currIndex)  // currIndex = index of the ImplMachine that has just been run (other machines have not changed, so their invariants need not be checked)
        {
#if true
            PrtImplMachine  Main  = implMachines[0]; Debug.Assert( Main .eventQueue.is_abstract());
            PrtImplMachine Client = implMachines[1]; Debug.Assert(Client.eventQueue.is_abstract());
            List<PrtEventNode> Client_q = Client.eventQueue.events;

            // this one we need for both list and set abstraction: can't have just dequeued DONE and then there are still DONE's in the queue
            if (Client.get_eventValue().ToString() == "DONE" && Client_q.Find(ev => ev.ev.ToString() == "DONE") != null)
                return false;

            if (PrtEventBuffer.qt == PrtEventBuffer.Queue_Type.list)
            {
                for (int i = 0; i < Client_q.Count - 1; ++i)
                {
                    string curr = Client_q[  i  ].ev.ToString();
                    string next = Client_q[i + 1].ev.ToString();
                    // PING cannot be followed by WAIT
                    if (curr == "PING" && next == "WAIT")
                        return false;
                }
            }
            else
            {
                // can't have just dequeued PING and then there are still WAIT's in the queue
                if (Client.get_eventValue().ToString() == "PING" && Client_q.Find(ev => ev.ev.ToString() == "WAIT") != null)
                    return false;
            }
#endif

#if false
            PrtImplMachine  Main  = implMachines[0]; Debug.Assert( Main .eventQueue.is_abstract()); List<PrtEventNode>  Main_q  =  Main .eventQueue.events;
            PrtImplMachine Client = implMachines[1]; Debug.Assert(Client.eventQueue.is_abstract()); List<PrtEventNode> Client_q = Client.eventQueue.events;

            Event_is_and_queue_contains event_is_and_queue_contains = delegate(PrtImplMachine m, string s)
            {
                List<PrtEventNode> q = m.eventQueue.events;
                return m.get_eventValue().ToString() == s && q.Find(ev => ev.ev.ToString() == s) != null;
            };

            // these lemmas state that none of the events in question occur more than once in the queue
            if (event_is_and_queue_contains(Main,   "req_share")      ||
                event_is_and_queue_contains(Main,   "req_excl")       ||
                event_is_and_queue_contains(Main,   "invalidate_ack") ||

                event_is_and_queue_contains(Client, "grant_share")    ||
                event_is_and_queue_contains(Client, "grant_excl")     ||
                event_is_and_queue_contains(Client, "ask_share")      ||
                event_is_and_queue_contains(Client, "ask_excl")       ||
                event_is_and_queue_contains(Client, "invalidate"))
                return false;
#endif
            return true;
        }

        public bool Check_trans_invariant(int currIndex, StateImpl pred)
        {
            return true;
        }

        // Implementation note: there are currently three distinct methods that crawl over the hierarchy of a StateImpl and collect various kinds of information:
        // - GetHashCode computes the combined hash value of the state
        // -   ToString  computes a combined string representation of the state
        // -    Clone    computes a copy of the state, in fresh memory
        // The descent into the StateImpl hierarchy is at least very similar, if not identical. Sometimes we RELY on it being identical, e.g. the hash and the string
        // (both are used to store a state, in different contexts). This code redundancy is unreliable and error prone.
        public override int GetHashCode()
        {
            var hash1 = implMachines.Select(impl => impl.GetHashCode()).Hash();
            var hash2 = specMachinesMap.Select(pair => pair.Value.GetHashCode()).Hash();
            return Hashing.Hash(hash1, hash2);
        }

        // A good convention for converting a state into a compressed string might be to define a separator char (like '|')
        // that is used twice, thrice, etc. depending on how deep in the state hierarchy you are. This way you need to reserve only 1 char
        public override string ToString()
        {
            // the debugger seems to use the following code to print
#if !DEBUG
            Console.WriteLine("StateImpl.ToString: error: should not reach this function");
            throw new NotImplementedException();
#endif
            string result = "";

            // dump each ImplMachine to a string
            foreach (PrtImplMachine m in implMachines)
            {
                result += m.ToString() + "|";
            }

            result += "#";

            // dump each specMachine to a string
            foreach (KeyValuePair<string, PrtSpecMachine> pair in specMachinesMap)
            {
                result += pair.Key + "|";
            }

            return result;
        }

        public string ToPrettyString(string indent = "")
        {
            string result = "Hash: " + GetHashCode().ToString() + "\n";

            if (implMachines.Count == 0)
                result += indent + "ImplMachines: (none)\n";
            else
            {
                ushort i = 0;
                // dump each ImplMachine to a string
                foreach (PrtImplMachine m in implMachines)
                {
                    result += indent + "ImplMachine " + (i++).ToString() + ":\n";
                    result += m.ToPrettyString(indent + "  ");
                }
            }

            if (specMachineMap.Count == 0)
                result += indent + "SpecMachines: (none)\n";
            else
            {
                ushort i = 0;
                // for each specMachine, why do we print only the key?
                foreach (KeyValuePair<string, PrtSpecMachine> pair in specMachinesMap)
                {
                    result += indent + "SpecMachine " + (i++).ToString() + ": " + pair.Key + "\n";
                }
            }

            return result;
        }

        public List<PrtSpecMachine> GetAllSpecMachines()
        {
            return specMachinesMap.Values.ToList();
        }

        private List<PrtSpecMachine> GetSpecMachines(string currMachine)
        {
            var allSpecMachines = specMachineMap.Where(mon => mon.Value.Contains(currMachine))
                                        .Select(item => item.Key)
                                        .Select(monName => specMachinesMap[monName]).ToList();
            return allSpecMachines;
        }
        public PrtInterfaceValue CreateInterface(PrtMachine currMach, string interfaceOrMachineName, PrtValue payload)
        {
            //add visible action to trace
            if (visibleInterfaces.Contains(interfaceOrMachineName))
            {
                currentVisibleTrace.AddAction(interfaceOrMachineName, payload.ToString());
            }

            var renamedImpMachine = linkMap[currMach.renamedName][interfaceOrMachineName];
            var impMachineName = machineDefMap[renamedImpMachine];
            var machine = createMachineMap[impMachineName](this, payload);
            machine.isSafe = isSafeMap[renamedImpMachine];
            machine.renamedName = renamedImpMachine;
            AddImplMachineToStateImpl(machine);

            CreateMachineCallback?.Invoke(machine);

            //TraceLine("<CreateLog> Machine {0}-{1} was created by machine {2}-{3}", currMach.renamedName, currMach.instanceNumber, machine.renamedName, machine.instanceNumber);
            TraceLine("<CreateLog> Machine {0}-{1} was created by machine {2}-{3}", machine.renamedName, machine.instanceNumber, currMach.renamedName, currMach.instanceNumber);

            if (interfaceMap.ContainsKey(interfaceOrMachineName))
            {
                return new PrtInterfaceValue(machine, interfaceMap[interfaceOrMachineName]);
            }
            else
            {
                return new PrtInterfaceValue(machine, machine.self.permissions);
            }
        }

        public void CreateMainMachine(string mainInterface)
        {


            if (!machineDefMap.ContainsKey(mainInterface))
            {
                throw new PrtInternalException($"No {mainInterface} interface in the module machine definition map");
            }
            var impMachineName = machineDefMap[mainInterface];
            var machine = createMachineMap[impMachineName](this, PrtValue.@null);
            machine.isSafe = isSafeMap[mainInterface];
            machine.renamedName = mainInterface;
            AddImplMachineToStateImpl(machine);
            TraceLine("<CreateLog> Main machine {0} was created by machine Runtime", impMachineName);

        }

        public void CreateSpecMachine(string renamedSpecName)
        {
            TraceLine("<CreateLog> Spec Machine {0} was created by machine Runtime", renamedSpecName);
            var impSpecMachine = machineDefMap[renamedSpecName];
            var machine = createSpecMap[impSpecMachine](this);
            machine.isSafe = isSafeMap[renamedSpecName];
            machine.renamedName = renamedSpecName;
            AddSpecMachineToStateImpl(machine);
        }
        public int NextMachineInstanceNumber(Type machineType)
        {
            return implMachines.Where(m => m.GetType() == machineType).Count() + 1;
        }

        public void Announce(PrtEventValue ev, PrtValue payload, PrtMachine parent)
        {
            if (ev.Equals(PrtValue.@null))
            {
                throw new PrtIllegalEnqueueException("Enqueued event must not be null");
            }

            PrtType prtType = ev.evt.payloadType;
            //assertion to check if argument passed inhabits the payload type.
            if (prtType is PrtNullType)
            {
                if (!payload.Equals(PrtValue.@null))
                {
                    throw new PrtIllegalEnqueueException("Did not expect a payload value");
                }
            }
            else if (!PrtValue.PrtInhabitsType(payload, prtType))
            {
                throw new PrtInhabitsTypeException(String.Format("Payload <{0}> does not match the expected type <{1}> with event <{2}>", payload.ToString(), prtType.ToString(), ev.evt.name));
            }

            var allSpecMachines = GetSpecMachines(parent.renamedName);
            foreach (var mon in allSpecMachines)
            {
                if (mon.observes.Contains(ev))
                {
                    TraceLine("<AnnounceLog> Enqueued Event <{0}, {1}> to Spec Machine {2}", ev, payload, mon.Name);
                    mon.PrtEnqueueEvent(ev, payload, parent);
                }
            }
        }

        public void AddImplMachineToStateImpl(PrtImplMachine machine)
        {
            implMachines.Add(machine);
        }

        public void AddSpecMachineToStateImpl(PrtSpecMachine spec)
        {
            specMachinesMap.Add(spec.renamedName, spec);
        }

        public void Trace(string message, params object[] arguments)
        {
            message = message.Replace(@"\n", System.Environment.NewLine);
            errorTrace.Append(String.Format(message, arguments));
        }

        public void TraceLine(string message, params object[] arguments)
        {
            message = message.Replace(@"\n", System.Environment.NewLine);
            errorTrace.AppendLine(String.Format(message, arguments));
        }



        public void SetPendingChoicesAsBoolean(PrtImplMachine process)
        {
            //TODO: NOT IMPLEMENT YET
            //throw new NotImplementedException();
        }

        public Boolean GetSelectedChoiceValue(PrtImplMachine process)
        {
            if (UserBooleanChoice != null)
            {
                return UserBooleanChoice();
            }
            else
            {
                //throw new NotImplementedException();
                return (new Random(DateTime.Now.Millisecond)).Next(10) > 5;
            }
        }
    }

    public class StateImplComparer : IEqualityComparer<StateImpl>
    {
        public int GetHashCode(StateImpl s) { return s.GetHashCode(); }

        public bool Equals(StateImpl s1, StateImpl s2) { return s1.GetHashCode() == s2.GetHashCode(); }
    }

}
