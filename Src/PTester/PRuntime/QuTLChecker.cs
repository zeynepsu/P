using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Runtime
{
    enum AstNodeType
    {
        OPERATOR = 0,
        EVENT = 1,
        VALUE = 2
    }

    enum QuTLOperator
    {

    }
    class AstNode
    {
#region Constructors
        AstNode(AstNodeType type, QuTLOperator op, PrtValue ev, int vl)
        {
            this.type = type;
            this.op = op;
            this.ev = ev;
            this.vl = vl;
            this.left = null;
            this.right = null;
        }
#endregion

#region Fields
        private AstNodeType type;
        private QuTLOperator op;
        private PrtValue ev;
        private int vl; // value

        public AstNode left;
        public AstNode right;

        public AstNodeType Type { get => type; set => type = value; }
        public QuTLOperator Operator { get => op; set => op = value; }
        public PrtValue Event { get => ev; set => ev = value; }
        public int Value { get => vl; set => vl = value; }
#endregion
    }

    /// <summary>
    /// Parser for QuTL formulae
    /// 
    /// </summary>
    class QuTLParser
    {

    }

    /// <summary>
    /// Labeled transition systems (LTS). We constructed it from a queue
    /// </summary>
    class LTS
    {

    }
    /// <summary>
    /// 
    /// </summary>
    class QuTLChecker
    {
#region Constructors
        protected QuTLChecker(AstNode root)
        {

        }
#endregion

#region fields
        private readonly AstNode root;

#endregion

        public static bool Check(List<PrtEventNode> Q)
        {

            return false;
        }
    }
}
