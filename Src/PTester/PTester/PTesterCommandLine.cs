using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using P.Runtime;
using Microsoft.PSharp;
using Microsoft.PSharp.Utilities;

namespace P.Tester
{
    public enum TestResult
    {
        /// <summary>
        /// No errors were found within the specified limits of the search (if any).
        /// </summary>
        Success = 0,

        /// <summary>
        /// Invalid parameters passed
        /// </summary>
        InvalidParameters = 1,

        /// <summary>
        /// An assertion failure was encountered.
        /// </summary>
        AssertionFailure = 2,

        /// <summary>
        /// An execution was found in which all P machines are blocked and at least one liveness monitor
        /// is in a hot state.
        /// </summary>
        Deadlock = 3,

        /// <summary>
        /// A lasso violating a liveness monitor was discovered.
        /// </summary>
        AcceptingCyleFound = 4,

        /// <summary>
        /// An internal error was encountered, typically indicating a bug in the compiler or runtime.
        /// </summary>
        InternalError = 5,

        /// <summary>
        /// Search stack size exceeded the maximum size.
        /// </summary>
        StackOverFlowError = 6,

        /// <summary>
        /// The search was canceled.
        /// </summary>
        Canceled = 7,

        /// <summary>
        /// Timeout
        /// </summary>
        Timeout = 8,
    }

    public class CommandLineOptions
    {
        public string inputFileName;
        public bool printStats;
        public int timeout;
        public bool UsePSharp = false;
        public bool DfsExploration;
        public bool OS_Exploration;
        public ushort k; // queue bound
        public bool UseStateHashing;
        public bool isRefinement;
        public string LHSModel;
        public string RHSModel;
        public bool verbose;
        public int numberOfSchedules;
        public bool debugHashing;
        public CommandLineOptions()
        {
            inputFileName = null;
            printStats = false;
            timeout = 0;
            isRefinement = false;
            LHSModel = null;
            RHSModel = null;
            verbose = false;
            numberOfSchedules = 1000;
            debugHashing = false;
            DfsExploration = false;
            OS_Exploration = false;
            k = 0;
            UseStateHashing = false;
        }
    }

    public class PTesterCommandLine
    {
        public static CommandLineOptions ParseCommandLine(string[] args)
        {
            var options = new CommandLineOptions();
            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];

                if (arg[0] == '-' || arg[0] == '/')
                {
                    string option = arg.TrimStart('/', '-').ToLower();
                    string param = string.Empty;

                    int sepIndex = option.IndexOf(':');

                    if (sepIndex > 0)
                    {
                        param = option.Substring(sepIndex + 1);
                        option = option.Substring(0, sepIndex);
                    }
                    else if (sepIndex == 0)
                    {
                        PrintHelp(arg, "Malformed option");
                        return null;
                    }

                    switch (option)
                    {
                        case "?":
                        case "h":
                            {
                                PrintHelp(null, null);
                                Environment.Exit((int)TestResult.Success);
                                break;
                            }
                        case "stats":
                            options.printStats = true;
                            break;
                        case "v":
                        case "verbose":
                            options.verbose = true;
                            break;
                        case "ns":
                            if (param.Length != 0)
                            {
                                options.numberOfSchedules = int.Parse(param);
                            }
                            break;
                        case "timeout":
                            if (param.Length != 0)
                            {
                                options.timeout = int.Parse(param);
                            }
                            break;
                        case "psharp":
                            options.UsePSharp = true;
                            break;
                        case "dfs":
                            options.DfsExploration = true;
                            if (param.Length != 0)
                            {
                                options.k = ushort.Parse(param);
                            }
                            break;
                        case "OS":
                            options.OS_Exploration = true;
                            if (param.Length != 0)
                            {
                                options.k = ushort.Parse(param);
                            }
                            break;
                        case "hash":
                            options.UseStateHashing = true;
                            break;
                        case "debughash":
                            options.debugHashing = true;
                            break;
                        case "break":
                            System.Diagnostics.Debugger.Launch();
                            break;
                        case "lhs":
                            if (param.Length != 0)
                            {
                                options.LHSModel = param;
                                options.RHSModel = null;
                                options.isRefinement = true;
                            }
                            else
                            {
                                PrintHelp(arg, "missing file name");
                                return null;
                            }
                            break;
                        case "rhs":
                            if (param.Length != 0)
                            {
                                options.RHSModel = param;
                                options.LHSModel = null;
                                options.isRefinement = true;
                            }
                            else
                            {
                                PrintHelp(arg, "missing file name");
                                return null;
                            }
                            break;
                        default:
                            PrintHelp(arg, "Invalid option");
                            return null;
                    }
                }
                else
                {
                    if (options.inputFileName != null)
                    {
                        PrintHelp(arg, "Only one input file is allowed");
                        return null;
                    }

                    if (!File.Exists(arg))
                    {
                        PrintHelp(arg, "Cannot find input file");
                        return null;
                    }

                    options.inputFileName = arg;
                }
            }

            if (!options.isRefinement && options.inputFileName == null)
            {
                PrintHelp(null, "No input file specified");
                return null;
            }
            return options;
        }

        public static void PrintHelp(string arg, string errorMessage)
        {
            if (errorMessage != null)
            {
                if (arg != null)
                    PTesterUtil.PrintErrorMessage(String.Format("Error: \"{0}\" - {1}", arg, errorMessage));
                else
                    PTesterUtil.PrintErrorMessage(String.Format("Error: {0}", errorMessage));
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Options ::");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("-h                       Print the help message");
            Console.WriteLine("-v or -verbose           Print the execution trace during exploration");
            Console.WriteLine("-ns:<int>                Number of schedulers <int> to explore");
            Console.WriteLine("-lhs:<LHS Model Dll>     Load the pre-computed traces of RHS Model and perform trace containment");
            Console.WriteLine("-rhs:<RHS Model Dll>     Compute all possible trace of the RHS Model using sampling and dump it in a file on disk");
            Console.WriteLine("-dfs:k                   Perform DFS exploration  of the state space, with a queue bound of k (i.e. a machine's send disabled when its current buffer is size k");
            Console.WriteLine("-OS:k                    Perform OS exploration (based on DFS) of the state space, starting with a queue bound of k");
        }

        public static void Main(string[] args)
        {
            var options = ParseCommandLine(args);
            if (options == null)
            {
                Environment.Exit((int)TestResult.InvalidParameters);
            }

            if (options.UsePSharp && options.isRefinement)
            {
                Console.WriteLine("Error: Refinement checking isn't yet supported with /psharp flag");
                Environment.Exit((int)TestResult.InvalidParameters);
            }

            if (options.isRefinement)
            {
                var refinementCheck = new RefinementChecking(options);
                if (options.LHSModel == null)
                {
                    refinementCheck.RunCheckerRHS();
                }
                else
                {
                    refinementCheck.RunCheckerLHS();
                }
                return;
            }

            var asm = Assembly.LoadFrom(options.inputFileName);
            StateImpl s = (StateImpl)asm.CreateInstance("P.Program.Application",
                                                        false,
                                                        BindingFlags.CreateInstance,
                                                        null,
                                                        new object[] { true },
                                                        null,
                                                        new object[] { });

            //StateImpl s = new P.Program.Application(true);

            if (s == null)
                throw new ArgumentException("Invalid assembly");

            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            if (options.UsePSharp)
            {
                PSharpExploration.RunPSharpTester(s);
            }
            else if (options.DfsExploration)
            {
                DfsExploration.UseStateHashing = options.UseStateHashing;
                DfsExploration.start = (StateImpl)(s.Clone());
                DfsExploration.Explore(options.k); // single exploration with queue bound k
            }
            else if (options.OS_Exploration)
            {
                DfsExploration.UseStateHashing = options.UseStateHashing;
                DfsExploration.start = (StateImpl)(s.Clone());
                DfsExploration.OS_Explore(options.k); // OS exploration starting with queue bound k
            }
            else
            {
                RandomExploration.Explore(s, options);
            }
            Console.WriteLine("Time elapsed: {0} seconds", sw.Elapsed.TotalSeconds.ToString("F2"));
        }

    }


}
