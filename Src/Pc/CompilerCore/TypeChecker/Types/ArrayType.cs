using System;
using System.Collections.Generic;
using Plang.Compiler.TypeChecker.AST.Declarations;

namespace Plang.Compiler.TypeChecker.Types
{
    public class ArrayType : PLanguageType
    {
        public ArrayType(PLanguageType elementType) : base(TypeKind.Array)
        {
            ElementType = elementType;
        }


        public PLanguageType ElementType { get; }

        public override string OriginalRepresentation => $"array[{ElementType.OriginalRepresentation}]";
        public override string CanonicalRepresentation => $"array[{ElementType.CanonicalRepresentation}]";

        public override Lazy<IReadOnlyList<PEvent>> AllowedPermissions => ElementType.AllowedPermissions;

        public override bool IsAssignableFrom(PLanguageType otherType)
        {
            // Copying semantics: Can assign to a array variable if the other array's elements are subtypes of this array's elements.
            return otherType.Canonicalize() is ArrayType other && ElementType.IsAssignableFrom(other.ElementType);
        }

        public override PLanguageType Canonicalize()
        {
            if (! (ElementType is TypeDefType) )
            {
                return new ArrayType(ElementType.Canonicalize());
            }
            else
            {
                return this;
            }
        }
    }
}