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

        public static void Explore(StateImpl s, CommandLineOptions options)
        {
            var stack = new Stack<BacktrackingState>();
            var visited = new HashSet<int>();

            stack.Push(new BacktrackingState(s));
            visited.Add(s.GetHashCode());

            while (stack.Count != 0) // while stack is non-empty
            {
                PrintStackDepth(stack.Count);

                var bstate = stack.Pop();
                var enabledMachines = bstate.State.EnabledMachines;

                if(bstate.CurrIndex >= enabledMachines.Count)
                {
                    continue;
                }

                var next = Execute(bstate);

                stack.Push(bstate);

                if (!CheckFailure(next.State, next.depth))
                {
                    var hash = next.State.GetHashCode();

                    if (!options.UseStateHashing || !visited.Contains(hash))
                    {
                        stack.Push(next);
                        visited.Add(hash);
                    }
                }
            }

        }

        static void PrintStackDepth(int depth)
        {
            for(int i = 0; i < depth; i++)
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
            while (bstate.ChoiceVector.Count > 0 && bstate.ChoiceVector[bstate.ChoiceVector.Count - 1] == true)
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
        public int CurrIndex;
        public List<bool> ChoiceVector;
        public int depth;

        public BacktrackingState(StateImpl state)
        {
            this.State = state;
            CurrIndex = 0;
            ChoiceVector = new List<bool>();
            depth = 0;
        }

    }
}
