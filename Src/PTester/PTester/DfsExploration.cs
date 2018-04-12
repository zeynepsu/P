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

        public static ushort k = 0; // queue size bound. '0' means 'unbounded'

        public static void Explore(StateImpl s, CommandLineOptions options)
        {
            var stack = new Stack<BacktrackingState>();
            var visited = new HashSet<int>();
            var visible = new SortedDictionary<int, VisibleState>();

            k = options.k;
            Console.WriteLine("Using queue bound of {0}", k);
            P.Runtime.PrtImplMachine.k = k;

            // uint state_number = 0;

            stack.Push(new BacktrackingState(s));
            visited.Add(s.GetHashCode());

            var vs = new VisibleState((StateImpl)(s.Clone()));
            visible.Add(vs.hash, vs);

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

                if (!CheckFailure(next.State, next.depth))
                {
                    var hash = next.State.GetHashCode();

                    if (!options.UseStateHashing)
                    {
                        throw new NotImplementedException();
                    }

                    // if (!options.UseStateHashing || !visited.Contains(hash)) // I don't understand this line: if state hashing not used, this will always add next to stack, whether new or not
                    if (!visited.Contains(hash))
                    {
                        stack.Push(next);
                        visited.Add(hash);
                        // Console.WriteLine("Encountered state number {0}", ++state_number);
                        var next_vs = new VisibleState((StateImpl)(next.State.Clone()));
                        visible.Add(next_vs.hash, next_vs);

                    }
                }
            }

            Console.WriteLine("Number of distinct         states visited = {0}", visited.Count);
            Console.WriteLine("Number of distinct visible states visited = {0}", visible.Count);
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
            if(UseDepthBounding && depth > DepthBound)
            {
                return true;
            }

            if(s.Exception == null)
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

  
        
    class VisibleState : StateImpl
    {   
//        public List<PrtValue> heads; // list of events at the head of each ImplMachine's event queue, or "null" if queue empty
        public int hash;             // hash value computed from the visible state's StateImpl interpretation

        public override StateImpl MakeSkeleton() { return this; } // meaning unclear, but required

        // precond: state is already cloned. Don't know how to program this better
        public VisibleState(StateImpl state)
        {
            hash = 10;
            //          heads = new List<PrtValue>();
            //        List<PrtImplMachine> implMachines = state.ImplMachines; // a reference, hopefully (not copy)
            //      for (int i = 0; i < implMachines.Count; i++)
            //    {
            //      PrtImplMachine m = implMachines[i]; // a reference, hopefully (not copy)
            //    if (m.eventQueue.Size() == 0)
            //  {
            //    heads.Add(PrtValue.@null);
            //}
            //                else
            //              {
            //                heads.Add(m.eventQueue.Head());
            //          }
            //    }
        }
    }
}
