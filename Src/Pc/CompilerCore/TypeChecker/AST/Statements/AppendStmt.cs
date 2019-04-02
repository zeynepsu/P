using Antlr4.Runtime;
using Plang.Compiler.TypeChecker.AST.Declarations;

namespace Plang.Compiler.TypeChecker.AST.Statements
{
    class AppendStmt : IPStmt
    {
        public AppendStmt(ParserRuleContext sourceLocation, Variable array, IPExpr value)
        {
            SourceLocation = sourceLocation;
            Array = array;
            Value = value;
        }

        public ParserRuleContext SourceLocation { get; }
        public Variable Array { get; }
        public IPExpr Value { get; }
    }
}
