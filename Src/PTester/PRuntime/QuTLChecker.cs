using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Runtime
{

    static class Symbol
    {
        /// <summary>
        /// current processing event
        /// </summary>
        public static readonly string PROCESS_EVENT = "$";
        /// <summary>
        ///  temporal operators
        /// </summary>
        public static readonly string TMP_F = "F";
        public static readonly string TMP_X = "X";
        public static readonly string TMP_G = "G";
        /// <summary>
        /// queue operators
        /// </summary>
        public static readonly string COUNT = "#";
        public static readonly string SIZE = "#Q";
        /// <summary>
        /// 
        /// </summary>
        public static readonly string NEGATION = "~";
        public static readonly string AND = "&";
        public static readonly string OR = "|";
        public static readonly string IMPLICATION = "=>";
        /// <summary>
        /// relation operators
        /// </summary>
        public static readonly string EQUAL = "=";
        public static readonly string NOT_EQUAL = "!=";
        public static readonly string LESS_THAN = "<";
        public static readonly string LESS_THAN_EQ = "<=";
        public static readonly string GREATER_THAN = ">";
        public static readonly string GREATER_THAN_EQ = ">=";
        /// <summary>
        /// arithmetic operators
        /// </summary>
        public static readonly string ADDITION = "+";
        public static readonly string SUBTRACTION = "-";
        public static readonly string PARENTHSIS = "()";
        /// <summary>
        /// constant bool value:
        /// -- true
        /// -- false
        /// </summary>
        public static readonly string CONST_T = "T";
        public static readonly string CONST_F = "F";
    }

    /// <summary>
    /// The types of AST node:
    ///  1. temporal operator
    ///  2. event
    ///  3. value: an integer value
    /// </summary>
    public enum AstNodeType
    {
        OPERATOR = 0,
        EVENT = 1,
        VALUE = 2
    }

    public enum QuTLOperator
    {
        /// <summary>
        /// Current processin event
        /// </summary>
        PROCESS_EVENT,
        /// <summary>
        ///  temporal operators
        /// </summary>
        TMP_F = 0,
        TMP_X,
        TMP_G,
        /// <summary>
        /// queue operators
        /// </summary>
        COUNT,
        SIZE,
        /// <summary>
        /// 
        /// </summary>
        NEGATION,
        AND,
        OR,
        IMPLICATION,
        /// <summary>
        /// relation operators
        /// </summary>
        EQUAL,
        NOT_EQUAL,
        LESS_THAN,
        LESS_THAN_EQ,
        GREATER_THAN,
        GREATER_THAN_EQ,
        /// <summary>
        /// arithmetic operators
        /// </summary>
        ADDITION,
        SUBTRACTION,
        PARENTHSIS,
        /// <summary>
        /// constant bool value:
        /// -- true
        /// -- false
        /// </summary>
        CONST_T,
        CONST_F,
        /// <summary>
        /// 
        /// </summary>
        NULLOP
    }

    /// <summary>
    /// 
    /// </summary>
    public class ExprNode
    {
        #region Constructors
        public ExprNode(QuTLOperator op)
        {
            this.type = AstNodeType.OPERATOR;
            this.op = op;
            this.ev = null;
            this.vl = int.MinValue;
        }
        public ExprNode(string ev)
        {
            this.type = AstNodeType.EVENT;
            this.op = QuTLOperator.NULLOP;
            this.ev = ev;
            this.vl = int.MinValue;
        }
        public ExprNode(int vl)
        {
            this.type = AstNodeType.VALUE;
            this.op = QuTLOperator.NULLOP;
            this.ev = null;
            this.vl = vl;
        }
        #endregion

        #region Fields
        private AstNodeType type;
        private QuTLOperator op;
        private String ev;
        private int vl; // value

        public AstNodeType Type { get => type; set => type = value; }
        public QuTLOperator Operator { get => op; set => op = value; }
        public string Event { get => ev; set => ev = value; }
        public int Value { get => vl; set => vl = value; }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            switch(type)
            {
                case AstNodeType.EVENT:
                    sb.Append(ev);
                    break;
                case AstNodeType.VALUE:
                    sb.Append(vl);
                    break;
                default:
                    sb.Append("op");
                    break;
            }
            return sb.ToString();
        }
    }

    public class AstNode
    {
        #region Constructors
        public AstNode(ExprNode node)
        {
            this.enode = node;
            this.left = null;
            this.right = null;
        }
        #endregion

        #region Fields
        public ExprNode enode;
        public AstNode left;
        public AstNode right;
       #endregion
    }

    /// <summary>
    /// Parser for QuTL formulae
    /// 
    /// </summary>
    public class QuTLParser
    {
        #region
        public QuTLParser(string expr)
        {
            phi = BuildExprNode(expr);
        }
        #endregion

        #region fields
        private readonly List<ExprNode> phi;
        #endregion

        public AstNode BuildAst()
        {
            return BuildAst(this.phi);
        }

        private AstNode BuildAst(List<ExprNode> phi)
        {
            Stack<AstNode> worklist = new Stack<AstNode>();
            foreach (var node in phi)
            {
                switch(node.Type)
                {
                    case AstNodeType.EVENT:
                        worklist.Push(new AstNode(node));
                        break;
                    case AstNodeType.VALUE:
                        worklist.Push(new AstNode(node));
                        break;
                    default:
                        BuildAst(node, ref worklist);
                        break;
                }
            }
            return worklist.Peek();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="worklist"></param>
        /// <returns></returns>
        private AstNode BuildAst(ExprNode node, ref Stack<AstNode> worklist)
        {

            var curr = new AstNode(node);
            switch (node.Operator)
            {
                case QuTLOperator.TMP_F:
                case QuTLOperator.TMP_G:
                case QuTLOperator.TMP_X:
                    {
                        var lch = worklist.Pop();
                        curr.left = lch;
                        worklist.Push(curr);
                    }
                    break;
                case QuTLOperator.COUNT:
                    {
                        var lch = worklist.Pop();
                        curr.left = lch;
                        worklist.Push(curr);
                    }
                    break;
                case QuTLOperator.SIZE:
                    {
                        worklist.Push(curr);  
                    }
                    break;
                case QuTLOperator.NEGATION:
                    {
                        var lch = worklist.Pop();
                        curr.left = lch;
                        worklist.Push(curr);
                    }
                    break;
                case QuTLOperator.AND:
                case QuTLOperator.OR:
                case QuTLOperator.IMPLICATION:
                case QuTLOperator.EQUAL:
                case QuTLOperator.NOT_EQUAL:
                case QuTLOperator.LESS_THAN:
                case QuTLOperator.LESS_THAN_EQ:
                case QuTLOperator.GREATER_THAN:
                case QuTLOperator.GREATER_THAN_EQ:
                case QuTLOperator.ADDITION:
                case QuTLOperator.SUBTRACTION:
                    {
                        var rch = worklist.Pop();
                        curr.right = rch;

                        var lch = worklist.Pop();
                        curr.left = lch;

                        worklist.Push(curr);
                    }
                    break;
                default:
                    throw new Exception("Unknow QuTL operator!");

            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        private List<ExprNode> BuildExprNode(string expr)
        {
            var eArray = expr.Split(null);
            List<ExprNode> phi = new List<ExprNode>();
            foreach (var op in eArray)
            {
                Console.WriteLine(op);

                ExprNode node = null;
                if (op == Symbol.TMP_F)
                {
                    node = new ExprNode(QuTLOperator.TMP_F);
                }
                else if (op == Symbol.TMP_X)
                {
                    node = new ExprNode(QuTLOperator.TMP_X);
                }
                else if (op == Symbol.TMP_G)
                {
                    node = new ExprNode(QuTLOperator.TMP_G);
                }
                else if (op == Symbol.COUNT)
                {
                    node = new ExprNode(QuTLOperator.COUNT);
                }
                else if (op == Symbol.SIZE)
                {
                    node = new ExprNode(QuTLOperator.SIZE);
                }
                else if (op == Symbol.NEGATION)
                {
                    node = new ExprNode(QuTLOperator.NEGATION);
                }
                else if (op == Symbol.AND)
                {
                    node = new ExprNode(QuTLOperator.AND);
                }
                else if (op == Symbol.OR)
                {
                    node = new ExprNode(QuTLOperator.OR);
                }
                else if (op == Symbol.IMPLICATION)
                {
                    node = new ExprNode(QuTLOperator.IMPLICATION);
                }
                else if (op == Symbol.EQUAL)
                {
                    node = new ExprNode(QuTLOperator.EQUAL);
                }
                else if (op == Symbol.NOT_EQUAL)
                {
                    node = new ExprNode(QuTLOperator.NOT_EQUAL);
                }
                else if (op == Symbol.LESS_THAN)
                {
                    node = new ExprNode(QuTLOperator.LESS_THAN);
                }
                else if (op == Symbol.LESS_THAN_EQ)
                {
                    node = new ExprNode(QuTLOperator.LESS_THAN_EQ);
                }
                else if (op == Symbol.GREATER_THAN_EQ)
                {
                    node = new ExprNode(QuTLOperator.GREATER_THAN_EQ);
                }
                else if (op == Symbol.ADDITION)
                {
                    node = new ExprNode(QuTLOperator.ADDITION);
                }
                else if (op == Symbol.SUBTRACTION)
                {
                    node = new ExprNode(QuTLOperator.SUBTRACTION);
                }
                else if (op == Symbol.PARENTHSIS)
                {
                    node = new ExprNode(QuTLOperator.PARENTHSIS);
                }
                else if (op == Symbol.CONST_T)
                {
                    node = new ExprNode(1);
                }
                else if (op == Symbol.CONST_F)
                {
                    node = new ExprNode(0);
                }
                else if (op.All(char.IsDigit))
                {
                    node = new ExprNode(int.Parse(op));
                }
                else
                {
                    node = new ExprNode(op);
                }
                phi.Add(node);
            }

            phi.ForEach(node => Console.Write(node.ToString() + " "));
            Console.WriteLine();
            return phi;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class State
    {

        #region
        public State(int id, string label)
        {
            this.id = id;
            this.labels = new HashSet<string>{ label };
        }

        public State(int id, HashSet<string> labels)
        {
            this.id = id;
            this.labels = labels;
            Console.WriteLine("s" + id + string.Join(" ", labels));
        }
        #endregion

        public int id;
        public HashSet<string> labels;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("s" + id + ": " + labels.Count + ": ");
            sb.Append(string.Join(" ", labels.ToArray()));
            return sb.ToString();
        }
    }

    /// <summary>
    /// Labeled transition systems (LTS). We constructed it from a queue
    /// </summary>
    class LTS
    {
        #region Constructors
        public LTS(List<string> Q)
        {
            this.BuilLTS(0, Q);
        }

        public LTS(int p, List<string> Q)
        {
            this.BuilLTS(p, Q);
        }
        #endregion

        #region Fields
        public State[] states;
        public List<int>[] transitions;
        public int initial;
        public int accepting;
        #endregion

        /// <summary>
        /// build the labelled transition system from an abstract queue
        /// </summary>
        /// <param name="p">the prefix of abstract queue </param>
        /// <param name="Q">the content of abstract queue</param>
        private void BuilLTS(int p, List<string> Q)
        {
            #region Initialization
            /// the number of events in the queue
            int k = Q.Count;
            int numOfStates = p + 2 * (k - p) + 1;
            this.transitions = new List<int>[numOfStates];
            this.states = new State[numOfStates];
            for (int i = 0; i < numOfStates; ++i)
            {
                transitions[i] = new List<int>();
                states[i] = null;
            }
            #endregion

            #region Handle the non-kleene star parts
            int stateID = 0; /// state stateID, increment
            this.initial = stateID;
            for (int i = 0; i <= Q.Count; ++i)
            {
                states[stateID] = new State(stateID, i < Q.Count ? Q[i] : "");
                if (i > 0)
                    transitions[stateID - 1].Add(stateID);
                ++stateID;
            }
            this.accepting = stateID; /// set up accepting state
            #endregion

            #region Handle the kleene star parts
            for (int i = p; i < Q.Count; ++i)
            {
                HashSet<string> labels = new HashSet<string>();
                for (int j = p; j <= i; ++j)
                {
                    labels.Add(Q[j]);
                }

                states[stateID] = new State(stateID, labels);
                transitions[i].Add(stateID);
                transitions[stateID].Add(stateID); // self loop
                transitions[stateID].Add(i + 1);

                ++stateID;
            }
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < states.Count(); ++i)
            {
                sb.Append(states[i].ToString());
                if (transitions[i] != null)
                    transitions[i].ForEach(s => sb.Append(" " + s));                
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class QuTLChecker
    {
        #region Constructors
        protected QuTLChecker()
        {

        }
        #endregion

        public static AstNode root;

        public static bool Check(string last, List<PrtEventNode> Q)
        {
#if true
            Console.WriteLine("---------- I am in QuTL model checker");
            // can't have just dequeued DONE and then there are still DONE's in the queue
            // This is not queue invariant but a transition invariant
            if (last == "DONE" && Q.Find(e => e.ev.ToString() == "DONE") != null)
            {
                Console.WriteLine("-------- state invariant is inviolated");
                return false;
            }

            for (int i = 0; i < Q.Count - 1; ++i)
            {
                var curr = Q[i    ].ev.ToString();
                var next = Q[i + 1].ev.ToString();

                // PING cannot be followed by WAIT
                if (curr == "PING" && next == "WAIT")
                {
                    Console.WriteLine("-------- queue invariant is inviolated");
                    return false;
                }
            }
#endif

#if false
            PrtImplMachine  Main  = implMachines[0]; 
            Debug.Assert( Main .eventQueue.is_abstract()); 
            List<PrtEventNode>  Main_q  =  Main .eventQueue.events;
            PrtImplMachine Client = implMachines[1]; 
            Debug.Assert(Client.eventQueue.is_abstract()); 
            List<PrtEventNode> Client_q = Client.eventQueue.events;

            Event_is_and_queue_contains event_is_and_queue_contains = delegate(PrtImplMachine m, string s)
            {
                List<PrtEventNode> q = m.eventQueue.events;
                return m.get_eventValue().ToString() == s && q.Find(ev => ev.ev.ToString() == s) != null;
            };

            // these lemmas state that none of the events in question occur more than once in the queue
            if (event_is_and_queue_contains(Main,   "req_share")      ||
                event_is_and_queue_contains(Main,   "req_excl")       ||
                event_is_and_queue_contains(Main,   "invalidate_ack") ||

                event_is_and_queue_contains(Client, "grant_share")    ||
                event_is_and_queue_contains(Client, "grant_excl")     ||
                event_is_and_queue_contains(Client, "ask_share")      ||
                event_is_and_queue_contains(Client, "ask_excl")       ||
                event_is_and_queue_contains(Client, "invalidate"))
                return false;
#endif
            return true;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="Q"></param>
        /// <returns></returns>
        public static bool AbstractCheck(int p, List<string> Q)
        {
            LTS lts = new LTS(p, Q);
            Console.WriteLine(lts.ToString());
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Q"></param>
        /// <returns></returns>
        private bool ConcreteCheck(List<string> Q)
        {
            return false;
        }

        public static void Print(AstNode root)
        {
            if (root == null)
                return;
            var node = root.enode;
            bool isPar = node.Type == AstNodeType.OPERATOR
                        && node.Operator == QuTLOperator.PARENTHSIS;
            if (isPar)
                Console.Write("(");

            if (root.right != null)
            {
                Print(root.left);
                Console.Write(" " + node.ToString() + " ");
                Print(root.right);
            }
            else
            {
                Console.Write(node.ToString() + " ");
                Print(root.left);
            }
            if (isPar)
                Console.Write(")");
        }
    }
}
