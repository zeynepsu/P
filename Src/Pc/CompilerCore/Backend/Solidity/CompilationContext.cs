using System.Collections.Generic;
using Plang.Compiler.TypeChecker.AST.Declarations;
using Plang.Compiler.TypeChecker.Types;

namespace Plang.Compiler.Backend.Solidity
{
    internal class CompilationContext : CompilationContextBase
    {
        public SolidityNameManager Names { get; }

        public CompilationContext(ICompilationJob job)
            : base(job)
        {
            Names = new SolidityNameManager("SGEN_");

            FileName = $"{ProjectName}.sol";
            GlobalFunctionClassName = $"GlobalFunctions_{ProjectName}";
        }

        public string GetStaticMethodQualifiedName(Function function)
        {
            return $"{GlobalFunctionClassName}.{Names.GetNameForDecl(function)}";
        }

        public string GlobalFunctionClassName { get; }

        public string FileName { get; }

    }
}
