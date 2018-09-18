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
    static class Constants
    {
        public const string dumpFileConcretePrefix = "concretes-";
        public const string dumpFileAbstractPrefix = "abstracts-";
        public const string dumpFileAbstractSuccPrefix = "abstract_succs-";
        public const string dumpFileTransitionPrefix = "transitions-";

        public const string dumpFileExtension = ".txt";

        public const string consoleSeparator = "==================================================";
    }
    /// <summary>
    /// The main class of OS approach
    /// </summary>
    static class DfsExploration
    {
        // static bool UseDepthBounding = false;
        // static int DepthBound = 100;

        public static bool useStateHashing = true; // currently doesn't make sense without hashing
        public static bool fileDump = false;

        /// <summary>
        /// the set of concrete states, storing in hash values, we have found in current round
        /// </summary>
        static HashSet<int> concretesInHash = new HashSet<int>();
        /// <summary>
        /// the set of abstract states, storing in hash values, we have found in current round
        /// </summary>
        static HashSet<int> abstractsInHash = new HashSet<int>();
        /// <summary>
        /// the set of successors of abstract states, storing in hash values, we have found in current round
        /// </summary>
        static HashSet<int> abstractSuccsInHash = new HashSet<int>();

        /// <summary>
        /// --PL: the number of reached concrete states when queue is bounded by k-1
        /// </summary>
        static int countConcretesPrevious = 0;
        /// <summary>
        /// --PL: the number of reached abstract states when queue is bounded by k-1
        /// </summary>
        static int countAbstractsPrevious = 0;
        /// <summary>
        /// --PL: the number of reached abstract states when queue is bounded by k-2
        /// </summary>
        static int countAbstractsPreviousPrevious = 0;

        /// <summary>
        /// For convergence detection:
        /// c -> c'
        /// |    |
        /// |    |
        /// a -> a', b' = alpha(c') (MUST: b' in A)
        /// </summary>
        static HashSet<int> competitors;

        public static StateImpl start = null;

        /// <summary>
        /// -- PL: the main procedure of OS exploration
        /// </summary>
        public static void OSIterate()
        {
            //if (PrtEventBuffer.k == 0)
            //  goto Next_Round; // skip 0: makes no sense

            while (true)
            {
                // skip k=0: makes no sense
                if (PrtEventBuffer.k == 0)
                {
                    ++PrtEventBuffer.k;
                    continue;
                }

                Console.Write("About to explore state space for queue bound k = {0}. Press <ENTER> to continue, anything else to 'Exit(0)': ", PrtEventBuffer.k);
                bool stop = (Console.ReadKey().Key != ConsoleKey.Enter);
                Console.WriteLine();
                if (stop)
                {
                    Console.WriteLine("Exiting.");
                    Environment.Exit(0);
                }

                try
                {
                    Dfs(true); /// with abstraction
                    Debug.Assert(StateImpl.mode == StateImpl.ExploreMode.normal, "Dfs should always find the successor state with the given hash code"); // --PL Q?
                }
                catch (StateImpl.SuccessorFound sfe) // --PL if a successor found
                {
                    string ap_str = "unreached";
                    string bp_str = "reached";
                    StreamWriter a_SW = new StreamWriter("a.txt");
                    a_SW.WriteLine(sfe.a.ToPrettyString());
                    a_SW.Close();
                    StreamWriter ap_SW = new StreamWriter(ap_str + Constants.dumpFileExtension);
                    ap_SW.WriteLine(sfe.ap.ToPrettyString());
                    ap_SW.Close();
                    Console.WriteLine("Located the so-far unreached abstract state and pretty-printed it into file {0}.txt .", ap_str);
                    StateImpl.mode = StateImpl.ExploreMode.find_comp;
                    competitors = new HashSet<int>();
                    Console.WriteLine("Restarting Dfs to find reachable abstract states 'parallel' to this so-far unreached state ...");
                    Dfs(); /// DFS restarts, why not queueAbstraction
                    Debug.Assert(competitors.Count > 0);
                    Console.WriteLine("Pretty-printed reachable parallel abstract states into files {0}0.txt..{0}{1}.txt .", bp_str, competitors.Count - 1);
                    Console.WriteLine("These states are \"competitors\" to the so-far unreached abstract state.");
                    Console.WriteLine("You should compare each reached state to the unreached state; the difference might reveal why the former are reachable while the latter may not be.");
                    /// The following is experimental
                    /// TODO: rewrite this part
                    string cmd = "c:\\Program Files\\Meld\\Meld.exe"; // your favorite diff command here. It must accept two filename arguments
                    string arg = bp_str + "0.txt " + ap_str + Constants.dumpFileExtension;
                    Console.Write("Press <ENTER> to run \"{0} {1}\", anything else to 'Exit(0)': ", cmd, arg);
                    bool run = (Console.ReadKey().Key == ConsoleKey.Enter);
                    Console.WriteLine();
                    if (run)
                    {
                        Console.WriteLine("Running external command.");
                        try
                        {
                            Process.Start(cmd, arg);
                        }
                        catch (System.Exception e)
                        {
                            Console.WriteLine("External command: something went wrong: {0}", e.Message);
                            Environment.Exit(-1);
                        }
                    }
                    Console.WriteLine("Exiting.");
                    Environment.Exit(0);
                }

                if (countConcretesPrevious == concretesInHash.Count) /// --PL: OS1 converges
                {
                    Console.WriteLine("Global state sequence converged!");
                    Console.Write("For fun, do you want to run the abstract convergence test as well? Press <ENTER> to continue, anything else to 'Exit(0)': ");
                    stop = (Console.ReadKey().Key != ConsoleKey.Enter);
                    Console.WriteLine();
                    if (stop)
                    {
                        Console.WriteLine("Exiting.");
                        Environment.Exit(0);
                    }
                }

                /// reach a plateau in OS3
                if (countAbstractsPreviousPrevious < countAbstractsPrevious && countAbstractsPrevious == abstractsInHash.Count)
                {
                    Console.WriteLine("New plateau detected.");
                    Console.Write("Running abstract state convergence test with tail-list abstraction ... ");

                    if (HasAbstractConverged()) /// convergence detection
                    {
                        Console.WriteLine("converged!");
                        Environment.Exit(0);
                    }
                }

                countAbstractsPreviousPrevious = countAbstractsPrevious;
                countAbstractsPrevious = abstractsInHash.Count;
                countConcretesPrevious = concretesInHash.Count;

                ++PrtEventBuffer.k; /// step into next round
            }
            //Next_Round:
            //++PrtEventBuffer.k;
            //OSIterate();
        }


        /// <summary>
        /// --PL: Queue-unbounded exploration, in DFS mode
        /// </summary>
        /// <param name="queueAbstraction">Abstracting queue or not, default is not (set param as false)</param>
        public static void Dfs(bool queueAbstraction = false)
        {
            if (!useStateHashing)
                throw new NotImplementedException();

            Console.WriteLine("Using "
                + (PrtEventBuffer.k == 0 ? "unbounded queue" : "queue bound of " + PrtEventBuffer.k.ToString()));
            /// Throw away states obtained from last rounds as all of them are static variables 
            concretesInHash.Clear();
            abstractsInHash.Clear();
            abstractSuccsInHash.Clear();

#if DEBUG
            int max_queue_size = 0;
            int max_stack_size = 0;
#endif
            /// worklist, implemented using stack
            var worklist = new Stack<BacktrackingState>();

            /// --PL: dump states & transitions to files
            StreamWriter concretesFile = null;
            StreamWriter abstractsFile = null;
            StreamWriter abstractSuccsFile = null;
            StreamWriter transitionsFile = null;
            if (fileDump)
            {
                /// add "0" for name formating
                var suffix = (PrtEventBuffer.k < 10 ? "0" : "") + PrtEventBuffer.k.ToString();
                concretesFile = new StreamWriter(Constants.dumpFileConcretePrefix
                    + suffix
                    + Constants.dumpFileExtension);
                abstractsFile = new StreamWriter(Constants.dumpFileAbstractPrefix
                    + suffix
                    + Constants.dumpFileExtension);
                abstractSuccsFile = new StreamWriter(Constants.dumpFileAbstractSuccPrefix
                    + suffix
                    + Constants.dumpFileExtension);
                transitionsFile = new StreamWriter(Constants.dumpFileTransitionPrefix
                    + suffix
                    + Constants.dumpFileExtension);
            }

            Debug.Assert(start != null);
            var startClone = (StateImpl)start.Clone(); // we need a fresh clone in each iteration (k) of Dfs

            // TODO: the following code is duplicate. Need to refine it. 
            worklist.Push(new BacktrackingState(startClone));
            var startHash = startClone.GetHashCode();
            concretesInHash.Add(startHash);
            if (fileDump)
            {
                concretesFile.Write(startClone.ToPrettyString());
                concretesFile.WriteLine(Constants.consoleSeparator);
                transitionsFile.WriteLine(startHash);
            }

            if (queueAbstraction)
            {
                var startAbstract = (StateImpl)start.Clone();
                startAbstract.AbstractMe(); // abstract queue

                abstractsInHash.Add(startAbstract.GetHashCode());
                /// compute abstract succs right way
                startAbstract.CollectAbstractSuccessors(abstractSuccsInHash, abstractSuccsFile);
                if (fileDump)
                {
                    abstractsFile.Write(startAbstract.ToPrettyString());
                    abstractsFile.WriteLine(Constants.consoleSeparator);
                }
            }

            /// the main loop of DFS
            while (worklist.Count != 0) /// if worklist is not empty
            {

#if false // code for investigating memory usage
                if(stack.Count == 5000)
                {
                    Console.WriteLine("Stack depth of 5000 reached");
                    
                    GC.Collect();
                    var mem1 = GC.GetTotalMemory(true) / (1024.0 * 1024.0);
                    Console.WriteLine("Current memory usage = {0} MB", mem1.ToString("F2"));

                    // lets clone
                    var stackarr = stack.ToArray();
                    var newStack = new List<StateImpl>();
                    for(int i = 0; i < stackarr.Length; i++)
                    {
                        newStack.Add((StateImpl)stackarr[i].State.Clone());
                    }

                    GC.Collect();
                    var mem2 = GC.GetTotalMemory(true) / (1024.0 * 1024.0);

                    Console.WriteLine("Memory usage after cloning the stack = {0} MB", mem2.ToString("F2"));
                    Console.WriteLine("Average usage per state = {0} MB", (mem2 - mem1) / 5000.0);

                    Environment.Exit(0);
                }
#endif
                /// -PL: pop a state from worklist, and operate on it
                var curr = worklist.Pop();
                if (curr.CurrIndex >= curr.State.EnabledMachines.Count) // if "done" with curr
                {
                    continue;
                }

                /// Get a successor by executing the enabled machine pointed to by currIndex. 
                /// Also, advance currIndex and/or choiceIndex and push curr state back to worklist
                BacktrackingState succ = Execute(curr);
                worklist.Push(curr);

                // if we are in competitor finding mode
                if (StateImpl.mode == StateImpl.ExploreMode.find_comp)
                    CheckPredHash(curr.State, succ.State);

                if (!succ.State.CheckFailure(succ.depth))   // check for failure before adding new state: may fail due to failed assume, in which case we don't want to add
                {
                    // update concrete state hashset
                    var succHash = succ.State.GetHashCode();
                    if (!concretesInHash.Add(succHash)) // -- PL: if successor has been explored
                        continue;
                    worklist.Push(succ);
#if DEBUG
                    max_stack_size = Math.Max(max_stack_size, worklist.Count);
#endif

                    if (fileDump)
                    {
                        concretesFile.Write(succ.State.ToPrettyString()); // + " = " + succHash.ToPrettyString());
                        concretesFile.WriteLine(Constants.consoleSeparator);
                        transitionsFile.WriteLine("{0} -> {1}", curr.State.GetHashCode(), succHash);
                    }

                    if (queueAbstraction)
                    {
                        var succAbs = (StateImpl)succ.State.Clone();
                        succAbs.AbstractMe();
                        if (abstractsInHash.Add(succAbs.GetHashCode())) /// --PL: if the abstract of current state has NOT been explored
                        {
                            succAbs.CollectAbstractSuccessors(abstractSuccsInHash, abstractSuccsFile);
                            if (fileDump)
                            {
                                abstractsFile.Write(succAbs.ToPrettyString());
                                abstractsFile.WriteLine(Constants.consoleSeparator);
                            }
                        }
                    }

                    // status and diagnostics
                    if (concretesInHash.Count % 1000 == 0)
                    {
                        Console.WriteLine("-------------- Number of concrete states visited so far   = {0}", concretesInHash.Count);
                        if (queueAbstraction)
                        {
                            Console.WriteLine("-------------- Number of abstract states found so far     = {0}", abstractsInHash.Count);
                            Console.WriteLine("-------------- Number of abstract successors found so far = {0}{1}", abstractSuccsInHash.Count, StateImpl.invariants ? " (only those satisfying all static invariants)" : "");
                        }
#if DEBUG
                        Console.WriteLine("-------------- Maximum queue size encountered so far      = {0}", max_queue_size);
                        Console.WriteLine("-------------- Maximum stack size encountered so far      = {0}", max_stack_size);
#endif
                        Console.WriteLine();
                    }

#if DEBUG
                    // update maximum encountered queue size
                    foreach (PrtImplMachine m in succ.State.ImplMachines)
                        max_queue_size = Math.Max(max_queue_size, m.eventQueue.Size());
#endif
                }
            } // end of while loop

            Console.WriteLine("");

            Console.WriteLine("Number of concrete states visited     = {0}", concretesInHash.Count);
            if (queueAbstraction)
            {
                Console.WriteLine("Number of abstract states encountered = {0}", abstractsInHash.Count);
                Console.WriteLine("Number of abstract successors found   = {0}{1}", abstractSuccsInHash.Count, StateImpl.invariants ? " (only those satisfying all static invariants)" : "");
            }

#if DEBUG
            Console.WriteLine("Maximum queue size  encountered       = {0}", max_queue_size);
            Console.WriteLine("Maximum stack size  encountered       = {0}", max_stack_size);
#endif
            Console.WriteLine();

            if (fileDump)
            {
                /// flush streams before close them
                concretesFile.Flush();
                abstractsFile.Flush();
                abstractSuccsFile.Flush();
                transitionsFile.Flush();
                /// close streams
                concretesFile.Close();
                abstractsFile.Close();
                abstractSuccsFile.Close();
                transitionsFile.Close();
            }
        }

        /// <summary>
        /// For convergence detection:
        /// c -> cp
        /// |    |
        /// |    |
        /// a -> ap, bp = alpha(cp) (MUST: bp in A)
        /// 
        /// Dump cp to file if cp's abstract state is a competitor
        /// </summary>
        /// <param name="c"> a concrete state</param>
        /// <param name="cp">the successor of c, cp means c'</param>
        static void CheckPredHash(StateImpl c, StateImpl cp)
        {
            /// build the abstract state a of c
            var a = (StateImpl)c.Clone();
            a.AbstractMe();
            /// only perfom actions when a == predecessor?
            if (a.GetHashCode() == StateImpl.predHash)
            {
                var bp = (StateImpl)cp.Clone();
                bp.AbstractMe();

                var bp_hash = bp.GetHashCode();
                if (competitors.Add(bp_hash))
                {
                    var bp_SW = new StreamWriter("reached" + (competitors.Count - 1).ToString() + ".txt");
                    bp_SW.WriteLine(bp.ToPrettyString());
                    bp_SW.Close();
                }
            }
        }

        /// <summary>
        /// compute abstract successors, and return true ("converged") 
        /// iff all of them are already contained in abstractsInHash
        /// </summary>
        static bool HasAbstractConverged()
        {
            foreach (var hash in abstractSuccsInHash)
            {
                if (!abstractsInHash.Contains(hash))
                {
                    Console.WriteLine("did not converge.");
                    Console.WriteLine("Found a so-far unreached abstract successor state. Its hash code is {0}.", hash);
                    Console.WriteLine("Do you want to");
                    Console.WriteLine("(c)ontinue, by increasing the queue bound, ignoring the unreached successor, OR");
                    Console.WriteLine("(i)nvestigate; we will then locate the state with that succHash code.");
                    string answer;
                    do
                    {
                        Console.Write(" ? ");
                        answer = Console.ReadKey().Key.ToString().ToLower();
                        Console.WriteLine();
                    } while (answer != "c" && answer != "i");

                    if (answer == "c")
                        return false;

                    // for the re-run, queue abstraction type remains, k bound remains; file dumping is turned off
                    StateImpl.mode = StateImpl.ExploreMode.find_a_ap;
                    StateImpl.succHash = hash;
                    StateImpl.FileDump = false;
                    fileDump = false;
                    OSIterate();
                    Debug.Assert(false, "DfsExploration.HasAbstractConverged: internal error: can't get here");
                }
            }
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
        /// - runs the state machine pointed to by CurrIndex, in place, and 
        ///   returns the successor wrapped into a curr
        /// - assigns to argument a clone (!) of the old curr, and advances 
        ///   its choice vector and currIndex, as appropriate
        /// So curr points to new memory after calling Execute. The returned 
        /// successor is stored in old memory.
        /// </summary>
        /// <param name="curr"></param>
        /// <returns></returns>
        static BacktrackingState Execute(BacktrackingState curr)
        {
            /// create a copy of curr
            var origState = (StateImpl)curr.State.Clone();

            /// --PL Q: set as 0 every time is called?
            int choiceIndex = 0;
            /// curr.State.UserBooleanChoice is a pointer to a function with 
            /// signature f: {} -> Bool.
            /// The following assigns the code under 'delegate' to this function pointer.
            /// curr and choiceIndex are global variables. -- PL: Q: global variables?
            curr.State.UserBooleanChoice = delegate ()
                  {
                      if (choiceIndex < curr.ChoiceVector.Count)
                      {
                          return curr.ChoiceVector[choiceIndex++];
                      }

                      choiceIndex++;
                      curr.ChoiceVector.Add(false);
                      return false;
                  };
            /// --PL: Execute the machine with index = CurrIndex
            curr.State.EnabledMachines[curr.CurrIndex].PrtRunStateMachine();

            Debug.Assert(choiceIndex == curr.ChoiceVector.Count);

            /// flip last choice -- PL Q: What does this mean??

            /// remove all 1's from the right
            while (curr.ChoiceVector.Count > 0 && curr.ChoiceVector[curr.ChoiceVector.Count - 1])
            {
                curr.ChoiceVector.RemoveAt(curr.ChoiceVector.Count - 1);
            }

            if (curr.ChoiceVector.Count > 0)
            {
                curr.ChoiceVector[curr.ChoiceVector.Count - 1] = true;
            }

            /// --PL: create the successor
            var succ = new BacktrackingState(curr.State)
            {
                depth = curr.depth + 1
            };

            curr.State = origState; // a clone of curr.State
            if (curr.ChoiceVector.Count == 0)
            {
                curr.CurrIndex++; // first iterate through all choices. When exhausted, step to the next enabled machine
            }

            return succ;
        }
    } /// the end of class DfsExploration

    /// <summary>
    /// --PL: A wrapper for P program State. Q: Why not use inheritance? 
    /// </summary>
    class BacktrackingState
    {
        public StateImpl State;
        public int CurrIndex;            // index of the next machine to execute
                                         /// <summary>
                                         /// Enumerate all non-deterministic choices
                                         /// </summary>
        public List<bool> ChoiceVector;  // length = number of choices to be made; contents of list = current choice as bitvector
        public int depth;                // only used with depth bounding

        public BacktrackingState(StateImpl state)
        {
            this.State = state;
            CurrIndex = 0;
            ChoiceVector = new List<bool>();
            depth = 0;
        }

    }
}
