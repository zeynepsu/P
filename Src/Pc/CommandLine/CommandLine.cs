using System;
﻿using static Plang.Compiler.CommandLineParseResult;


namespace Plang.Compiler
{
    public static class CommandLine
    {
        public static int Main(string[] args)
        {
            switch (CommandLineOptions.ParseArguments(args, out var job))
            {
                case Failure:
                    CommandLineOptions.PrintUsage();
                    return 1;
                case HelpRequested:
                    CommandLineOptions.PrintUsage();
                    return 0;
                default:
                    try
                    {
                        ICompiler compiler = new Compiler();
                        compiler.Compile(job);

                        Console.WriteLine("Press any key to exit...");
                        Console.ReadLine();
                        return 0;
                    }
                    catch (TranslationException e)
                    {
                        job.Output.WriteMessage(e.Message, SeverityKind.Error);
                        return 1;
                    }
            }
        }
    }
}