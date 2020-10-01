using Plang.Compiler.Backend.ASTExt;
using Plang.Compiler.TypeChecker;
using Plang.Compiler.TypeChecker.AST;
using Plang.Compiler.TypeChecker.AST.Declarations;
using Plang.Compiler.TypeChecker.AST.Expressions;
using Plang.Compiler.TypeChecker.AST.Statements;
using Plang.Compiler.TypeChecker.AST.States;
using Plang.Compiler.TypeChecker.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Plang.Compiler.PParser;

namespace Plang.Compiler.Backend.Uclid
{
    public class UclidCodeGenerator : ICodeGenerator
    {
        public IEnumerable<CompiledFile> GenerateCode(ICompilationJob job, Scope globalScope)
        {
            return UclidCodeGeneratorImpl.GenerateCode(job, globalScope);
        }
    }

    internal class UclidCodeGeneratorImpl
    {
        private readonly CompilationContext context;

        private UclidCodeGeneratorImpl(CompilationContext context)
        {
            this.context = context;
        }

        public static IEnumerable<CompiledFile> GenerateCode(ICompilationJob job, Scope globalScope)
        {
            CompilationContext context = new CompilationContext(job);
            UclidCodeGeneratorImpl generator = new UclidCodeGeneratorImpl(context);
            CompiledFile cSource = generator.GenerateSourceFile(globalScope);
            return new List<CompiledFile> { cSource };
        }

        private CompiledFile GenerateSourceFile(Scope globalScope)
        {
            CompiledFile cSource = new CompiledFile(context.SourceFileName);

            // declare machine and event types
            StringWriter commonWriter = new StringWriter();
            WriteCommon(commonWriter, globalScope);
            cSource.Stream.GetStringBuilder().Append(commonWriter);

            // declare each machine as a module
            StringWriter machineWriter = new StringWriter();
            WriteMachines(machineWriter, globalScope.Machines);
            cSource.Stream.GetStringBuilder().Append(machineWriter);

            // declare driver module
            StringWriter mainWriter = new StringWriter();
            WriteMain(mainWriter, globalScope);
            cSource.Stream.GetStringBuilder().Append(mainWriter);

            return cSource;
        }

        private void WriteCommon(TextWriter output, Scope globalScope) 
        {
            context.WriteLine(output, "module common {\n");
            context.WriteLine(output, "type string = integer; // needed for P asserts, but never really used\n");
            context.WriteLine(output, "// Declare machine reference types");
            foreach (var m in globalScope.Machines)
            {
                context.WriteLine(output, $"type {m.Name}_ref_t;");
            }
            context.WriteLine(output);
            context.WriteLine(output, "// Declare event types");
            foreach (var e in globalScope.Events)
            {
                if (!Equals(e.PayloadType, PrimitiveType.Null)) {
                    context.WriteLine(output, $"type {e.Name}_t = {context.Names.GetNameForType(e.PayloadType)};");
                    // context.Names.SetNameForType(e.PayloadType, $"{e.Name}_t");
                }
            }
            context.WriteLine(output);
            context.WriteLine(output, "} // End of common module\n");
        }

        private void WriteMain(TextWriter output, Scope globalScope) 
        {
            context.WriteLine(output, "module main {");
            context.WriteLine(output, "type * = common.*;");
            context.WriteLine(output, "// Declare instances and event bags");
            foreach (var m in globalScope.Machines)
            {
                List<string> args = new List<string>();
                foreach (var r in m.Receives.Events)
                {
                    if (!Equals(r.PayloadType, PrimitiveType.Null)) {
                        context.WriteLine(output, $"var {m.Name}_{r.Name}_in : [{m.Name}_ref_t][{r.Name}_t]integer;");
                    } else {
                        context.WriteLine(output, $"var {m.Name}_{r.Name}_in : [{m.Name}_ref_t]integer;");
                    }
                    args.Add($"{r.Name}_in : ({m.Name}_{r.Name}_in)");
                }
                foreach (var s in m.Sends.Events)
                {
                    foreach (var other in globalScope.Machines)
                    {
                        if (other.Receives.Contains(s)) {
                            if (!Equals(s.PayloadType, PrimitiveType.Null)) {
                                context.WriteLine(output, $"var {m.Name}_{s.Name}_to_{other.Name} : [{m.Name}_ref_t][{other.Name}_ref_t][{s.Name}_t]integer;");
                            } else {
                                context.WriteLine(output, $"var {m.Name}_{s.Name}_to_{other.Name} : [{m.Name}_ref_t][{other.Name}_ref_t]integer;");
                            }
                            args.Add($"{s.Name}_to_{other.Name} : ({m.Name}_{s.Name}_to_{other.Name})");
                        }
                    }
                }
                string bindings = string.Join(", ", args);
                context.WriteLine(output, $"instances {m.Name}_instances : [{m.Name}_ref_t]{m.Name}({bindings});");
                context.WriteLine(output);
            }

            context.WriteLine(output, "init {");
            foreach (var m in globalScope.Machines)
            {
                context.WriteLine(output, $"assume(forall (m : {m.Name}_ref_t) :: {m.Name}_instances[m].this == m);");
                foreach (var r in m.Receives.Events)
                {
                    if (!Equals(r.PayloadType, PrimitiveType.Null)) {
                        context.WriteLine(output, $"{m.Name}_{r.Name}_in = const(const(0, [{r.Name}_t]integer), [{m.Name}_ref_t][{r.Name}_t]integer);");
                    } else {
                        context.WriteLine(output, $"{m.Name}_{r.Name}_in = const(0, [{m.Name}_ref_t]integer);");
                    }
                }
                foreach (var s in m.Sends.Events)
                {
                    foreach (var other in globalScope.Machines)
                    {
                        if (other.Receives.Contains(s)) {
                            if (!Equals(s.PayloadType, PrimitiveType.Null)) {
                                context.WriteLine(output, $"{m.Name}_{s.Name}_to_{other.Name} = const(const(const(0, [{s.Name}_t]integer), [{other.Name}_ref_t][{s.Name}_t]integer), [{m.Name}_ref_t][{other.Name}_ref_t][{s.Name}_t]integer);");
                            } else {
                                context.WriteLine(output, $"{m.Name}_{s.Name}_to_{other.Name} = const(const(0, [{other.Name}_ref_t]integer), [{m.Name}_ref_t][{other.Name}_ref_t]integer);");
                            }
                        }
                    }
                }
            }
            context.WriteLine(output, "} // end init\n");

            context.WriteLine(output, "next {");
            foreach (var m in globalScope.Machines)
            {
                context.WriteLine(output, $"var {m.Name}_choice : {m.Name}_ref_t;");
            }

            // mediate communcation
            context.WriteLine(output, "if (*) {");
            int messages = 0;
            foreach (var m in globalScope.Machines)
            {
                foreach (var s in m.Sends.Events)
                {
                    foreach (var other in globalScope.Machines)
                    {
                        if (other.Receives.Contains(s)) {
                            messages += 1;
                            context.WriteLine(output, "if (*) {");
                            // create source variable
                            string src = $"{m.Name}_src";
                            context.WriteLine(output, $"var {src} : {m.Name}_ref_t;");
                            // create target variable
                            string trgt = $"{other.Name}_trgt";
                            context.WriteLine(output, $"var {trgt} : {other.Name}_ref_t;");

                            // create paload
                            string payload;
                            if (Equals(s.PayloadType, PrimitiveType.Null)) {
                                payload = "";
                            } else {
                                context.WriteLine(output, $"var payload_local : {context.Names.GetNameForType(s.PayloadType)};");
                                payload = $"payload_local";
                            }


                            if (Equals(s.PayloadType, PrimitiveType.Null)) {
                                context.WriteLine(output, $"if ({m.Name}_{s.Name}_to_{other.Name}[{src}][{trgt}] > 0) {{");
                                context.WriteLine(output, $"{m.Name}_{s.Name}_to_{other.Name}' = {m.Name}_{s.Name}_to_{other.Name}[{src} -> {m.Name}_{s.Name}_to_{other.Name}[{src}][{trgt} -> {m.Name}_{s.Name}_to_{other.Name}[{src}][{trgt}] - 1]];");
                                context.WriteLine(output, $"{other.Name}_{s.Name}_in' = {other.Name}_{s.Name}_in[{trgt} -> {other.Name}_{s.Name}_in[{trgt}] + 1];");
                            } else {
                                context.WriteLine(output, $"if ({m.Name}_{s.Name}_to_{other.Name}[{src}][{trgt}][{payload}] > 0) {{");
                                context.WriteLine(output, $"{m.Name}_{s.Name}_to_{other.Name}' = {m.Name}_{s.Name}_to_{other.Name}[{src} -> {m.Name}_{s.Name}_to_{other.Name}[{src}][{trgt} -> {m.Name}_{s.Name}_to_{other.Name}[{src}][{trgt}][{payload} -> {m.Name}_{s.Name}_to_{other.Name}[{src}][{trgt}][{payload}] - 1]]];");
                                context.WriteLine(output, $"{other.Name}_{s.Name}_in' = {other.Name}_{s.Name}_in[{trgt} -> {other.Name}_{s.Name}_in[{trgt}][{payload} -> {other.Name}_{s.Name}_in[{trgt}][{payload}] + 1]];");
                            }

                            context.WriteLine(output, "}");

                            context.WriteLine(output, "} else {");
                        }
                    }
                }
            }

            for (int i = 0; i < messages; i++)
            {
               context.WriteLine(output, "}"); 
            }

            context.WriteLine(output, "} else {");
            // pick machines to step
            int count = 0;
            foreach (var m in globalScope.Machines)
            {
                if (count < globalScope.Machines.Count() - 1) {
                    context.WriteLine(output, "if (*) {");
                    context.WriteLine(output, $"next({m.Name}_instances[{m.Name}_choice]);");
                    context.WriteLine(output, "} else {");
                } else {
                    context.WriteLine(output, $"next({m.Name}_instances[{m.Name}_choice]);");
                }
                count += 1;
            }

            for (int i = 0; i < globalScope.Machines.Count() - 1; i++)
            {
                context.WriteLine(output, "}");
            }

            context.WriteLine(output, "}");
            context.WriteLine(output, "} // End of next block\n");       

            context.WriteLine(output, "// make sure bag counts are positive");
            foreach (var m in globalScope.Machines)
            {
                foreach (var r in m.Receives.Events)
                {
                    if (!Equals(r.PayloadType, PrimitiveType.Null)) {
                        context.WriteLine(output, $"invariant {m.Name}_{r.Name}_in_gt0: (forall (m : {m.Name}_ref_t, p : {r.Name}_t) :: {m.Name}_{r.Name}_in[m][p] >= 0);");
                    } else {
                        context.WriteLine(output, $"invariant {m.Name}_{r.Name}_in_gt0: (forall (m : {m.Name}_ref_t) :: {m.Name}_{r.Name}_in[m] >= 0);");
                    }
                }
                foreach (var s in m.Sends.Events)
                {
                    foreach (var other in globalScope.Machines)
                    {
                        if (other.Receives.Contains(s)) {
                            if (!Equals(s.PayloadType, PrimitiveType.Null)) {
                                context.WriteLine(output, $"invariant {m.Name}_{s.Name}_to_{other.Name}_gt0: (forall (m : {m.Name}_ref_t, n : {other.Name}_ref_t, p : {s.Name}_t) :: {m.Name}_{s.Name}_to_{other.Name}[m][n][p] >= 0);");
                            } else {
                                context.WriteLine(output, $"invariant {m.Name}_{s.Name}_to_{other.Name}_gt0: (forall (m : {m.Name}_ref_t, n : {other.Name}_ref_t) :: {m.Name}_{s.Name}_to_{other.Name}[m][n] >= 0);");
                            }
                        }
                    }
                }
            }

            foreach (var m in globalScope.Machines)
            {
                int num = 0;
                foreach (var i in m.Invariants) {
                    context.WriteLine(output, $"invariant {m.Name}_{num}: {i.Trim('"')};");
                    // WriteExpr(context, output, i);
                    // context.WriteLine(output, ";");
                    num += 1;
                }
            }
        }


        private void WriteMachines(TextWriter output, IEnumerable<Machine> machines) 
        {
            foreach (var m in machines)
            {
                context.WriteLine(output, $"module {m.Name} {{");
                context.WriteLine(output, "type * = common.*;");
                context.WriteLine(output);

                bool hadEvents = false;
                foreach (var r in m.Receives.Events)
                {
                    if (!Equals(r.PayloadType, PrimitiveType.Null)) {
                        context.WriteLine(output, $"sharedvar {r.Name}_in : [{r.Name}_t]integer;");
                    } else {
                        context.WriteLine(output, $"sharedvar {r.Name}_in : integer;");
                    }
                    hadEvents = true;
                }
                foreach (var s in m.Sends.Events)
                {
                    foreach (var other in machines)
                    {
                        if (other.Receives.Contains(s)) {
                            if (!Equals(s.PayloadType, PrimitiveType.Null)) {
                                context.WriteLine(output, $"sharedvar {s.Name}_to_{other.Name} : [{other.Name}_ref_t][{s.Name}_t]integer;");
                            } else {
                                context.WriteLine(output, $"sharedvar {s.Name}_to_{other.Name} : [{other.Name}_ref_t]integer;");
                            }
                            hadEvents = true;
                        }
                    }
                }
                if (hadEvents) {
                    context.WriteLine(output);
                }

                context.WriteLine(output, $"// Declare state space");
                string stateArrayBody = string.Join(", ", m.States.Select(st => $"{m.Name}_{st.Name}"));
                context.WriteLine(output, $"var state : enum {{ {stateArrayBody} }};");
                context.WriteLine(output, "var entry : boolean;");
                context.WriteLine(output, $"const this : {m.Name}_ref_t;");
                context.WriteLine(output);

                context.WriteLine(output, "// Declare local variables");
                foreach (var field in m.Fields)
                {
                    writeVariableDecl(context, output, field);
                }
                context.WriteLine(output);

                // declare init block
                WriteInit(context, output, m.StartState);
                // declare next block
                WriteNext(context, output, m);

                context.WriteLine(output, $"}} // End of {m.Name} module\n");
            }
        }

        private void WriteNext(CompilationContext context, TextWriter output, Machine machine)
        {
            context.WriteLine(output, "next");
            context.WriteLine(output, "{");

            int choices = 0;
            int total = machine.States.Select(p => p.AllEventHandlers.Count()).Sum() + machine.States.Count();

            if (total > 0) {
                foreach (var state in machine.States)
                {

                    if (state.Entry != null && state != machine.StartState) {

                        context.WriteLine(output, "if (*) {");

                        context.WriteLine(output, $"if (state == {machine.Name}_{state.Name} && entry) {{");

                        foreach (Variable local in state.Entry.Signature.Parameters)
                        {
                            writeVariableDecl(context, output, local);
                        }

                        foreach (Variable local in state.Entry.LocalVariables)
                        {
                            writeVariableDecl(context, output, local);
                        }

                        foreach (IPStmt bodyStatement in state.Entry.Body.Statements)
                        {
                            WriteStmt(context, output, state.Entry, bodyStatement, true);
                        }
                        context.WriteLine(output, "entry' = false;");
                        context.WriteLine(output, "}");

                        if (choices < total - 1) {
                            context.WriteLine(output, "} else {");
                        }
                        choices += 1;
                    } else {
                        total -= 1;
                    }

                    foreach (var handler in state.AllEventHandlers)
                    {
                        PEvent pEvent = handler.Key;
                        IStateAction stateAction = handler.Value;
                        if (choices < total - 1) {
                            context.WriteLine(output, "if (*) {");
                        }

                        string input_name = $"{pEvent.Name}_local";

                        switch (stateAction)
                        {
                            case EventDoAction eventDoAction:
                                Function func = eventDoAction.Target;
                                Boolean found = false;

                                foreach (Variable local in func.Signature.Parameters)
                                {
                                    writeVariableDecl(context, output, local);
                                    if (local.Type.IsSameTypeAs(pEvent.PayloadType)) {
                                        input_name = local.Name;
                                        found = true;
                                    }
                                }

                                if (!found && !Equals(pEvent.PayloadType, PrimitiveType.Null)) {
                                    context.WriteLine(output, $"var {input_name} : {context.Names.GetNameForType(pEvent.PayloadType)};");
                                }

                                if (Equals(pEvent.PayloadType, PrimitiveType.Null)) {
                                    context.WriteLine(output, $"if (state == {machine.Name}_{state.Name} && {pEvent.Name}_in > 0) {{");
                                } else {
                                    context.WriteLine(output, $"if (state == {machine.Name}_{state.Name} && {pEvent.Name}_in[{input_name}] > 0) {{");
                                }

                                foreach (Variable local in func.LocalVariables)
                                {
                                    writeVariableDecl(context, output, local);
                                }

                                Boolean has_goto = false; 
                                foreach (IPStmt bodyStatement in func.Body.Statements)
                                {
                                    switch (bodyStatement)
                                    {
                                        case GotoStmt _:
                                            has_goto = true; 
                                            break;
                                        default:
                                            break;
                                    }
                                    WriteStmt(context, output, func, bodyStatement, true);
                                }

                                if (!has_goto) {
                                    context.WriteLine(output, "entry' = false;");
                                } 
                                break;

                            case EventDefer _:
                            case EventGotoState eventGotoStateNull when eventGotoStateNull.TransitionFunction == null:
                            case EventGotoState eventGotoState when eventGotoState.TransitionFunction != null:
                            case EventIgnore _:
                            case EventPushState eventPushState:
                                context.WriteLine(output, $"{stateAction.ToString()} {{ // Not implemented yet");
                                break;
                        }

                        if (Equals(pEvent.PayloadType, PrimitiveType.Null)) {
                            context.WriteLine(output, $"{pEvent.Name}_in' = {pEvent.Name}_in - 1;");
                        } else {
                            context.WriteLine(output, $"{pEvent.Name}_in' = {pEvent.Name}_in[{input_name} -> ({pEvent.Name}_in[{input_name}] - 1)];");
                        }
                        context.WriteLine(output, "}");

                        if (choices < total - 1) {
                            context.WriteLine(output, "} else {");
                        }
                        choices += 1;
                    }
                }
                for (int i = 0; i < total - 1; i++)
                {
                    context.WriteLine(output, "}");
                }
            }
            context.WriteLine(output, "}// End of next block\n");
        }

        private void writeVariableDecl(CompilationContext context, TextWriter output, Variable field){

            string name = field.Role == VariableRole.Temp ? field.Name : field.Name.Replace("$", "_");

            switch (field.Type.Canonicalize())
            {
                case SequenceType sequenceType:
                    context.WriteLine(output, $"type {name}_seq;");
                    context.WriteLine(output, $"var {name} : [{name}_seq]{context.Names.GetNameForType(sequenceType.ElementType)};");
                    break;

                case PrimitiveType primitiveType when Equals(primitiveType, PrimitiveType.Event):
                    break;

                default:
                    context.WriteLine(output, $"var {name} : {context.Names.GetNameForType(field.Type)};");
                    break;
            }
        }

        private void WriteInit(CompilationContext context, TextWriter output, State state)
        {

            context.WriteLine(output, "init");
            if (state.Entry == null) {
                context.WriteLine(output, "{");
                context.WriteLine(output, "entry = true;");
                context.WriteLine(output, "}");
            } else {
                context.WriteLine(output, "{");

                foreach (Variable local in state.Entry.Signature.Parameters)
                {
                    writeVariableDecl(context, output, local);
                }

                foreach (Variable local in state.Entry.LocalVariables)
                {
                    writeVariableDecl(context, output, local);
                }

                foreach (IPStmt bodyStatement in state.Entry.Body.Statements)
                {
                    WriteStmt(context, output, state.Entry, bodyStatement);
                }
                context.WriteLine(output, "}// End of init block\n");
            }
        }

        private IPStmt FlattenStatement(IPStmt stmt) {
            switch (stmt)
            {
                case AssignStmt assignStmt:
                    return new AssignStmt(assignStmt.SourceLocation, assignStmt.Location, FlattenExpr(assignStmt.Value));
                default:
                    return stmt;
            }
        }

        private IPExpr FlattenExpr(IPExpr expr) {
            switch (expr)
            {
                case CloneExpr cExpr:
                    return cExpr.Term;
                default:
                    return expr;
            }
        }

        private void WriteStmt(CompilationContext context, TextWriter output, Function function, IPStmt inStmt, Boolean primed = false)
        {
            IPStmt stmt = FlattenStatement(inStmt);
            switch (stmt)
            {
                case AssignStmt assignStmt:
                    WriteAssign(context, output, function, assignStmt, primed);
                    break;

                case CompoundStmt compoundStmt:
                    context.WriteLine(output, "{");
                    foreach (IPStmt subStmt in compoundStmt.Statements)
                    {
                        WriteStmt(context, output, function, subStmt, primed);
                    }

                    context.WriteLine(output, "}");
                    break;

                case GotoStmt gotoStmt:
                    //last statement
                    if (primed) {
                        context.WriteLine(output, $"state' = {function.Owner.Name}_{context.Names.GetNameForDecl(gotoStmt.State)};");
                        context.WriteLine(output, "entry' = true;");
                    } else {
                        context.WriteLine(output, $"state = {function.Owner.Name}_{context.Names.GetNameForDecl(gotoStmt.State)};");
                        context.WriteLine(output, "entry = true;");                        
                    }
                    break;

                case IfStmt ifStmt:
                    context.Write(output, "if (");
                    WriteExpr(context, output, ifStmt.Condition);
                    context.WriteLine(output, ")");
                    WriteStmt(context, output, function, ifStmt.ThenBranch, primed);
                    if (ifStmt.ElseBranch != null && ifStmt.ElseBranch.Statements.Any())
                    {
                        context.WriteLine(output, "else");
                        WriteStmt(context, output, function, ifStmt.ElseBranch, primed);
                    }

                    break;

                case SendStmt sendStmt:
                    string target_type = sendStmt.MachineExpr.Type.CanonicalRepresentation;
                    string event_type = ((SendStmtContext)sendStmt.SourceLocation).@event.GetText();
                    string bag_name = $"{event_type}_to_{target_type}";

                    CompilationContext empty = new CompilationContext(context.Job);
                    StringWriter machine_expr_writer = new StringWriter();
                    WriteExpr(empty, machine_expr_writer, sendStmt.MachineExpr);
                    string target_name = machine_expr_writer.ToString();

                    if (sendStmt.Arguments.Count() == 0) {
                        context.WriteLine(output, $"{bag_name}' = {bag_name}[{target_name} -> {bag_name}[{target_name}] + 1];");
                    } else {
                        StringWriter args_writer = new StringWriter();
                        if (sendStmt.Arguments.Count > 1)
                        {
                            string septor = "";
                            foreach (IPExpr ctorExprArgument in sendStmt.Arguments)
                            {
                                empty.Write(args_writer, septor);
                                WriteExpr(empty, args_writer, ctorExprArgument);
                                septor = ",";
                            }

                            empty.Write(args_writer, ")");
                        }
                        else
                        {
                            WriteExpr(empty, args_writer, sendStmt.Arguments.First());
                        }
                        string args = args_writer.ToString();

                        context.WriteLine(output, $"{bag_name}' = {bag_name}[{target_name} -> {bag_name}[{target_name}][{args} -> {bag_name}[{target_name}][{args}] + 1]];");
                    }
                    break;

                case MoveAssignStmt moveAssignStmt:
                    Variable field = moveAssignStmt.FromVariable;
                    string name = field.Role == VariableRole.Temp ? field.Name : field.Name.Replace("$", "_");
                    if (primed) {
                        WriteLValue(context, output, moveAssignStmt.ToLocation, function.LocalVariables.ToList());
                    } else {
                        WriteLValue(context, output, moveAssignStmt.ToLocation);
                    }
                    context.WriteLine(output, $" = {name};");
                    break;
            
                case AssertStmt assertStmt:
                    context.Write(output, "assert(");
                    WriteExpr(context, output, assertStmt.Assertion);
                    context.WriteLine(output, ");");
                    break;

                case FunCallStmt funCallStmt:
                case AnnounceStmt announceStmt:
                case CtorStmt ctorStmt:
                case AddStmt addStmt:
                case InsertStmt insertStmt:
                case NoStmt _:
                case PopStmt _:
                case PrintStmt printStmt:
                case RaiseStmt raiseStmt:
                case ReceiveStmt receiveStmt:
                case RemoveStmt removeStmt:
                case ReturnStmt returnStmt:
                case BreakStmt breakStmt:
                case ContinueStmt continueStmt:
                    // TODO
                    context.WriteLine(output, $"{stmt.ToString()} // Not implemented yet");
                    break;

                case SwapAssignStmt swapStmt:
                    throw new NotImplementedException("Swap Assignment Not Implemented");

                case WhileStmt whileStmt:
                    context.Write(output, "while (");
                    WriteExpr(context, output, whileStmt.Condition);
                    context.WriteLine(output, ")");
                    WriteStmt(context, output, function, whileStmt.Body, primed);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(stmt));
            }
        }

        private void WriteAssign(CompilationContext context, TextWriter output, Function function, AssignStmt assignStmt, bool primed)
        {
            Boolean assumed = false;
            IPExpr loc = assignStmt.Location;
            if (primed) {
            LOC:
                switch (loc)
                {
                    case TupleAccessExpr tupleAccessExpr:
                        loc = tupleAccessExpr.SubExpr;
                        goto LOC;

                    case NamedTupleAccessExpr namedTupleAccessExpr:
                        loc = namedTupleAccessExpr.SubExpr;
                        goto LOC;
                        
                    case MapAccessExpr mapAccessExpr:
                        loc = mapAccessExpr.MapExpr;
                        goto LOC;

                    case SeqAccessExpr seqAccessExpr:
                        loc = seqAccessExpr.SeqExpr;
                        goto LOC;

                    case VariableAccessExpr variableAccessExpr:
                        Variable field = variableAccessExpr.Variable;
                        string name = field.Role == VariableRole.Temp ? field.Name : field.Name.Replace("$", "_");

                        if (function.LocalVariables != null && !function.LocalVariables.Contains(field)) {
                            assumed = false;
                        } else {
                            assumed = true;
                        }
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(assignStmt.Location));
                }
            }

            switch (assignStmt.Value)
            {
                case NamedTupleExpr namedTupleExpr:
                    List<string> fieldNamesList = ((NamedTupleType)namedTupleExpr.Type).Names.ToList();
                    for (int i = 0; i < namedTupleExpr.TupleFields.Count; i++)
                    {
                        context.Write(output, "assume(");
                        if (primed) {
                            WriteLValue(context, output, assignStmt.Location, function.LocalVariables.ToList());
                        } else {
                            WriteLValue(context, output, assignStmt.Location);
                        }
                        context.Write(output, $".{fieldNamesList[i]} == ");
                        WriteExpr(context, output, namedTupleExpr.TupleFields[i]);
                        context.WriteLine(output, ");");
                        }
                    break;

                case EventRefExpr eRefExp:
                    break;
                case NondetExpr nondetExpr:
                    switch (assignStmt.Location)
                    {
                        case VariableAccessExpr variableAccessExpr:
                            List<Variable> locals = function.LocalVariables.ToList();
                            Variable variable = variableAccessExpr.Variable;
                            string vname = variable.Role == VariableRole.Temp ? variable.Name : variable.Name.Replace("$", "_");

                            if (!locals.Contains(variable)) {
                                context.Write(output, $"havoc {vname};");
                            }
                            break;

                        default:
                            throw new ArgumentOutOfRangeException(nameof(assignStmt.Location));
                    }
                    break;

                default:
                    if (assumed) {
                        context.Write(output, "assume(");
                        if (primed) {
                            WriteLValue(context, output, assignStmt.Location, function.LocalVariables.ToList());
                        } else {
                            WriteLValue(context, output, assignStmt.Location);
                        }
                        context.Write(output, " == ");
                        WriteExpr(context, output, assignStmt.Value);
                        context.WriteLine(output, ");");
                    } else {
                        if (primed) {
                            WriteLValue(context, output, assignStmt.Location, function.LocalVariables.ToList());
                        } else {
                            WriteLValue(context, output, assignStmt.Location);
                        }
                        context.Write(output, " = ");      
                        WriteExpr(context, output, assignStmt.Value);
                        context.WriteLine(output, ";");
                    }
                    break;
            }
        }

        private void WriteExpr(CompilationContext context, TextWriter output, IPExpr pExpr)
        {
            switch (pExpr)
            {
                case CloneExpr cloneExpr:
                    WriteClone(context, output, cloneExpr.Term);
                    break;

                case BinOpExpr binOpExpr:
                    //handle eq and noteq differently
                    if (binOpExpr.Operation == BinOpType.Eq || binOpExpr.Operation == BinOpType.Neq)
                    {
                        string negate = binOpExpr.Operation == BinOpType.Neq ? "!" : "";
                        context.Write(output, $"{negate}(");
                        WriteExpr(context, output, binOpExpr.Lhs);
                        context.Write(output, $" == ");
                        WriteExpr(context, output, binOpExpr.Rhs);
                        context.Write(output, ")");
                    }
                    else
                    {
                        context.Write(output, "(");
                        WriteExpr(context, output, binOpExpr.Lhs);
                        context.Write(output, $" {BinOpToStr(binOpExpr.Operation)} ");
                        WriteExpr(context, output, binOpExpr.Rhs);
                        context.Write(output, ")");
                    }

                    break;

                case BoolLiteralExpr boolLiteralExpr:
                    context.Write(output, $"{(boolLiteralExpr.Value ? "true" : "false")}");
                    break;

                case DefaultExpr defaultExpr:
                    context.Write(output, GetDefaultValue(defaultExpr.Type));
                    break;

                case IntLiteralExpr intLiteralExpr:
                    context.Write(output, $"{intLiteralExpr.Value}");
                    break;

                case NondetExpr _:
                    context.Write(output, "*");
                    break;

                case SizeofExpr sizeofExpr:
                    WriteExpr(context, output, sizeofExpr.Expr);
                    break;

                case UnaryOpExpr unaryOpExpr:
                    context.Write(output, $"{UnOpToStr(unaryOpExpr.Operation)}(");
                    WriteExpr(context, output, unaryOpExpr.SubExpr);
                    context.Write(output, ")");
                    break;

                case LinearAccessRefExpr linearAccessRefExpr:
                    Variable field = linearAccessRefExpr.Variable;
                    string name = field.Role == VariableRole.Temp ? field.Name : field.Name.Replace("$", "_");
                    context.Write(output, $"{name}");
                    break;

                case UnnamedTupleExpr unnamedTupleExpr:
                    context.Write(output, "(");
                    string septor = "";
                    foreach (var el in unnamedTupleExpr.TupleFields)
                    {
                        context.Write(output, septor);
                        WriteExpr(context, output, el);
                        septor = ", ";
                    }
                    context.Write(output, ")");
                    break;

                case StringExpr stringExpr:
                    context.Write(output, "0");
                    break;

                case ThisRefExpr _:
                    context.Write(output, "this");
                    break;

                case CastExpr castExpr:
                case CoerceExpr coerceExpr:
                case ChooseExpr chooseExpr:
                case ContainsExpr containsExpr:
                case CtorExpr ctorExpr:
                case EnumElemRefExpr enumElemRefExpr:
                case EventRefExpr eventRefExpr:
                case FairNondetExpr _:
                case FloatLiteralExpr floatLiteralExpr:
                case FunCallExpr funCallExpr:
                case KeysExpr keysExpr:
                case NullLiteralExpr _:
                case ValuesExpr valuesExpr:
                    // TODO
                    context.Write(output, $"{pExpr.ToString()} // Not implemented yet");
                    break;

                case MapAccessExpr _:
                case NamedTupleAccessExpr _:
                case NamedTupleExpr _:
                case SeqAccessExpr _:
                case TupleAccessExpr _:
                case VariableAccessExpr _:
                    WriteLValue(context, output, pExpr);
                    break;

                default:
                    Console.WriteLine($"\n\nhere with {pExpr}\n\n");
                    throw new ArgumentOutOfRangeException(nameof(pExpr), $"type was {pExpr?.GetType().FullName}");
            }
        }
        private void WriteLValue(CompilationContext context, TextWriter output, IPExpr lvalue, List<Variable> locals = null)
        {
            switch (lvalue)
            {
                case TupleAccessExpr tupleAccessExpr:
                    WriteExpr(context, output, tupleAccessExpr.SubExpr);
                    context.Write(output, $"_{tupleAccessExpr.FieldNo}");
                    break;

                case NamedTupleAccessExpr namedTupleAccessExpr:
                    WriteExpr(context, output, namedTupleAccessExpr.SubExpr);
                    context.Write(output, $".{namedTupleAccessExpr.FieldName}");
                    break;

                case NamedTupleExpr namedTupleExpr:
                    List<string> fieldNamesArray = ((NamedTupleType)namedTupleExpr.Type).Names.ToList();
                    context.Write(output, "{");
                    string septor = "";
                    for (int i = 0; i < namedTupleExpr.TupleFields.Count(); i++)
                    {
                        context.Write(output, septor);
                        context.Write(output, $"{fieldNamesArray[i]} : ");
                        WriteExpr(context, output, namedTupleExpr.TupleFields[i]);
                        septor = ", ";
                    }
                    context.Write(output, "}");
                    break;

                case MapAccessExpr _:
                case SeqAccessExpr _:
                    //TODO
                    context.Write(output, $"{lvalue.ToString()} // Not implemented yet");
                    break;
                    
                case VariableAccessExpr variableAccessExpr:
                    Variable field = variableAccessExpr.Variable;
                    string name = field.Role == VariableRole.Temp ? field.Name : field.Name.Replace("$", "_");

                    if (locals != null && !locals.Contains(field)) {
                        context.Write(output, $"{name}'");
                    } else {
                        context.Write(output, name);
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(lvalue));
            }
        }

        private void WriteClone(CompilationContext context, TextWriter output, IExprTerm cloneExprTerm)
        {
            if (!(cloneExprTerm is IVariableRef variableRef))
            {
                WriteExpr(context, output, cloneExprTerm);
                return;
            }
            Variable field = variableRef.Variable;
            string varName = field.Role == VariableRole.Temp ? field.Name : field.Name.Replace("$", "_");
            context.Write(output, $"{varName}");
        }

        private string GetUclidType(PLanguageType type, bool isVar = false)
        {
            switch (type.Canonicalize())
            {
                case DataType _:
                case EnumType _:
                case ForeignType _:
                case MapType _:
                case NamedTupleType _:
                case PermissionType _:
                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Any):
                case PrimitiveType primitiveType1 when primitiveType1.IsSameTypeAs(PrimitiveType.Event):
                case PrimitiveType primitiveType2 when primitiveType2.IsSameTypeAs(PrimitiveType.String):
                case PrimitiveType primitiveType3 when primitiveType3.IsSameTypeAs(PrimitiveType.Float):
                case PrimitiveType primitiveType4 when primitiveType4.IsSameTypeAs(PrimitiveType.Machine):
                case PrimitiveType primitiveType5 when primitiveType5.IsSameTypeAs(PrimitiveType.Null):
                case SequenceType _:
                case TupleType _:
                case SetType _:
                    return type.CanonicalRepresentation;

                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Bool):
                    return "boolean";

                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Int):
                    return "integer";

                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }
        private string GetDefaultValue(PLanguageType returnType)
        {
            switch (returnType.Canonicalize())
            {

                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Bool):
                    return "false";

                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Int):
                    return "0";

                case PrimitiveType primitiveType1 when primitiveType1.IsSameTypeAs(PrimitiveType.String):
                    return "0";

                case EnumType _:
                case MapType mapType:
                case SequenceType sequenceType:
                case SetType setType:
                case NamedTupleType namedTupleType:
                case TupleType tupleType:
                case PrimitiveType primitiveType when primitiveType.IsSameTypeAs(PrimitiveType.Float):
                case PrimitiveType eventType when eventType.IsSameTypeAs(PrimitiveType.Event):
                case PermissionType _:
                case PrimitiveType anyType when anyType.IsSameTypeAs(PrimitiveType.Any):
                case PrimitiveType machineType when machineType.IsSameTypeAs(PrimitiveType.Machine):
                case ForeignType _:
                case PrimitiveType nullType when nullType.IsSameTypeAs(PrimitiveType.Null):
                case DataType _:
                case null:
                    return "null // Not implemented yet";

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
    }
}
