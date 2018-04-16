using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P.Runtime;
using System.Diagnostics;


namespace P.Tester
{
    static class DfsExploration
    {
        public static bool UseDepthBounding = false;
        public static int DepthBound = 100;

        public static bool UseStateHashing = true; // currently doesn't make sense without

        public static StateImpl start; // start state. Silly: I assume CommandLineOptions sets the start state. Improve this

        public static HashSet<int>                  visited = new HashSet<int>();
        public static SortedDictionary<int, VState> visible = new SortedDictionary<int, VState>();
        
        public static int size_Visible_previous = 0;
        public static int size_Visible_previous_previous = 0;

        public static void Explore(int k)
        {
            Console.WriteLine("Using queue bound of {0}", k);
            P.Runtime.PrtImplMachine.k = k;

            // uint state_number = 0;

            visited.Clear();
            visible.Clear();

            var stack = new Stack<BacktrackingState>();

            stack.Push(new BacktrackingState(start));
            visited.Add(start.GetHashCode());

            var vs = new VState(start);
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

                    // if (!UseStateHashing || !visited.Contains(hash)) // I don't understand this line: if state hashing not used, this will always add next to stack, whether new or not
                    if (!visited.Contains(hash))
                    {
                        stack.Push(next);
                        visited.Add(hash);
                        // Console.WriteLine("Encountered state number {0}", ++state_number);
                        var next_vs = new VState(next.State);
                        var vhash = next_vs.GetHashCode();
                        if (!visible.ContainsKey(vhash))
                        {
                            visible.Add(vhash, next_vs);
                        }
                    }
                }
            }

            Console.WriteLine("Number of distinct         states visited = {0}", visited.Count);
            Console.WriteLine("Number of distinct visible states visited = {0}", visible.Count);
        }

        public static bool visible_converged()
        {
            return false;
        }

        public static void OS_Explore(int k0)
        {
            int k = k0;
            do
            {
                Console.Write("About to DFS-explore state space for bound k = {0}. Continue (<ENTER> for 'y')?", k);
                int ans = Console.Read();
                if (ans == 'n' || ans == 'N')
                    break;

                Explore(k);

                // when do we have to run the convergence test?
                if (size_Visible_previous_previous < size_Visible_previous && size_Visible_previous == visible.Count)
                { // a new plateau!
                    if (visible_converged())
                    {
                        Console.WriteLine("Converged!");
                        Environment.Exit(0);
                    }
                }

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
    // The abstraction of the rest might be a set of the messages in the rest of the queue, i.e. ignoring ordering and multiplicity.

    // The following implementation is inelegant: a VState should really be derived from a StateImpl, not /have/ a StateImpl. Not quite clear in C# -- need a copy constructor, similar to Clone?
    class VState
    {
        private StateImpl s;

        public VState(StateImpl s)
        {
            this.s = (StateImpl)(s.Clone());
            // the abstraction is a per-machine abstraction
            List<PrtImplMachine> implMachines = s.ImplMachines; // a reference, hopefully (not copy)
            for (int i = 0; i < implMachines.Count; ++i)
            {
                implMachines[i].abstract_me();
                Console.WriteLine("Abstract queue size = {0}", implMachines[i].eventQueue.Size());
            }
        }
    }
}
