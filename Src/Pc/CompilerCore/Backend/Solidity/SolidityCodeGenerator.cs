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

            WriteSourceEpilogue(context, source.Stream);

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
                case Function function:
                    context.WriteLine(output, $"public static partial class {context.GlobalFunctionClassName}");
                    context.WriteLine(output, "{");
                    WriteFunction(context, output, function);
                    context.WriteLine(output, "}");
                    break;
                case PEvent pEvent when !pEvent.IsBuiltIn:
                    context.WriteLine(output, $"internal class {declName} : Event");
                    context.WriteLine(output, "{");
                    WriteEvent(context, output, pEvent);
                    context.WriteLine(output, "}");
                    break;
                case Machine machine:
                    context.WriteLine(output, $"internal class {declName} : Machine");
                    context.WriteLine(output, "{");
                    WriteMachine(context, output, machine);
                    context.WriteLine(output, "}");
                    break;
                case PEnum pEnum:
                    context.WriteLine(output, $"public enum {declName}");
                    context.WriteLine(output, "{");
                    foreach (EnumElem enumElem in pEnum.Values)
                    {
                        context.WriteLine(output, $"{declName} = {enumElem.Value},");
                    }

                    context.WriteLine(output, "}");
                    break;
                default:
                    context.WriteLine(output, $"// TODO: {decl.GetType().Name} {declName}");
                    break;
            }
        }


    }

   
}
