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
            Console.WriteLine("Using queue bound of {0}", k);
            P.Runtime.PrtImplMachine.k = k;

            visited.Clear();
            visible.Clear();

#if DEBUG
            max_queue_size = 0;
#endif

            var stack = new Stack<BacktrackingState>();

            StreamWriter visited_k = new StreamWriter("visited-" + k.ToString() + ".txt"); // for dumping visited states as strings into a file

            StateImpl s = (StateImpl)start.Clone(); // clone this since we need the original 'start', for later iterations of Explore

            stack.Push(new BacktrackingState(s));
            int start_hash = s.GetHashCode();
            visited.Add(start_hash);
            visited_k.WriteLine(s.ToString()); // + " = " + start_hash.ToString());

            var vs = new VState(s);
            visible.Add(vs.GetHashCode(), vs);

            // DFS begin
            while (stack.Count != 0)
            {
                // PrintStackDepth(stack.Count);

                var bstate = stack.Pop();
                var enabledMachines = bstate.State.EnabledMachines;


                if (bstate.CurrIndex >= enabledMachines.Count) // if "done" with bstate
                {
                    continue;
                }

                BacktrackingState next = Execute(bstate);

                stack.Push(bstate); // after increasing the index, push state back on. This is like modifying bstate "on the stack"

                if (!CheckFailure(next.State, next.depth)) // should we check for "new" first, then check for failure? failure check could become complicated some day
                {
                    var hash = next.State.GetHashCode();

                    if (!UseStateHashing)
                    {
                        throw new NotImplementedException();
                    }

                    if (!visited.Contains(hash))
                    {

                        // a new global states: update the various data structures
                        stack.Push(next);
                        visited.Add(hash);
                        visited_k.WriteLine(next.State.ToString()); // + " = " + hash.ToString());

                        // update visible state dictionary
                        var next_vs = new VState(next.State);
                        var vhash = next_vs.GetHashCode();
                        if (!visible.ContainsKey(vhash))
                        {
                            visible.Add(vhash, next_vs);
                            // Console.WriteLine(next_vs.ToString());
                        }

                        // diagnostics
#if DEBUG
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

        public static bool visible_converged()
        {
            return false;
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
                bstate.CurrIndex++;
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


    // Part I: define what an "abstract state" is. The general guidelines are as follows. An abstract state consists of two parts:
    // 1. the /visible fragment/ of the state, which is a part of the state information that is kept concretely, precisely, in plain text; and
    // 2. an abstraction of the rest of the state information.
    // This state partitioning should satisfy two properties:
    // (a) It defines a finite state space. That is, the set of visible fragments + abstractions of the rest of all conceivable states is finite.
    // (b) It contains all the information needed to determine fireability of a transition, and the visible fragment of the successor state.
    // As an example, for the common case of a message passing system with finitely many local states, a finite set of message types, but unbounded queues,
    // the visible state might contain of the complete local state and the head of the queue of each machine.
    // The abstraction of the rest might be the set of the messages in the rest of the queue, i.e. ignoring ordering and multiplicity.

    // The following implementation is inelegant: a VState should really be derived from a StateImpl, not /have/ a StateImpl. I guess we need a copy constructor, similar to Clone. Too messy ...
    class VState
    {
        private StateImpl s;

        public VState(StateImpl s)
        {
            this.s = (StateImpl)(s.Clone());
            // abstract each ImplMachine
            foreach (var m in this.s.ImplMachines)
            {
                m.abstract_me();
                // Console.WriteLine("Abstract queue size = {0}", implMachines[i].eventQueue.Size());
            }
        }

        // these would not be required if VState was derived from StateImpl
        public override string ToString() { return s.ToString(); }
        public override int GetHashCode() { return s.GetHashCode(); }
    }
}
