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
        Dictionary<string, Dictionary<string, string>> NextStateMap;
        Dictionary<string, Dictionary<string, string>> ActionMap;

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
            NextStateMap = new Dictionary<string, Dictionary<string, string>>();
            ActionMap = new Dictionary<string, Dictionary<string, string>>();

            BuildNextStateMap(context, machine);
            BuildActionMap(context, machine);

            #region variables and data structures
            foreach (Variable field in machine.Fields)
            {
                context.WriteLine(output, $"private {GetSolidityType(context, field.Type)} {context.Names.GetNameForDecl(field)};");
            }

            // Add the queue data structure
            AddInternalDataStructures(context, output, machine);

            #endregion

            #region functions
            
            foreach (Function method in machine.Methods)
            {
                WriteFunction(context, output, method);
            }

            // Add basic fallback function
            AddTransferFunction(context, output);

            // Add helper functions for the queue
            AddInboxEnqDeq(context, output);

            // Add the scheduler
            AddScheduler(context, output, machine);
            #endregion

            foreach (State state in machine.States)
            {
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

        #region internal data structures

        private void AddInternalDataStructures(CompilationContext context, StringWriter output, Machine machine)
        {
            // TODO: Define the type of the value for the inbox
            context.WriteLine(output, $"struct Event");
            context.WriteLine(output, "{");
            context.WriteLine(output, $"string name;");
            context.WriteLine(output, "}");
            context.WriteLine(output, $"// Adding inbox for the contract");
            context.WriteLine(output, $"mapping (uint => Event) private inbox;");
            context.WriteLine(output, $"uint private first = 1;");
            context.WriteLine(output, $"uint private last = 0;");
            context.WriteLine(output, $"bool private IsRunning = false;");

            // Add all the states as an enumerated data type
            EnumerateStates(context, output, machine);

        }

        /// <summary>
        /// Add the states as an enumerated data type
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        private void EnumerateStates(CompilationContext context, StringWriter output, Machine machine)
        {
            string startState = "";

            context.WriteLine(output, $"enum private State");
            context.WriteLine(output, "{");

            foreach(State state in machine.States)
            {
                if(state.IsStart)
                {
                    startState = GetQualifiedStateName(state);
                }

                context.WriteLine(output, GetQualifiedStateName(state) + ",");
            }

            // Add a system defined error state
            context.WriteLine(output, "Sys_Error_State");
            context.WriteLine(output, "}");

            // Add a variable which tracks the current state of the contract
            context.WriteLine(output, $"State private ContractCurrentState = " + startState + ";");
        }

        #endregion

        #region queue helper functions
        private void AddInboxEnqDeq(CompilationContext context, StringWriter output)
        {
            // Enqueue to inbox
            context.WriteLine(output, $"// Enqueue in the inbox");
            // TODO: fix the type of the inbox
            context.WriteLine(output, $"function enqueue (Event e) private");
            context.WriteLine(output, "{");
            context.WriteLine(output, $"last += 1;");
            context.WriteLine(output, $"inbox[last] = e;");
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
        private void AddScheduler(CompilationContext context, StringWriter output, Machine machine)
        {
            context.WriteLine(output, $"// Schedulers");

            // Get all the events we have processed 
            HashSet<string> events = new HashSet<string>(NextStateMap.Keys);
            events.UnionWith(ActionMap.Keys);

            foreach (string ev in events)
            {
                Dictionary<string, string> stateChanges = null;
                Dictionary<string, string> actions = null;

                // Get the set og state changes associated with this event, if any
                if(NextStateMap.ContainsKey(ev))
                {
                    stateChanges = NextStateMap[ev];
                }
                // Get the action associated with each state, for this event
                if(ActionMap.ContainsKey(ev))
                {
                    actions = ActionMap[ev];
                }

                context.WriteLine(output, $"function scheduler (" + ev + " e)  public");
                context.WriteLine(output, "{");
                context.WriteLine(output, $"State memory prevContractState = ContractCurrentState");
                context.WriteLine(output, $"if(!IsRunning)");
                context.WriteLine(output, "{");
                context.WriteLine(output, $"IsRunning = true;");

                // Update contract state
                if(stateChanges != null)
                {
                    foreach(string prevState in stateChanges.Keys)
                    {
                        context.WriteLine(output, $"if(prevContractState == " + prevState + ")");
                        context.WriteLine(output, "{");
                        context.WriteLine(output, $"ContractCurrentState = " + stateChanges[prevState] + ";");
                        context.WriteLine(output, "}");
                    }
                }

                // Invoke the handler
                if (actions != null)
                {
                    foreach (string prevState in actions.Keys)
                    {
                        context.WriteLine(output, $"if(prevContractState == " + prevState + ")");
                        context.WriteLine(output, "{");
                        context.WriteLine(output, $"" + actions[prevState] + "(" + ev + ");");
                        context.WriteLine(output, "}");
                    }
                }
               
                // enqueue if the contract is busy
                context.WriteLine(output, "}");
                context.WriteLine(output, $"else");
                context.WriteLine(output, "{");
                context.WriteLine(output, $"enqueue(e);");
                context.WriteLine(output, "}");
                context.WriteLine(output, "}");
            }
        }

        #endregion

        #region WriteFunction

        private void WriteFunction(CompilationContext context, StringWriter output, Function function)
        {
            bool isStatic = function.Owner == null;
            FunctionSignature signature = function.Signature;

            string staticKeyword = isStatic ? "static " : "";
            string returnType = GetSolidityType(context, signature.ReturnType);
            string functionName = context.Names.GetNameForDecl(function);
            string functionParameters =
                string.Join(
                    ", ",
                    signature.Parameters.Select(param => $"{GetSolidityType(context, param.Type)} {context.Names.GetNameForDecl(param)}"));

            context.WriteLine(output, $"{staticKeyword}{returnType} private {functionName}({functionParameters})");
            // WriteFunctionBody(context, output, function);
        }

        #endregion

        #region misc helper functions

        /// <summary>
        /// Get the name of the state, in a Solidity-supported format
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private string GetQualifiedStateName(State state)
        {
            return state.QualifiedName.Replace(".", "_");
        }

        /// <summary>
        /// Adds the default handler for the eTransfer event, which accepts ether.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        private void AddTransferFunction(CompilationContext context, StringWriter output)
        {
            context.WriteLine(output, $"function Transfer () public payable");
            context.WriteLine(output, "{");
            context.WriteLine(output, "}");
        }

        /// <summary>
        /// Adds a function which can compare two strings in Solidity
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        private void AddStringComparator(CompilationContext context, StringWriter output)
        {
            context.WriteLine(output, $"function CompareStrings (string s1, string s2) view returns (bool)");
            context.WriteLine(output, "{");
            context.WriteLine(output, $"return keccak256(s1) == keccak256(s2);");
            context.WriteLine(output, "}");
        }

        /// <summary>
        /// Build the NextStateMap: Event -> (CurrentState -> NextState)
        /// </summary>
        /// <param name="machine"></param>
        private void BuildNextStateMap(CompilationContext context, Machine machine)
        {
            foreach(State state in machine.States)
            {
                foreach (var eventHandler in state.AllEventHandlers)
                {
                    PEvent pEvent = eventHandler.Key;
                    Dictionary<string, string> pEventStateChanges;

                    // Create an entry for pEvent, if we haven't encountered this before
                    if(! NextStateMap.Keys.Contains(pEvent.Name))
                    {
                        NextStateMap.Add(pEvent.Name, new Dictionary<string, string>());
                        pEventStateChanges = new Dictionary<string, string>();
                    }
                    else
                    {
                        pEventStateChanges = NextStateMap[pEvent.Name];
                    }

                    IStateAction stateAction = eventHandler.Value;

                    switch (stateAction)
                    {
                        case EventGotoState eventGotoState when eventGotoState.TransitionFunction != null:
                            pEventStateChanges.Add(GetQualifiedStateName(state), GetQualifiedStateName(eventGotoState.Target));
                            break;

                        case EventGotoState eventGotoState when eventGotoState.TransitionFunction == null:
                            pEventStateChanges.Add(GetQualifiedStateName(state), GetQualifiedStateName(eventGotoState.Target));
                            break;

                        case EventDoAction eventDoAction:
                            break;

                        default:
                            throw new Exception("BuildNextStateMap: Unsupported/Incorrect event handler specification");
                    }

                    NextStateMap[pEvent.Name] = pEventStateChanges;
                }
            }
        }

        /// <summary>
        /// Build the action lookup map: Event -> (CurrentState -> Action)
        /// </summary>
        /// <param name="machine"></param>
        private void BuildActionMap(CompilationContext context, Machine machine)
        {
            foreach (State state in machine.States)
            {
                foreach (var eventHandler in state.AllEventHandlers)
                {
                    PEvent pEvent = eventHandler.Key;
                    Dictionary<string, string> pEventActionForState;

                    // Create an entry for pEvent, if we haven't encountered this before
                    if (! ActionMap.Keys.Contains(pEvent.Name))
                    {
                        NextStateMap.Add(pEvent.Name, new Dictionary<string, string>());
                        pEventActionForState = new Dictionary<string, string>();
                    }
                    else
                    {
                        pEventActionForState = ActionMap[pEvent.Name];
                    }

                    IStateAction stateAction = eventHandler.Value;

                    switch (stateAction)
                    {
                        case EventGotoState eventGotoState when eventGotoState.TransitionFunction != null:
                            pEventActionForState.Add(GetQualifiedStateName(state), eventGotoState.TransitionFunction.Name);
                            break;

                        case EventGotoState eventGotoState when eventGotoState.TransitionFunction == null:
                            break;

                        case EventDoAction eventDoAction:
                            pEventActionForState.Add(GetQualifiedStateName(state), context.Names.GetNameForDecl(eventDoAction.Target));
                            break;

                        default:
                            throw new Exception("BuildActionMap: Unsupported/Incorrect event handler specification");
                    }

                    ActionMap[pEvent.Name] = pEventActionForState;
                }
            }
        }

        #endregion

    }
}
