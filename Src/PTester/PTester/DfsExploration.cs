#define __STATE_INVARIANTS__
// #define __TRANS_INVARIANTS__

using System;
using System.Collections.Generic;
using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using P.Runtime;
using System.Diagnostics;

namespace P.Tester
{
    static class DfsExploration
    {
        private static int max_queue_size;

        public static bool UseDepthBounding = false;
        public static int DepthBound = 100;

        public static bool UseStateHashing = true; // currently doesn't make sense without

        public static HashSet<int> visited = new HashSet<int>();
        public static HashSet<StateImpl> visible = new HashSet<StateImpl>(new StateImplComparer());

        public static int size_Visited_previous = 0;
        public static int size_Visible_previous = 0;
        public static int size_Visible_previous_previous = 0;

        public static void Dfs(StateImpl start, bool visible_abstraction = false)
        {
            if (!UseStateHashing) throw new NotImplementedException();

            int k = PrtEventBuffer.k; // const ref would be better
            Console.WriteLine("Using queue bound of {0}", k);

            visited.Clear();
            visible.Clear();

#if DEBUG
            max_queue_size = 0;
#endif

            var stack = new Stack<BacktrackingState>();

            StreamWriter visited_k = new StreamWriter("visited-" + (k < 10 ? "0" : "") + k.ToString() + ".txt"); // for dumping visited states as strings into a file

            StateImpl start_k = (StateImpl)start.Clone(); // we need a fresh clone in each iteration (k) of Dfs

            stack.Push(new BacktrackingState(start_k));
            int start_hash = start_k.GetHashCode();
            visited.Add(start_hash);

            visited_k.Write(start_k.ToPrettyString()); // + " = " + start_hash.ToPrettyString());
            visited_k.WriteLine("==================================================");

            if (visible_abstraction)
            {
                StateImpl vstart_k = (StateImpl)start_k.Clone(); vstart_k.abstract_me();
                visible.Add(vstart_k);
            }

            // DFS begin
            while (stack.Count != 0)
            {
                var bstate = stack.Pop();

                // PrintStackDepth(stack.Count);

                if (bstate.CurrIndex >= bstate.State.EnabledMachines.Count) // if "done" with bstate
                {
                    continue;
                }

                BacktrackingState next = Execute(bstate);    // execute the enabled machine pointed to by currIndex. Also, advance currIndex and/or choiceIndex
                stack.Push(bstate);                          // after increasing currIndex/choiceIndex, push state back on. This is like modifying bstate "on the stack"

                if (!CheckFailure(next.State, next.depth))   // check for failure before adding new state: may fail due to failed assume, in which case we don't want to add
                {
                    // update visited state hashset
                    var hash = next.State.GetHashCode();
                    if (!visited.Add(hash))
                        continue;

                    if (visible_abstraction)
                    {
                        // update visible state set
                        StateImpl next_vs = (StateImpl)next.State.Clone(); next_vs.abstract_me();
                        visible.Add(next_vs);
                    }

                    stack.Push(next);

                    visited_k.Write(next.State.ToPrettyString()); // + " = " + hash.ToPrettyString());
                    visited_k.WriteLine("==================================================");
#if DEBUG
                    // diagnostics

                    // Print number of states explored
                    if (visited.Count % 100 == 0)
                    {
                        Console.WriteLine("-------------- Number of states visited so far = {0}", visited.Count);
                    }

                    // update maximum encountered queue size
                    foreach (PrtImplMachine m in next.State.ImplMachines)
                    {
                        int m_size = m.eventQueue.Size();
                        if (m_size > max_queue_size)
                        {
                            max_queue_size = m_size;
                            Console.WriteLine("New maximum queue size observed  = {0}", max_queue_size);
                        }
                    }
#endif
                }
            }

            Console.WriteLine("");

            Console.WriteLine("Number of global  states visited = {0}", visited.Count);
            Console.WriteLine("Number of visible states visited = {0}", visible.Count);
            Console.WriteLine();

            visited_k.Close();

            if (visible_abstraction)
            {
                // dump reached visible states into a file
                StreamWriter visible_k = new StreamWriter("visible-" + (k < 10 ? "0" : "") + k.ToString() + ".txt");
                foreach (StateImpl vs in visible)
                {
                    visible_k.Write(vs.ToPrettyString());
                    visible_k.WriteLine("==================================================");
                }

                visible_k.Close();
            }
        }

        public static void OS_Iterate(StateImpl start)
        {
            if (PrtEventBuffer.k == 0) { Console.WriteLine("OS Exploration: skipping k=0 (makes no sense)"); goto Next_Round; }

            Console.Write("About to explore state space for queue bound k = {0}. Press <ENTER> to continue, anything else to 'Exit(0)': ", PrtEventBuffer.k);
            if (!String.IsNullOrEmpty(Console.ReadLine()))
            {
                Console.WriteLine("Exiting.");
                Environment.Exit(0);
            }

            Dfs(start, true);

            if (size_Visited_previous == visited.Count)
            {
                Console.WriteLine("Global state sequence converged!");
                Console.Write("For fun, do you want to run the abstract convergence test as well? Press <ENTER> to continue, anything else to 'Exit(0)': ");
                if (!String.IsNullOrEmpty(Console.ReadLine()))
                {
                    Console.WriteLine("Exiting.");
                    Environment.Exit(0);
                }
            }

            // when do we have to run the abstract convergence test?
            if (size_Visible_previous_previous < size_Visible_previous && size_Visible_previous == visible.Count)
            {
                Console.WriteLine("New plateau detected.");
                Console.Write("Running abstract state convergence test with tail-" + PrtEventBuffer.qt.ToString() + " abstraction ... ");

                if (visible_converged())
                {
                    Console.WriteLine("converged!");
                    Environment.Exit(0);
                }
            }

            size_Visible_previous_previous = size_Visible_previous;
            size_Visible_previous = visible.Count;
            size_Visited_previous = visited.Count;

        Next_Round:
            ++PrtEventBuffer.k;
            OS_Iterate(start);
        }

        // compute visible successors, and return true ("converged") iff all of them are already contained in visible:
        static bool visible_converged()
        {
            foreach (StateImpl vs in visible)
            {
                for (int currIndex = 0; currIndex < vs.ImplMachines.Count; ++currIndex)
                {
                    PrtImplMachine m = vs.ImplMachines[currIndex];

                    // reject disabled machines
                    if (!(m.currentStatus == PrtMachineStatus.Enabled))
                        continue;

                    // reject machines not dequeing or receiving. I assume these are the only two that can lead to a call to PrtDequeueEvent
                    if (!(m.nextSMOperation == PrtNextStatemachineOperation.DequeueOperation ||
                          m.nextSMOperation == PrtNextStatemachineOperation.ReceiveOperation))
                        continue;

                    if (m.eventQueue.Empty()) // apparently enabled machines whose next SM op is dequeue or receive may have still an empty queue
                        continue;

                    if ( PrtEventBuffer.qt == PrtEventBuffer.Queue_Type.list ? new_cand_from_list(vs, currIndex) : new_cand_from_set(vs, currIndex) )
                        return false;
                }
            }
            return true;
        }

        // Try to dequeue an event and look for new abstract states

        // for queue-list abstraction:
        static bool new_cand_from_list(StateImpl vs, int currIndex)
        {
            PrtImplMachine m = vs.ImplMachines[currIndex];
            List<PrtEventNode> m_q = m.eventQueue.events;

            StateImpl vs_succ = (StateImpl)vs.Clone();
            PrtImplMachine m_succ = vs_succ.ImplMachines[currIndex];
            List<PrtEventNode> m_succ_q = m_succ.eventQueue.events;
            m_succ.PrtRunStateMachine();
            if (m_succ_q.Count < m_q.Count && !CheckFailure(vs_succ, 0)) // if dequeing was successful
            {
                Debug.Assert(m_q.Count == m_succ_q.Count + 1); // we have dequeued exactly one event
                // Find the dequeued event, to correct the abstract queue
                int i;
                for (i = 0; i < m_q.Count; ++i)
                {
                    if (i == m_succ_q.Count || !m_q[i].Equals(m_succ_q[i]))   // if we are past m_succ_q  OR  the ith event before and after dequeue differ, then
                        break; // i points to the dequeued event
                }
                Debug.Assert(i < m_q.Count);
                PrtEventNode dequeued_ev = m_q[i];
                Debug.Assert(!m_succ_q.Contains(dequeued_ev)); // we just dequeued it, and the queue contains no duplicates
                // choice 1: dequeued_ev existed exactly once in the concrete m_q. Then it is gone after the dequeue, in both abstract and concrete. The new state abstract is valid.
                if (new_cand(vs, vs_succ, currIndex, dequeued_ev))
                    return true;
                // choice 2: dequeued_ev existed >= twice in concrete m_q. Now we need to find the positions where to re-introduce it in the abstract, and try them all non-deterministically
                for (int j = i; j < m_succ_q.Count; ++j)
                {
                    // insert dequeue_ev at position j (push the rest to the right)
                    m_succ_q.Insert(j, dequeued_ev);
                    if (new_cand(vs, vs_succ, currIndex, dequeued_ev))
                        return true;
                    m_succ_q.RemoveAt(j); // restore previous state
                }
                m_succ_q.Add(dequeued_ev); // finally, insert dequeue_ev at end
                if (new_cand(vs, vs_succ, currIndex, dequeued_ev))
                    return true;
            }
            return false;
        }

        // for queue-set abstraction:
        static bool new_cand_from_set(StateImpl vs, int currIndex)
        {
            PrtImplMachine m = vs.ImplMachines[currIndex];
            List<PrtEventNode> m_q = m.eventQueue.events;

            foreach (PrtEventNode ev in m_q)
            {
                StateImpl vs_succ = (StateImpl)vs.Clone();
                PrtImplMachine m_succ = vs_succ.ImplMachines[currIndex];
                PrtEventBuffer m_succ_buffer = m_succ.eventQueue;
                List<PrtEventNode> m_succ_q = m_succ_buffer.events;
                // prepare the buffer for running the machine: make head with no tail
                m_succ_q.Clear();
                m_succ_q.Add(ev.Clone());
                m_succ.PrtRunStateMachine();
                if (m_succ_buffer.Empty() && !CheckFailure(vs_succ, 0)) // if dequeing was successful
                {
                    foreach (PrtEventNode ev2 in m_q) m_succ_q.Add(ev2.Clone()); // restore whole queue set (we had cleared it for controlled running of the state machine on ev only)
                    // choice 1: ev existed >= twice in concrete m_q. No change in queue set abstraction
                    if (new_cand(vs, vs_succ, currIndex, ev))
                        return true;
                    // choice 2: ev existed once in m_q, so after the dequeue it is gone
                    m_succ_q.Remove(ev);
                    if (new_cand(vs, vs_succ, currIndex, ev))
                        return true;
                }
            }
            return false;
        }

        static bool new_cand(StateImpl vs, StateImpl vs_succ, int currIndex, PrtEventNode dequeue_ev)
        {
            if (visible.Contains(vs_succ)
#if __STATE_INVARIANTS__
                || !vs_succ.state_invariant(currIndex)
#endif
#if __TRANS_INVARIANTS__
                || !vs_succ.trans_invariant(currIndex, vs)
#endif
                )
                return false;

            // candidate is new and satisfies the invariants

            Console.WriteLine("did not converge.");
            Console.WriteLine("Found a so-far unreached successor candidate. It was generated by ImplMachine {0} while trying to dequeue event {1}.", currIndex, dequeue_ev.ToString());

            StreamWriter vs_SW = new StreamWriter("vs.txt"); vs_SW.WriteLine(vs.ToPrettyString()); vs_SW.Close();
            StreamWriter vs_succ_SW = new StreamWriter("vs_succ.txt"); vs_succ_SW.WriteLine(vs_succ.ToPrettyString()); vs_succ_SW.Close();

            Console.WriteLine("Dumped abstract source state and successor candidate state into files. Their hashes are {0} and {1}.", vs.GetHashCode(), vs_succ.GetHashCode());
            Console.WriteLine();

            return true;
        }

        static void PrintStackDepth(int depth)
        {
            for (int i = 0; i < depth; i++)
            {
                Console.Write(".");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// - runs the state machine pointed to by CurrIndex, in place, and returns the successor wrapped into a bstate. Nothing gets cloned.
        /// - assigns to argument a clone (!) of the old bstate, and advances its choice vector and currIndex, as appropriate
        /// So bstate points to new memory after calling Execute. The returned successor is stored in old memory.
        /// </summary>
        /// <param name="bstate"></param>
        /// <returns></returns>
        static BacktrackingState Execute(BacktrackingState bstate)
        {
            var origState = (StateImpl)bstate.State.Clone();

            int choiceIndex = 0;

            // bstate.State.UserBooleanChoice is a pointer to a function with signature f: {} -> Bool.
            // The following assigns the code under 'delegate' to this function pointer.
            // bstate and choiceIndex are global variables
            bstate.State.UserBooleanChoice = delegate ()
            {
                if (choiceIndex < bstate.ChoiceVector.Count)
                {
                    return bstate.ChoiceVector[choiceIndex++];
                }

                choiceIndex++;
                bstate.ChoiceVector.Add(false);
                return false;
            };

            bstate.State.EnabledMachines[bstate.CurrIndex].PrtRunStateMachine();

            Debug.Assert(choiceIndex == bstate.ChoiceVector.Count);

            // flip last choice          
            while (bstate.ChoiceVector.Count > 0 && bstate.ChoiceVector[bstate.ChoiceVector.Count - 1])
            {
                bstate.ChoiceVector.RemoveAt(bstate.ChoiceVector.Count - 1);
            }

            if (bstate.ChoiceVector.Count > 0)
            {
                bstate.ChoiceVector[bstate.ChoiceVector.Count - 1] = true;
            }

            var ret = new BacktrackingState(bstate.State);
            ret.depth = bstate.depth + 1;

            bstate.State = origState;

            if (bstate.ChoiceVector.Count == 0)
            {
                bstate.CurrIndex++; // first iterate through all choices. When exhausted, step to the next enabled machine
            }

            return ret;
        }

        static bool CheckFailure(StateImpl s, int depth)
        {
            if (UseDepthBounding && depth > DepthBound)
            {
                return true;
            }

            if (s.Exception == null)
            {
                return false;
            }


            if (s.Exception is PrtAssumeFailureException)
            {
                return true;
            }
            else if (s.Exception is PrtException)
            {
                Console.WriteLine(s.errorTrace.ToString());
                Console.WriteLine("ERROR: {0}", s.Exception.Message);
                Environment.Exit(-1);
            }
            else
            {
                Console.WriteLine(s.errorTrace.ToString());
                Console.WriteLine("[Internal Exception]: Please report to the P Team");
                Console.WriteLine(s.Exception.ToString());
                Environment.Exit(-1);
            }
            return false;
        }
    }

    class BacktrackingState
    {
        public StateImpl State;
        public int CurrIndex;            // index of the next machine to execute
        public List<bool> ChoiceVector;  // length = number of choices to be made; contents of list = current choice as bitvector
        public int depth;                // used only with depth bounding

        public BacktrackingState(StateImpl state)
        {
            this.State = state;
            CurrIndex = 0;
            ChoiceVector = new List<bool>();
            depth = 0;
        }

    }
}
