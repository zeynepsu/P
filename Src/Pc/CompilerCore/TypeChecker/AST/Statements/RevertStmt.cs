using System.Collections.Generic;
using Antlr4.Runtime;

namespace Plang.Compiler.TypeChecker.AST.Statements
{
    public class RevertStmt : IPStmt
    {
        public RevertStmt(ParserRuleContext sourceLocation, string message, List<IPExpr> args)
        {
            SourceLocation = sourceLocation;
            Message = message;
            Args = args;
        }

        public string Message { get; }
        public List<IPExpr> Args { get; }

        public ParserRuleContext SourceLocation { get; }
    }
}
