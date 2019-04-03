using Antlr4.Runtime;

namespace Plang.Compiler.TypeChecker.AST.Statements
{
    class DeleteStmt : IPStmt
    {
        public DeleteStmt(ParserRuleContext sourceLocation, IPExpr array, IPExpr index)
        {
            SourceLocation = sourceLocation;
            Array = array;
            Index = index;
        }

        public ParserRuleContext SourceLocation { get; }
        public IPExpr Array { get; }
        public IPExpr Index { get; }
    }
}
