﻿using Plang.Compiler.TypeChecker.AST;
using Plang.Compiler.TypeChecker.AST.Declarations;
using Plang.Compiler.TypeChecker.AST.Statements;
using System;
using System.Collections.Generic;

namespace Plang.Compiler.TypeChecker
{
    public class ControlFlowChecker
    {
        private readonly ITranslationErrorHandler handler;

        private ControlFlowChecker(ITranslationErrorHandler handler)
        {
            this.handler = handler;
        }

        public static void AnalyzeMethods(ITranslationErrorHandler handler, IEnumerable<Function> allFunctions)
        {
            var checker = new ControlFlowChecker(handler);
            foreach (var function in allFunctions) checker.CheckFunction(function);
        }

        private void CheckFunction(Function function)
        {
            CheckStmt(function.Body);
        }

        private void CheckStmt(IPStmt stmt)
        {
            switch (stmt)
            {
                case BreakStmt breakStmt:
                    throw handler.BareLoopControlFlow("break", breakStmt.SourceLocation);
                case ContinueStmt continueStmt:
                    throw handler.BareLoopControlFlow("continue", continueStmt.SourceLocation);

                case CompoundStmt compoundStmt:
                    foreach (var subStmt in compoundStmt.Statements) CheckStmt(subStmt);
                    break;
                case IfStmt ifStmt:
                    CheckStmt(ifStmt.ThenBranch);
                    CheckStmt(ifStmt.ElseBranch);
                    break;

                // Any break or continue statements inside this while loop are necessarily safe
                case WhileStmt _:
                    break;

                // None of the following statement types can contain child statements, so we can safely skip them
                case AnnounceStmt _:
                case AssertStmt _:
                case AssignStmt _:
                case CtorStmt _:
                case FunCallStmt _:
                case GotoStmt _:
                case InsertStmt _:
                case MoveAssignStmt _:
                case NoStmt _:
                case PopStmt _:
                case PrintStmt _:
                case RaiseStmt _:
                case ReceiveStmt _:
                case RemoveStmt _:
                case ReturnStmt _:
                case SendStmt _:
                case SwapAssignStmt _:
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(stmt));
            }
        }
    }
}