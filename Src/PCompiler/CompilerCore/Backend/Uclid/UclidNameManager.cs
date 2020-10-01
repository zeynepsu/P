using Plang.Compiler.TypeChecker.AST;
using Plang.Compiler.TypeChecker.AST.Declarations;
using Plang.Compiler.TypeChecker.AST.States;
using Plang.Compiler.TypeChecker.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Plang.Compiler.Backend.Uclid
{
    public class UclidNameManager : NameManagerBase
    {
        private readonly Dictionary<PLanguageType, string> typeNames = new Dictionary<PLanguageType, string>();

        public UclidNameManager(string namePrefix)
            : base(namePrefix)
        {
        }

        public IEnumerable<PLanguageType> UsedTypes => typeNames.Keys;

        public string GetNameForType(PLanguageType type)
        {
            type = type.Canonicalize();

            if (typeNames.TryGetValue(type, out string name))
            {
                return name;
            }
            name = SimplifiedRep(type);
            typeNames.Add(type, name);
            return name;
        }

        protected override string ComputeNameForDecl(IPDecl decl)
        {
            return decl.Name;
        }

        private string SimplifiedRep(PLanguageType type)
        {
            switch (type.Canonicalize())
            {
                case MapType mapType:
                    return $"[{SimplifiedRep(mapType.KeyType)}]{SimplifiedRep(mapType.ValueType)}";

                case PermissionType ptype:
                    return $"{ptype.CanonicalRepresentation}_ref_t";

                case PrimitiveType primitiveType when Equals(primitiveType, PrimitiveType.Bool):
                    return "boolean";

                case PrimitiveType primitiveType when Equals(primitiveType, PrimitiveType.Int):
                    return "integer";

                case PrimitiveType primitiveType when Equals(primitiveType, PrimitiveType.String):
                    // Works since we never do string solving
                    return "string"; // need to declare string as an uninterpreted type. 

                case NamedTupleType namedTupleType:
                    List<string> fieldNames = namedTupleType.Names.Select(n => $"{n}").ToList();
                    List<string> fieldTypes = namedTupleType.Types.Select(n => $"{SimplifiedRep(n)}").ToList();
                    List<(string First, string Second)> args = fieldNames.Zip(fieldTypes).ToList();
    
                    return $"record {{{string.Join(", ", args.Select((x) => $"{x.First} : {x.Second}"))}}}";

                case TupleType tupleType:
                    return $"{{{string.Join(", ", tupleType.Types.Select((x) => SimplifiedRep(x)))}}}";

                default:
                    throw new ArgumentException("unsupported primitive type", type.OriginalRepresentation);
            }

            throw new ArgumentException("unsupported type kind", nameof(type));
        }
    }
}