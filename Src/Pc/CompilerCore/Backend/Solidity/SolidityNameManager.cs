using System.Collections.Generic;
using Plang.Compiler.TypeChecker.AST;
using Plang.Compiler.TypeChecker.AST.Declarations;
using Plang.Compiler.TypeChecker.Types;

namespace Plang.Compiler.Backend.Solidity
{
    internal class SolidityNameManager : NameManagerBase
    {
        public SolidityNameManager(string namePrefix) : base(namePrefix)
        {
        }

        protected override string ComputeNameForDecl(IPDecl decl)
        {
            string name = decl.Name;
            if (name.StartsWith("$"))
            {
                name = "TMP_" + name.Substring(1);
            }

            return name;
        }
    }
}
