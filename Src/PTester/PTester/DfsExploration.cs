using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static StateImpl start; // start state. Silly: I assume CommandLineOptions sets the start state. Improve this

        public static HashSet<int> visited = new HashSet<int>();
        public static SortedDictionary<int, VState> visible = new SortedDictionary<int, VState>();

        public static int size_Visible_previous = 0;
        public static int size_Visible_previous_previous = 0;

        public static void Explore(int k)
        {

            if (!UseStateHashing) throw new NotImplementedException();

            Console.WriteLine("Using queue bound of {0}", k);
            P.Runtime.PrtImplMachine.k = k;

            visited.Clear();
            visible.Clear();

#if DEBUG
            max_queue_size = 0;
#endif

            var stack = new Stack<BacktrackingState>();

            StreamWriter visited_k = new StreamWriter("visited-" + k.ToString() + ".txt"); // for dumping visited states as strings into a file

            StateImpl s = (StateImpl)start.Clone(); // we need a fresh clone in each iteration of Explore

            stack.Push(new BacktrackingState(s));
            int start_hash = s.GetHashCode();
            visited.Add(start_hash);
            visited_k.WriteLine(s.ToString()); // + " = " + start_hash.ToString());

            var vs = new VState(s);
            visible.Add(vs.GetHashCode(), vs);

            // DFS begin
            while (stack.Count != 0)
            {
                var bstate = stack.Pop();

                // PrintStackDepth(stack.Count);

                if (bstate.CurrIndex >= bstate.State.EnabledMachines.Count) // if "done" with bstate
                {
                    continue;
                }

                BacktrackingState next = Execute(bstate); // execute the enabled machine pointed to by currIndex. Also, advance currIndex and/or choiceIndex
                stack.Push(bstate);                       // after increasing currIndex/choiceIndex, push state back on. This is like modifying bstate "on the stack"

                if (!CheckFailure(next.State, next.depth))
                {
                    var hash = next.State.GetHashCode();
                    if (!visited.Add(hash))  // first check for failure, then (try to) add hash, since the latter has a side effect
                        continue;
                    stack.Push(next);
                    visited_k.WriteLine(next.State.ToString()); // + " = " + hash.ToString());

                    // update visible state dictionary
                    var next_vs = new VState(next.State);
                    var vhash = next_vs.GetHashCode();

                    try { visible.Add(vhash, next_vs); /* Console.WriteLine(next_vs.ToString()); */ }
                    catch (ArgumentException) { } // not new: ignore
#if DEBUG
                    // diagnostics

                    // update maximum encountered queue size
                    foreach (PrtImplMachine m in next.State.ImplMachines)
                    {
                        int m_size = m.eventQueue.Size();
                        max_queue_size = (m_size > max_queue_size ? m_size : max_queue_size);
                    }

                    // Print number of states explored
                    if (visited.Count % 1000 == 0)
                    {
                        Console.WriteLine("-------------- Number of states visited so far = {0}", visited.Count);
                    }
#endif
                }
            }

            Console.WriteLine("");

            Console.WriteLine("Number of         states visited = {0}", visited.Count);
            Console.WriteLine("Number of visible states visited = {0}", visible.Count);

            visited_k.Close();

            // dump reached visible states into a file
            StreamWriter visible_k = new StreamWriter("visible-" + k.ToString() + ".txt");
            foreach (KeyValuePair<int, VState> pair in visible)
            {
                visible_k.WriteLine(pair.Value.ToString());
            }
            visible_k.Close();

#if DEBUG
            Console.WriteLine("Maximum queue size observed      = {0}", max_queue_size);
#endif

        }

        // Step II: compute abstract successors, and return true ("converged") iff all of them are already contained in visible:
        // for each visible state vs:
        //   for each abstract successor vs' of vs:
        //     if vs' not in visible:
        //       return false;
        // return true;
        public static bool visible_converged()
        {
            Debug.Assert(visible.Count > 0);
            return false;

            foreach (KeyValuePair<int, VState> pair in visible)
            {
                VState vs = pair.Value;
                StateImpl s = vs.s;

                var stack = new Stack<BacktrackingState>(); // doesn't really have to be a stack
                stack.Push(new BacktrackingState(s));

                // mini DFS: only immediate successors
                while (stack.Count != 0)
                {
                    var bstate = stack.Pop();

                    int currIndex = bstate.CurrIndex; // which machine is about to be fired?

                    if (currIndex >= bstate.State.EnabledMachines.Count) // if "done" with bstate
                    {
                        continue;
                    }

                    // skip machines whose event queue is empty (we care only about RECV actions)
                    if (bstate.State.ImplMachines[currIndex].eventQueue.Empty()) // if queue is empty
                    {
                        bstate.CurrIndex++;
                        // we likely also need to reset the choiceVector. To what?
                        stack.Push(bstate);
                        continue;
                    }

                    BacktrackingState s_succ = Execute(bstate);
                    stack.Push(bstate);

                    // Overapproximating RECV actions: we know the current state's queue is non-empty (previous if). Now we require the successor's queue to be empty:
                    if (s_succ.State.ImplMachines[currIndex].eventQueue.Empty())
                    {
                        // abstract to visible state
                        var vs_succ = new VState(s_succ.State);
                        Debug.Assert(vs_succ.GetHashCode() == s_succ.GetHashCode()); // there should be no change: the visible state of a state with an empty queue equals that state (all unaffected queues have size 1)
                        // bstate's queue has an empty tail. We assume for now this does not affect the question what machines are enabled.
                        //   In the absence of DEFERs this seems to be true; we deal with DEFER separately (we defer it...), as it is kind of a special, non-FIFO feature.
                        // The tail of the queue does affect the successor state, however, and even the ABSTRACT (visible) successor: namely, it determines the head of the new queue.
                        // For soundness we have to overapproximate here: after firing a RECEIVE rule we don't know what the new queue head is. So assume it can be anything.
                        //for each possible message + payload(m, p)
                        //{
                        //    s_succ.State.ImplMachines[currIndex].eventQueue.head = (m, p)
                        //    if (!visible.ContainsKey(vs_succ.GetHashCode()))
                        //        return false;
                        //}
                    }
                }
            }
            return true;
        }

        public static void OS_Iterate(int k0)
        {
            if (k0 == 0)
            {
                Console.WriteLine("OS Exploration: skipping k=0 (makes no sense)");
                OS_Iterate(1);
            }

            int k = k0;
            do
            {
                Console.Write("About to explore state space for bound k = {0}. Continue (<ENTER> for 'y') ? ", k);
                string ans = Console.ReadLine();
                if (ans == "n" || ans == "N")
                    break;

                Explore(k);

                // when do we have to run the convergence test?
                if (size_Visible_previous_previous < size_Visible_previous && size_Visible_previous == visible.Count)
                { // a new plateau!
                    Console.Write("Running convergence test ...");
                    if (visible_converged())
                    {
                        Console.WriteLine(" Converged!");
                        Environment.Exit(0);
                    }
                    Console.WriteLine(" did not converge; continuing");
                }

                size_Visible_previous_previous = size_Visible_previous;
                size_Visible_previous = visible.Count;

                ++k;

            } while (true);
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
        /// Returns the new state, modifies the original state in place (for the next choice)
        /// </summary>
        /// <param name="bstate"></param>
        /// <returns></returns>
        static BacktrackingState Execute(BacktrackingState bstate)
        {
            var origState = (StateImpl)bstate.State.Clone();

            int choiceIndex = 0;
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


    // Step I: define what an "abstract state" is. The general guidelines are as follows. An abstract state consists of two parts:
    // 1. the /visible fragment/ of the state, "visible state" for short, which is a part of the state information that is kept concretely, precisely, in plain text; and
    // 2. an abstraction of the rest of the state information (which may be implicit if the visible fragment is some sort of approximation).
    // This state partitioning should satisfy two properties:
    // (a) It defines a finite state space. That is, the set of visible fragments + abstractions of the rest of all conceivable states is finite.
    // (b) It contains "most" of the information needed to determine fireability of a transition and the visible fragment of the successor state.
    // (c) It contains enough information to decide whether some target safety property is satisfied.
    // As an example, for the common case of a message passing system with finitely many local states, a finite set of message + payload types, but unbounded queues,
    // the visible state might consist of
    // * the complete local state, plus
    // * the head of the queue of each machine, plus
    // * the /set/ of items in the tail of the queue.
    // The "abstraction of the rest" amounts to ignoring the multiplicity and ordering of messages in the tail of the queue.
    // This defines a finite state space and allows us to decide whether e.g. the system is responsive (we don't need the tail of the queue for that).
    // It is enough info to decide whether a transition is fireable: depends on local state and queue head.
    // Finally, abstract successors of RECEIVEs cannot be precisely computed since the head of the successor queue is unknown (but we know it is a member of the tail set).

    // The following implementation is inelegant: a VState should really be derived from a StateImpl, not /have/ a StateImpl. I guess we need a copy constructor, similar to Clone. Too messy?
    class VState
    {
        public StateImpl s;

        public VState(StateImpl s)
        {
            this.s = (StateImpl)(s.Clone());
            // abstract each ImplMachine
            foreach (var m in this.s.ImplMachines)
                m.abstract_me();
        }

        // these wouldn't be required if VState was derived from StateImpl
        public override string ToString() { return s.ToString(); }
        public override int GetHashCode() { return s.GetHashCode(); }
    }
}
