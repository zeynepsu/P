using Microsoft.Pc.TypeChecker.AST;

namespace Microsoft.Pc.Backend.Solidity
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
