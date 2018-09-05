using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Pc.Backend.ASTExt;
using Microsoft.Pc.TypeChecker;
using Microsoft.Pc.TypeChecker.AST;
using Microsoft.Pc.TypeChecker.AST.Declarations;
using Microsoft.Pc.TypeChecker.AST.Expressions;
using Microsoft.Pc.TypeChecker.AST.Statements;
using Microsoft.Pc.TypeChecker.AST.States;
using Microsoft.Pc.TypeChecker.Types;

namespace Microsoft.Pc.Backend.Solidity
{
    public class SolidityCodeGenerator : ICodeGenerator
    {
        public IEnumerable<CompiledFile> GenerateCode(ICompilationJob job, Scope globalScope)
        {
            var context = new CompilationContext(job);
            CompiledFile soliditySource = GenerateSource(context, globalScope);
            return new List<CompiledFile> { soliditySource };
        }
    
        private CompiledFile GenerateSource(CompilationContext context, Scope globalScope)
        {
            var source = new CompiledFile(context.FileName);

            WriteSourcePrologue(context, source.Stream);

            foreach (IPDecl decl in globalScope.AllDecls)
            {
                WriteDecl(context, source.Stream, decl);
            }

            // TODO: generate tuple type classes.

            // TODO:
            //WriteSourceEpilogue(context, source.Stream);
            
            return source;
        }

        private void WriteSourcePrologue(CompilationContext context, StringWriter output)
        {
            context.WriteLine(output, "pragma solidity ^0.4.24;");
        }

        
        private void WriteDecl(CompilationContext context, StringWriter output, IPDecl decl)
        {
            string declName = context.Names.GetNameForDecl(decl);
            switch (decl)
            {
                case Machine machine:
                    context.WriteLine(output, $"contract {declName}");
                    context.WriteLine(output, "{");
                    WriteMachine(context, output, machine);
                    context.WriteLine(output, "}");
                    break;
                default:
                    context.WriteLine(output, $"// TODO: {decl.GetType().Name} {declName}");
                    break;
            }
            
        }

        private void WriteMachine(CompilationContext context, StringWriter output, Machine machine)
        {
            #region variables and data structures
            foreach (Variable field in machine.Fields)
            {
                context.WriteLine(output, $"private {GetSolidityType(context, field.Type)} {context.Names.GetNameForDecl(field)};");
            }

            // Add the queue data structure
            AddInternalDataStructures(context, output);
            #endregion

            #region functions
            /*
            foreach (Function method in machine.Methods)
            {
                WriteFunction(context, output, method);
            }
            */

            // Add helper functions for the queue
            AddInboxEnqDeq(context, output);

            // Add the scheduler
            AddScheduler(context, output);
            #endregion

            foreach (State state in machine.States)
            {
                if (state.IsStart)
                {
                    context.WriteLine(output, "[Start]");
                }

                if (state.Entry != null)
                {
                    context.WriteLine(output, $"[OnEntry(nameof({context.Names.GetNameForDecl(state.Entry)}))]");
                }

                var deferredEvents = new List<string>();
                var ignoredEvents = new List<string>();
                foreach (var eventHandler in state.AllEventHandlers)
                {
                    PEvent pEvent = eventHandler.Key;
                    IStateAction stateAction = eventHandler.Value;
                    switch (stateAction)
                    {
                        case EventDefer _:
                            deferredEvents.Add($"typeof({context.Names.GetNameForDecl(pEvent)})");
                            break;
                        case EventDoAction eventDoAction:
                            context.WriteLine(
                                output,
                                $"[OnEventDoAction(typeof({context.Names.GetNameForDecl(pEvent)}), nameof({context.Names.GetNameForDecl(eventDoAction.Target)}))]");
                            break;
                        case EventGotoState eventGotoState when eventGotoState.TransitionFunction == null:
                            context.WriteLine(
                                output,
                                $"[OnEventGotoState(typeof({context.Names.GetNameForDecl(pEvent)}), typeof({context.Names.GetNameForDecl(eventGotoState.Target)}))]");
                            break;
                        case EventGotoState eventGotoState when eventGotoState.TransitionFunction != null:
                            context.WriteLine(
                                output,
                                $"[OnEventGotoState(typeof({context.Names.GetNameForDecl(pEvent)}), typeof({context.Names.GetNameForDecl(eventGotoState.Target)}), nameof({context.Names.GetNameForDecl(eventGotoState.TransitionFunction)}))]");
                            break;
                        case EventIgnore _:
                            ignoredEvents.Add($"typeof({context.Names.GetNameForDecl(pEvent)})");
                            break;
                        case EventPushState eventPushState:
                            context.WriteLine(
                                output,
                                $"[OnEventPushState(typeof({context.Names.GetNameForDecl(pEvent)}), typeof({context.Names.GetNameForDecl(eventPushState.Target)}))]");
                            break;
                    }
                }

                if (deferredEvents.Count > 0)
                {
                    context.WriteLine(output, $"[DeferEvents({string.Join(", ", deferredEvents.AsEnumerable())})]");
                }

                if (ignoredEvents.Count > 0)
                {
                    context.WriteLine(output, $"[IgnoreEvents({string.Join(", ", ignoredEvents.AsEnumerable())})]");
                }

                if (state.Exit != null)
                {
                    context.WriteLine(output, $"[OnExit(nameof({context.Names.GetNameForDecl(state.Exit)}))]");
                }

                context.WriteLine(output, $"class {context.Names.GetNameForDecl(state)} : MachineState");
                context.WriteLine(output, "{");
                context.WriteLine(output, "}");
            }
        }

        private string GetSolidityType(CompilationContext context, PLanguageType returnType)
        {
            switch (returnType.Canonicalize())
            {
                case BoundedType _:
                    return "Machine";
                case EnumType enumType:
                    return context.Names.GetNameForDecl(enumType.EnumDecl);
                case ForeignType _:
                    throw new NotImplementedException();
                case MapType mapType:
                    return $"Dictionary<{GetSolidityType(context, mapType.KeyType)}, {GetSolidityType(context, mapType.ValueType)}>";
                case NamedTupleType _:
                    throw new NotImplementedException();
                case PermissionType _:
                    return "Machine";
                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Any):
                    return "object";
                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Bool):
                    return "bool";
                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Int):
                    return "int";
                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Float):
                    return "double";
                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Event):
                    return "struct";
                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Machine):
                    return "address";
                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Null):
                    return "void";
                case SequenceType sequenceType:
                    return $"List<{GetSolidityType(context, sequenceType.ElementType)}>";
                case TupleType _:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException(nameof(returnType));
            }
        }

        #region helpers for queues

        private void AddInternalDataStructures(CompilationContext context, StringWriter output)
        {
            // TODO: Define the type of the value for the inbox
            context.WriteLine(output, $"struct Event");
            context.WriteLine(output, "{");
            context.WriteLine(output, $"string name;");
            context.WriteLine(output, "}");
            context.WriteLine(output, $"// Adding inbox for the contract");
            context.WriteLine(output, $"private mapping (uint => Event) inbox;");
            context.WriteLine(output, $"private uint first = 1;");
            context.WriteLine(output, $"private uint last = 0;");
            context.WriteLine(output, $"private bool IsRunning = false;");
            context.WriteLine(output, $"private string currentState;");
           
        }

        private void AddInboxEnqDeq(CompilationContext context, StringWriter output)
        {
            // Enqueue to inbox
            context.WriteLine(output, $"// Enqueue in the inbox");
            // TODO: fix the type of the inbox
            context.WriteLine(output, $"function enqueue (Event e) private");
            context.WriteLine(output, "{");
            context.WriteLine(output, $"last += 1;");
            context.WriteLine(output, $"inbox[last] = e");
            context.WriteLine(output, "}");

            // Dequeue from inbox
            context.WriteLine(output, $"// Dequeue from the inbox");
            // TODO: fix the type of the inbox
            context.WriteLine(output, $"function dequeue () private returns (Event e)");
            context.WriteLine(output, "{");
            context.WriteLine(output, $"data = inbox[first];");
            context.WriteLine(output, $"delete inbox[first];");
            context.WriteLine(output, $"first += 1;");
            context.WriteLine(output, "}");
        }

        #endregion

        #region scheduler
        private void AddScheduler(CompilationContext context, StringWriter output)
        {
            context.WriteLine(output, $"// Scheduler");
            // TODO: fix the type of the inbox
            context.WriteLine(output, $"function scheduler (Event e) public");
            context.WriteLine(output, "{");
            context.WriteLine(output, $"if(!IsRunning)");
            context.WriteLine(output, "{");
            context.WriteLine(output, $"if(e.name == \"eTransfer\")");
            context.WriteLine(output, "{");
            context.WriteLine(output, "Transfer();");    // TODO: Add payload for transfer
            context.WriteLine(output, "}");
            context.WriteLine(output, $"else");
            context.WriteLine(output, "{");
            context.WriteLine(output, $"m = LookupAction(currentState, e.name);");
            context.WriteLine(output, $"currentState = LookupNextState(currentState, e.name);");
            context.WriteLine(output, $"m();");
            context.WriteLine(output, "}");
            context.WriteLine(output, "IsRunning = true");
            context.WriteLine(output, "}");
            context.WriteLine(output, $"else");
            context.WriteLine(output, "{");
            context.WriteLine(output, $"enqueue(e)");
            context.WriteLine(output, "}");
            context.WriteLine(output, "}");
        }

        #endregion

    }


}
