using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Plang.Compiler.Backend.ASTExt;
using Plang.Compiler.TypeChecker;
using Plang.Compiler.TypeChecker.AST;
using Plang.Compiler.TypeChecker.AST.Declarations;
using Plang.Compiler.TypeChecker.AST.Expressions;
using Plang.Compiler.TypeChecker.AST.Statements;
using Plang.Compiler.TypeChecker.AST.States;
using Plang.Compiler.TypeChecker.Types;

namespace Plang.Compiler.Backend.Solidity
{
    public class SolidityCodeGenerator : ICodeGenerator
    {
        // Name of the library containing contract types and event types
        string LibraryName;

        // Name of the contract we are processing
        string ContractName;

        // Fully qualified name of the type of the event associated with the contract: <LibraryName>_Event
        string EventTypeName;

        // Globally unique type identifier
        int TypeId = 0;

        // Assign a unique id to each type
        Dictionary<string, int> TypeIdMap = new Dictionary<string, int>();

        // Map each event type id to the types it carries as payload
        Dictionary<int, Dictionary<string, string>> IdVarsMap = new Dictionary<int, Dictionary<string, string>>();


        Dictionary<int, Dictionary<string, string>> NextStateMap = new Dictionary<int, Dictionary<string, string>>();
        Dictionary<int, Dictionary<string, string>> ActionMap = new Dictionary<int, Dictionary<string, string>>();

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

            PopulateLibrary(context, source.Stream, globalScope);

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
            context.WriteLine(output, "pragma solidity 0.5.3;");
            context.WriteLine(output, "pragma experimental ABIEncoderV2;");
        }

        private void WriteDecl(CompilationContext context, StringWriter output, IPDecl decl)
        {
            string declName = context.Names.GetNameForDecl(decl);

            switch (decl)
            {
                case Machine machine:
                    // Write the rest of the machine
                    ContractName = machine.Name;
                    EventTypeName = LibraryName + ".Event";
                    context.WriteLine(output, $"contract {ContractName}");
                    context.WriteLine(output, "{");
                    WriteMachine(context, output, machine);
                    context.WriteLine(output, "}");
                    break;

                default:
                    // context.WriteLine(output, $"// TODO: {decl.GetType().Name} {declName}");
                    break;
            }

        }

        /// <summary>
        /// This function makes a pass through all the declarations to collect information about the event types.
        /// It stores the set of event types which each machine receives, assigns a unique type id to each event type, and stores the set of types 
        /// which each event carries as payload. 
        /// Finally, it creates a library with all the collected information.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="decl"></param>
        private void PopulateLibrary(CompilationContext context, StringWriter output, Scope globalScope)
        {
            LibraryName = "ContractLibrary";

            // For each event type, assign a unique type id and gather information about the payload types
            foreach (IPDecl decl in globalScope.AllDecls)
            {
                switch (decl)
                {
                    case PEvent pEvent when !pEvent.IsBuiltIn:
                        AddEventType(context, pEvent);
                        break;

                    default:
                        break;
                }
            }

            // Write the library
            context.WriteLine(output, $"// Adding library");
            context.WriteLine(output, $"library " + LibraryName);
            context.WriteLine(output, "{");

            // Write the consolidated event
            context.WriteLine(output, $"struct Event");
            context.WriteLine(output, "{");
            context.WriteLine(output, $"int256 TypeId;");
            // Add all the possible payloads
            foreach (var typeId in IdVarsMap.Keys)
            {
                Dictionary<string, string> varsForId = IdVarsMap[typeId];

                if (varsForId.Count > 0)
                {
                    foreach (string var in varsForId.Keys)
                    {
                        context.WriteLine(output, $"" + varsForId[var] + " " + var + ";");
                    }
                }
            }
            context.WriteLine(output, "}");

            context.WriteLine(output, "}");
        }

        /// <summary>
        /// For an event, record the payloads and their types.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="pEvent"></param>
        private void AddEventType(CompilationContext context, PEvent pEvent)
        {
            // Assign a new id to the event type
            int typeId = TypeId++;
            TypeIdMap.Add(pEvent.Name, typeId);

            Dictionary<string, string> varsForId = new Dictionary<string, string>();

            // If there is a new payload type, add it to known payload types
            if (!pEvent.PayloadType.IsSameTypeAs(PrimitiveType.Null))
            {
                if (!(pEvent.PayloadType is NamedTupleType))
                {
                    string payloadType = GetSolidityType(context, pEvent.PayloadType);

                    // TODO: Current only one payload per event seems to be supported
                    // create and associate variables with this type
                    varsForId.Add(pEvent.Name + "_v0", payloadType);
                }
                else if (pEvent.PayloadType is NamedTupleType)
                {
                    NamedTupleType namedTupleType = pEvent.PayloadType as NamedTupleType;
                    int i = 0;
                    foreach (var t in namedTupleType.Types)
                    {
                        varsForId.Add(pEvent.Name + "_v" + i, GetSolidityType(context, t));
                        i++;
                    }
                }
            }
            IdVarsMap.Add(typeId, varsForId);
        }

        private void WriteMachine(CompilationContext context, StringWriter output, Machine machine)
        {
            BuildNextStateMap(context, machine);
            BuildActionMap(context, machine);

            #region variables and data structures
            foreach (Variable field in machine.Fields)
            {
                context.WriteLine(output, $"{GetSolidityType(context, field.Type)} private {context.Names.GetNameForDecl(field)};");
            }

            // Add the queue data structure
            WriteInternalDataStructures(context, output, machine);

            #endregion

            #region functions

            foreach (Function method in machine.Methods)
            {
                WriteFunction(context, output, method);
            }

            // Add helper functions for the queue
            WriteInboxEnqDeq(context, output);
            WriteIsInboxEmpty(context, output);

            // Add the scheduler
            WriteScheduler(context, output, machine);


            // Write the default fallback function
            WriteFallbackFunction(context, output);
            #endregion
        }


        #region internal data structures

        /// <summary>
        /// Adds data structures to encode the P message passing (with run-to-completion) semantics in EVM.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <param name="machine"></param>
        private void WriteInternalDataStructures(CompilationContext context, StringWriter output, Machine machine)
        {
            context.WriteLine(output, $"// Adding inbox for the contract");
            context.WriteLine(output, $"mapping (uint => " + EventTypeName + ") private inbox;");
            context.WriteLine(output, $"uint private first = 1;");
            context.WriteLine(output, $"uint private last = 0;");
            context.WriteLine(output, $"bool private IsRunning = false;");
            context.WriteLine(output, $"event Printer(string s);");

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

            context.WriteLine(output, $"enum State");
            context.WriteLine(output, "{");

            string stateNames = "";
            foreach (State state in machine.States)
            {
                if (state.IsStart)
                {
                    startState = GetQualifiedStateName(state);
                }

                stateNames += GetQualifiedStateName(state) + ",";
            }

            // Add a system defined error state
            stateNames = stateNames.Remove(stateNames.Length - 1);
            context.WriteLine(output, stateNames);
            context.WriteLine(output, "}");

            // Add a variable which tracks the current state of the contract
            context.WriteLine(output, $"State private ContractCurrentState = State." + startState + ";");
        }

        #endregion

        #region queue helper functions
        private void WriteInboxEnqDeq(CompilationContext context, StringWriter output)
        {
            // Enqueue to inbox
            context.WriteLine(output, $"// Enqueue in the inbox");
            // TODO: fix the type of the inbox
            context.WriteLine(output, $"function enqueue (" + EventTypeName + " memory ev) private");
            context.WriteLine(output, "{");
            context.WriteLine(output, $"last += 1;");
            context.WriteLine(output, $"inbox[last] = ev;");
            context.WriteLine(output, "}");

            // Dequeue from inbox
            context.WriteLine(output, $"// Dequeue from the inbox");
            // TODO: fix the type of the inbox
            context.WriteLine(output, $"function dequeue () private returns (" + EventTypeName + " memory ev)");
            context.WriteLine(output, "{");
            context.WriteLine(output, "if(first <= last)");
            context.WriteLine(output, "{");
            context.WriteLine(output, $"ev = inbox[first];");
            context.WriteLine(output, $"delete inbox[first];");
            context.WriteLine(output, $"first += 1;");
            context.WriteLine(output, "}");
            context.WriteLine(output, "else");
            context.WriteLine(output, "{");
            context.WriteLine(output, "revert(\"Attempting to dequeue from an empty queue\");");
            context.WriteLine(output, "}");

            context.WriteLine(output, "}");
        }

        private void WriteIsInboxEmpty(CompilationContext context, StringWriter output)
        {
            context.WriteLine(output, "// Test to check if the inbox is empty");
            context.WriteLine(output, "function IsInboxEmpty () view private returns (bool) ");
            context.WriteLine(output, "{");
            context.WriteLine(output, "if(first > last)");
            context.WriteLine(output, "{");
            context.WriteLine(output, "return true;");
            context.WriteLine(output, "}");
            context.WriteLine(output, "else");
            context.WriteLine(output, "{");
            context.WriteLine(output, "return false;");
            context.WriteLine(output, "}");
            context.WriteLine(output, "}");
        }

        #endregion

        #region scheduler
        private void WriteScheduler(CompilationContext context, StringWriter output, Machine machine)
        {
            context.WriteLine(output, $"// Scheduler");
            context.WriteLine(output, $"function scheduler (" + EventTypeName + " memory ev)  public payable");
            context.WriteLine(output, "{");
            context.WriteLine(output, $"State prevContractState = ContractCurrentState;");
            context.WriteLine(output, $"if(!IsRunning)");
            context.WriteLine(output, "{");
            context.WriteLine(output, $"IsRunning = true;");

            for (int i = 0; i < TypeId; i++)
            {
                context.WriteLine(output, $"// Perform state change for type with id " + i);

                context.WriteLine(output, $"if(ev.TypeId == " + i + ")");
                context.WriteLine(output, "{");

                Dictionary<string, string> stateChanges = null;
                Dictionary<string, string> actions = null;

                // Get the set og state changes associated with this event, if any
                if (NextStateMap.ContainsKey(i))
                {
                    stateChanges = NextStateMap[i];
                }
                // Get the action associated with each state, for this event
                if (ActionMap.ContainsKey(i))
                {
                    actions = ActionMap[i];
                }

                // Update contract state
                if (stateChanges != null)
                {
                    foreach (string prevState in stateChanges.Keys)
                    {
                        context.WriteLine(output, $"if(prevContractState == State." + prevState + ")");
                        context.WriteLine(output, "{");
                        context.WriteLine(output, $"ContractCurrentState = State." + stateChanges[prevState] + ";");
                        context.WriteLine(output, "}");
                    }
                }

                context.WriteLine(output, $"// Invoke handler for state and type with id " + i);
                // Invoke the handler
                if (actions != null)
                {
                    foreach (string prevState in actions.Keys)
                    {
                        context.WriteLine(output, $"if(prevContractState == State." + prevState + ")");
                        context.WriteLine(output, "{");

                        Dictionary<string, string> varsForId = IdVarsMap[i];

                        if (varsForId.Count == 0)
                        {
                            context.WriteLine(output, $"" + actions[prevState] + "();");
                        }
                        else
                        {
                            string callString = actions[prevState] + "(";
                            foreach (string var in varsForId.Keys)
                            {
                                callString += "ev." + var + ",";
                            }
                            callString = callString.Remove(callString.Length - 1);
                            context.WriteLine(output, $"" + callString + ");");
                        }
                        context.WriteLine(output, "}");
                    }
                }
                context.WriteLine(output, "}");
            }
            // enqueue if the contract is busy
            context.WriteLine(output, "}");
            context.WriteLine(output, $"else");
            context.WriteLine(output, "{");
            context.WriteLine(output, $"enqueue(ev);");
            context.WriteLine(output, "}");
            context.WriteLine(output, "}");
        }

        private void WriteFallbackFunction(CompilationContext context, StringWriter output)
        {
            context.WriteLine(output, "function () external payable ");
            context.WriteLine(output, "{");
            context.WriteLine(output, "}");
        }

        #endregion




        #region WriteFunction

        /// <summary>
        /// Sets up and writes the function signature.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <param name="function"></param>
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

            context.WriteLine(output, $"function {functionName}({functionParameters}) private");
            WriteFunctionBody(context, output, function);
        }

        /// <summary>
        /// Writes the body of a function.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <param name="function"></param>
        private void WriteFunctionBody(CompilationContext context, StringWriter output, Function function)
        {
            context.WriteLine(output, "{");
            context.WriteLine(output, "bool callReturnValue;");     // stores the return value of each call statement
            context.WriteLine(output, "bytes memory data;");         // holds the encoded string for call
            context.WriteLine(output, EventTypeName + " memory ev;");   // holds the struct to pass as argument

            foreach (var bodyStatement in function.Body.Statements) WriteStmt(context, output, bodyStatement);

            // Reset IsRunning flag, and process next event from inbox, if there exists one
            context.WriteLine(output, "");
            context.WriteLine(output, "// handle next event if any");
            context.WriteLine(output, "IsRunning = false;");
            context.WriteLine(output, "if(!IsInboxEmpty())");
            context.WriteLine(output, "{");
            context.WriteLine(output, "ev = dequeue();");
            context.WriteLine(output, "scheduler(ev);");
            context.WriteLine(output, "}");

            context.WriteLine(output, "}");
        }

        #endregion

        #region WriteStmt

        private void WriteStmt(CompilationContext context, StringWriter output, IPStmt stmt)
        {
            switch (stmt)
            {
                case AnnounceStmt announceStmt:
                    break;
                case AssertStmt assertStmt:
                    break;
                case AssignStmt assignStmt:
                    // if a new temporary variable is being declared, correctly specify the type
                    if (assignStmt.Location is VariableAccessExpr)
                    {
                        if (((VariableAccessExpr)assignStmt.Location).Variable.Name.StartsWith("$"))
                        {
                            context.Write(output, ((VariableAccessExpr)assignStmt.Location).Variable.Type.OriginalRepresentation + " ");
                        }
                    }
                    WriteLValue(context, output, assignStmt.Location);
                    context.Write(output, " = ");
                    WriteExpr(context, output, assignStmt.Value);
                    context.WriteLine(output, ";");
                    break;
                case CompoundStmt compoundStmt:
                    context.WriteLine(output, "{");
                    foreach (IPStmt subStmt in compoundStmt.Statements)
                    {
                        WriteStmt(context, output, subStmt);
                    }

                    context.WriteLine(output, "}");
                    break;
                case CtorStmt ctorStmt:
                    break;
                case FunCallStmt funCallStmt:
                    break;
                case GotoStmt gotoStmt:
                    context.WriteLine(output, "");
                    context.WriteLine(output, "ContractCurrentState = State." + GetQualifiedStateName(gotoStmt.State) + ";");
                    break;
                case IfStmt ifStmt:
                    context.Write(output, "if (");
                    WriteExpr(context, output, ifStmt.Condition);
                    context.WriteLine(output, ")");
                    WriteStmt(context, output, ifStmt.ThenBranch);
                    if (ifStmt.ElseBranch != null)
                    {
                        context.WriteLine(output, "else");
                        WriteStmt(context, output, ifStmt.ElseBranch);
                    }
                    break;
                case InsertStmt insertStmt:
                    break;
                case MoveAssignStmt moveAssignStmt:
                    WriteLValue(context, output, moveAssignStmt.ToLocation);
                    context.WriteLine(output, $" = {context.Names.GetNameForDecl(moveAssignStmt.FromVariable)};");
                    break;
                case NoStmt _:
                    break;
                case PopStmt popStmt:
                    break;
                case PrintStmt printStmt:
                    context.WriteLine(output, "emit Printer(\"" + printStmt.Message + "\");");
                    break;
                case RaiseStmt raiseStmt:
                    break;
                case ReceiveStmt receiveStmt:
                    break;
                case RemoveStmt removeStmt:
                    break;
                case ReturnStmt returnStmt:
                    context.Write(output, "return ");
                    WriteExpr(context, output, returnStmt.ReturnValue);
                    context.WriteLine(output, ";");
                    break;
                case RevertStmt revertStmt:
                    context.WriteLine(output, "revert(\"" + revertStmt.Message + "\");");
                    break;
                case SendStmt sendStmt:
                    WriteSendStmt(context, output, sendStmt);
                    break;
                case SwapAssignStmt swapAssignStmt:
                    break;
                case WhileStmt whileStmt:
                    context.Write(output, "while (");
                    WriteExpr(context, output, whileStmt.Condition);
                    context.WriteLine(output, ")");
                    WriteStmt(context, output, whileStmt.Body);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(stmt));
            }
        }

        /// <summary>
        /// Send translates to a call invocation in Solidity.
        /// Create an event which the receiving contract can parse.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <param name="sendStmt"></param>
        private void WriteSendStmt(CompilationContext context, StringWriter output, SendStmt sendStmt)
        {
            try
            {
                EventRefExpr eventRefExpr = sendStmt.Evt as EventRefExpr;
                string eventName = context.Names.GetNameForDecl(eventRefExpr.Value);
                // store the arguments
                IReadOnlyList<IPExpr> argsList = sendStmt.Arguments;

                // Setup the event to be dispatched
                if (!eventName.Contains("payable_eTransfer"))
                {
                    int tid = TypeIdMap[eventName];
                    context.WriteLine(output, "ev.TypeId = " + tid + ";");

                    int argIndex = 0;
                    foreach (var varName in IdVarsMap[tid])
                    {
                        context.Write(output, "ev." + varName.Key + " = ");
                        WriteExpr(context, output, argsList[argIndex]);
                        context.Write(output, ";");
                        context.WriteLine(output, "");
                        argIndex++;
                    }

                    string callEncodedString = "\"scheduler((";
                    callEncodedString += "int256,";
                    foreach (var typeId in IdVarsMap.Keys)
                    {
                        Dictionary<string, string> varsForId = IdVarsMap[typeId];

                        if (varsForId.Count > 0)
                        {
                            foreach (string var in varsForId.Keys)
                            {
                                callEncodedString += varsForId[var] + ",";
                            }
                        }
                    }
                    callEncodedString = callEncodedString.Remove(callEncodedString.Length - 1);
                    callEncodedString += "))\"";

                    context.WriteLine(output, "data = abi.encodeWithSignature(" + callEncodedString + " , ev);");

                }

                // Write the call statement
                context.Write(output, "(callReturnValue, ) = ");
                WriteExpr(context, output, sendStmt.MachineExpr);
                context.Write(output, ".call");
                // for a payable event, send the amount of ether
                if (eventName.Contains("payable_") && !eventName.Contains("payable_eTransfer"))
                {
                    VariableAccessExpr vExpr = (argsList[0] as VariableAccessExpr);
                    context.Write(output, ".value(uint256(" + context.Names.GetNameForDecl(vExpr.Variable) + "))");
                }
                if (eventName.Contains("payable_eTransfer"))
                {
                    VariableAccessExpr vExpr = (argsList[0] as VariableAccessExpr);
                    context.Write(output, ".value(uint256(" + context.Names.GetNameForDecl(vExpr.Variable) + "))(\"\");");
                }

                // add the data payload (only if event is not a eTransfer
                if(!eventName.Contains("payable_eTransfer"))
                {
                    context.Write(output, "(");

                    context.Write(output, " data );");
                    context.WriteLine(output, "");
                }

                context.WriteLine(output, "if ( callReturnValue == false )");
                context.WriteLine(output, "{");
                context.WriteLine(output, "revert(\"Call failed. Reverting transaction\");");
                context.WriteLine(output, "}");
            }
            catch (Exception e)
            {

                EventRefExpr eventRefExpr = sendStmt.Evt as EventRefExpr;
                string eventName = context.Names.GetNameForDecl(eventRefExpr.Value);
                Console.WriteLine("<ExceptionLog> Processing event: " + eventName);
            }
        }

        private void WriteLValue(CompilationContext context, StringWriter output, IPExpr lvalue)
        {
            switch (lvalue)
            {
                case MapAccessExpr mapAccessExpr:
                    //context.Write(output, "(");
                    WriteLValue(context, output, mapAccessExpr.MapExpr);
                    // context.Write(output, ")[");
                    context.Write(output, "[");
                    WriteExpr(context, output, mapAccessExpr.IndexExpr);
                    context.Write(output, "]");
                    break;
                case NamedTupleAccessExpr namedTupleAccessExpr:
                    context.Write(output, "struct {");
                    WriteExpr(context, output, namedTupleAccessExpr.SubExpr);
                    context.Write(output, $")[\"{namedTupleAccessExpr.FieldName}\"]");
                    break;
                case SeqAccessExpr seqAccessExpr:
                    context.Write(output, "(");
                    WriteLValue(context, output, seqAccessExpr.SeqExpr);
                    context.Write(output, ")[");
                    WriteExpr(context, output, seqAccessExpr.IndexExpr);
                    context.Write(output, "]");
                    break;
                case TupleAccessExpr tupleAccessExpr:
                    throw new NotImplementedException();
                case VariableAccessExpr variableAccessExpr:
                    context.Write(output, context.Names.GetNameForDecl(variableAccessExpr.Variable));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(lvalue));
            }
        }

        private void WriteExpr(CompilationContext context, StringWriter output, IPExpr pExpr)
        {
            switch (pExpr)
            {
                case CloneExpr cloneExpr:
                    WriteClone(context, output, cloneExpr.Term);
                    break;
                case BinOpExpr binOpExpr:
                    context.Write(output, "(");
                    WriteExpr(context, output, binOpExpr.Lhs);
                    context.Write(output, $") {BinOpToStr(binOpExpr.Operation)} (");
                    WriteExpr(context, output, binOpExpr.Rhs);
                    context.Write(output, ")");
                    break;
                case BoolLiteralExpr boolLiteralExpr:
                    context.Write(output, boolLiteralExpr.Value ? "true" : "false");
                    break;
                case CastExpr castExpr:
                    throw new NotImplementedException();
                case CoerceExpr coerceExpr:
                    throw new NotImplementedException();
                case ContainsKeyExpr containsKeyExpr:
                    context.Write(output, "(");
                    WriteExpr(context, output, containsKeyExpr.Map);
                    context.Write(output, ").ContainsKey(");
                    WriteExpr(context, output, containsKeyExpr.Key);
                    context.Write(output, ")");
                    break;
                case CtorExpr ctorExpr:
                    context.Write(output, $"address(new " + context.Names.GetNameForDecl(ctorExpr.Interface) + "())");
                    break;
                case DefaultExpr defaultExpr:
                    context.Write(output, GetDefaultValue(context, defaultExpr.Type));
                    break;
                case EnumElemRefExpr enumElemRefExpr:
                    EnumElem enumElem = enumElemRefExpr.Value;
                    context.Write(output, $"{context.Names.GetNameForDecl(enumElem.ParentEnum)}.{context.Names.GetNameForDecl(enumElem)}");
                    break;
                case EventRefExpr eventRefExpr:
                    context.Write(output, $"{context.Names.GetNameForDecl(eventRefExpr.Value)}");
                    break;
                case FairNondetExpr _:
                    context.Write(output, "this.FairRandom()");
                    break;
                case FloatLiteralExpr floatLiteralExpr:
                    context.Write(output, $"{floatLiteralExpr.Value}");
                    break;
                case FunCallExpr funCallExpr:
                    break;
                case IntLiteralExpr intLiteralExpr:
                    context.Write(output, $"{intLiteralExpr.Value}");
                    break;
                case KeysExpr keysExpr:
                    context.Write(output, "(");
                    WriteExpr(context, output, keysExpr.Expr);
                    context.Write(output, ").Keys.ToList()");
                    break;
                case LinearAccessRefExpr linearAccessRefExpr:
                    string swapKeyword = linearAccessRefExpr.LinearType.Equals(LinearType.Swap) ? "ref " : "";
                    context.Write(output, $"{swapKeyword}{context.Names.GetNameForDecl(linearAccessRefExpr.Variable)}");
                    break;
                case NamedTupleExpr namedTupleExpr:
                    throw new NotImplementedException();
                case NondetExpr _:
                    context.Write(output, "this.Random()");
                    break;
                case NullLiteralExpr _:
                    context.Write(output, "null");
                    break;
                case SizeofExpr sizeofExpr:
                    context.Write(output, "(");
                    WriteExpr(context, output, sizeofExpr.Expr);
                    context.Write(output, ").Count");
                    break;
                case ThisRefExpr _:
                    context.Write(output, "address(this)");
                    break;
                case UnaryOpExpr unaryOpExpr:
                    context.Write(output, $"{UnOpToStr(unaryOpExpr.Operation)}(");
                    WriteExpr(context, output, unaryOpExpr.SubExpr);
                    context.Write(output, ")");
                    break;
                case UnnamedTupleExpr unnamedTupleExpr:
                    throw new NotImplementedException();
                case ValuesExpr valuesExpr:
                    context.Write(output, "(");
                    WriteExpr(context, output, valuesExpr.Expr);
                    context.Write(output, ").Values.ToList()");
                    break;
                case MapAccessExpr _:
                case NamedTupleAccessExpr _:
                case SeqAccessExpr _:
                case TupleAccessExpr _:
                case VariableAccessExpr _:
                    WriteLValue(context, output, pExpr);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pExpr));
            }
        }

        private void WriteClone(CompilationContext context, StringWriter output, IExprTerm cloneExprTerm)
        {
            if (!(cloneExprTerm is IVariableRef variableRef))
            {
                WriteExpr(context, output, cloneExprTerm);
                return;
            }

            var variable = variableRef.Variable;
            context.Write(output, RenderClone(context, variable.Type, context.Names.GetNameForDecl(variable)));
        }

        private string RenderClone(CompilationContext context, PLanguageType cloneType, string termName)
        {
            switch (cloneType.Canonicalize())
            {
                case SequenceType seq:
                    var elem = context.Names.GetTemporaryName("elem");
                    return $"({termName}).ConvertAll({elem} => {RenderClone(context, seq.ElementType, elem)})";
                case MapType map:
                    var key = context.Names.GetTemporaryName("k");
                    var val = context.Names.GetTemporaryName("v");
                    return $"({termName}).ToDictionary({key} => {RenderClone(context, map.KeyType, key + ".Key")}, {val} => {RenderClone(context, map.ValueType, val + ".Value")})";
                case PrimitiveType type when type.IsSameTypeAs(PrimitiveType.Int):
                    return termName;
                case PrimitiveType type when type.IsSameTypeAs(PrimitiveType.Float):
                    return termName;
                case PrimitiveType type when type.IsSameTypeAs(PrimitiveType.Bool):
                    return termName;
                case PrimitiveType type when type.IsSameTypeAs(PrimitiveType.Machine):
                    return termName;
                case PrimitiveType type when type.IsSameTypeAs(PrimitiveType.Event):
                    return GetDefaultValue(context, type);
                default:
                    throw new NotImplementedException($"Cloning {cloneType.OriginalRepresentation}");
            }
        }

        private string GetDefaultValue(CompilationContext context, PLanguageType returnType)
        {
            switch (returnType.Canonicalize())
            {
                case EnumType enumType:
                    return $"({context.Names.GetNameForDecl(enumType.EnumDecl)})(0)";
                case MapType mapType:
                    return $"new {GetSolidityType(context, mapType)}()";
                case SequenceType sequenceType:
                    return $"new <{GetSolidityType(context, sequenceType)}>()";
                case NamedTupleType _:
                    throw new NotImplementedException();
                case TupleType _:
                    throw new NotImplementedException();
                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Bool):
                    return "false";
                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Int):
                    return "0";
                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Float):
                    return "0.0";
                case PermissionType _:
                case PrimitiveType anyType when anyType.IsSameTypeAs(PrimitiveType.Any):
                case PrimitiveType eventType when eventType.IsSameTypeAs(PrimitiveType.Event):
                case PrimitiveType machineType when machineType.IsSameTypeAs(PrimitiveType.Machine):
                case ForeignType _:

                default:
                    throw new ArgumentOutOfRangeException(nameof(returnType));
            }
        }

        private static string UnOpToStr(UnaryOpType operation)
        {
            switch (operation)
            {
                case UnaryOpType.Negate:
                    return "-";
                case UnaryOpType.Not:
                    return "!";
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }

        private static string BinOpToStr(BinOpType binOpType)
        {
            switch (binOpType)
            {
                case BinOpType.Add:
                    return "+";
                case BinOpType.Sub:
                    return "-";
                case BinOpType.Mul:
                    return "*";
                case BinOpType.Div:
                    return "/";
                case BinOpType.Eq:
                    return "==";
                case BinOpType.Neq:
                    return "!=";
                case BinOpType.Lt:
                    return "<";
                case BinOpType.Le:
                    return "<=";
                case BinOpType.Gt:
                    return ">";
                case BinOpType.Ge:
                    return ">=";
                case BinOpType.And:
                    return "&&";
                case BinOpType.Or:
                    return "||";
                default:
                    throw new ArgumentOutOfRangeException(nameof(binOpType), binOpType, null);
            }
        }

        #endregion

        #region misc helper functions

        private string GetSolidityType(CompilationContext context, PLanguageType returnType)
        {
            switch (returnType.Canonicalize())
            {
                case EnumType enumType:
                    return context.Names.GetNameForDecl(enumType.EnumDecl);
                case ForeignType _:
                    throw new NotImplementedException();
                case MapType mapType:
                    return $"mapping ({GetSolidityType(context, mapType.KeyType)} => {GetSolidityType(context, mapType.ValueType)})";
                case NamedTupleType namedTupleType:
                    // throw new NotImplementedException();
                    return namedTupleType.CanonicalRepresentation;
                case PermissionType _:
                    return "Machine";
                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Any):
                    return "object";
                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Bool):
                    return "bool";
                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Int):
                    return "int256";
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
                case TupleType tupleType:
                    // throw new NotImplementedException();
                    return tupleType.CanonicalRepresentation;
                default:
                    throw new ArgumentOutOfRangeException(nameof(returnType));
            }
        }

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
            NextStateMap = new Dictionary<int, Dictionary<string, string>>();

            foreach (State state in machine.States)
            {
                foreach (var eventHandler in state.AllEventHandlers)
                {
                    PEvent pEvent = eventHandler.Key;
                    Dictionary<string, string> pEventStateChanges;

                    int typeId = TypeIdMap[pEvent.Name];

                    // Create an entry for pEvent, if we haven't encountered this before
                    if (!NextStateMap.Keys.Contains(typeId))
                    {
                        NextStateMap.Add(typeId, new Dictionary<string, string>());
                        pEventStateChanges = new Dictionary<string, string>();
                    }
                    else
                    {
                        pEventStateChanges = NextStateMap[typeId];
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

                    NextStateMap[typeId] = pEventStateChanges;
                }
            }
        }

        /// <summary>
        /// Build the action lookup map: Event -> (CurrentState -> Action)
        /// </summary>
        /// <param name="machine"></param>
        private void BuildActionMap(CompilationContext context, Machine machine)
        {
            ActionMap = new Dictionary<int, Dictionary<string, string>>();

            foreach (State state in machine.States)
            {
                foreach (var eventHandler in state.AllEventHandlers)
                {
                    PEvent pEvent = eventHandler.Key;
                    Dictionary<string, string> pEventActionForState;

                    int typeId = TypeIdMap[pEvent.Name];

                    // Create an entry for pEvent, if we haven't encountered this before
                    if (!ActionMap.Keys.Contains(typeId))
                    {
                        ActionMap.Add(typeId, new Dictionary<string, string>());
                        pEventActionForState = new Dictionary<string, string>();
                    }
                    else
                    {
                        pEventActionForState = ActionMap[typeId];
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

                    ActionMap[typeId] = pEventActionForState;
                }
            }
        }

        #endregion

    }
}
