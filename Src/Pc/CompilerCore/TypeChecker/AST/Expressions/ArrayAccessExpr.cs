using Antlr4.Runtime;
using Plang.Compiler.TypeChecker.Types;

namespace Plang.Compiler.TypeChecker.AST.Expressions
{
    public class ArrayAccessExpr : IPExpr
    {
        public ArrayAccessExpr(ParserRuleContext sourceLocation, IPExpr arrayExpr, IPExpr indexExpr, PLanguageType type)
        {
            SourceLocation = sourceLocation;
            ArrayExpr = arrayExpr;
            IndexExpr = indexExpr;
            Type = type;
        }

        public IPExpr ArrayExpr { get; }
        public IPExpr IndexExpr { get; }

        public ParserRuleContext SourceLocation { get; }

        public PLanguageType Type { get; }
    }
}