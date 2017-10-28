using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplex.Expressions
{
    public abstract class ExpressionBase
    {
        protected static int _precision = 10;
        protected List<Variable> _variables;
        protected ExpressionBase _root;

        public ExpressionBase()
        {
            _variables = new List<Variable>();
            _root = this;
        }
        public ExpressionBase(ExpressionBase root)
        {
            _root = root;
        }
        public static int Precision
        {
            get
            {
                return ExpressionBase._precision;
            }
            set
            {
                ExpressionBase._precision = Math.Min(20, Math.Max(1, value));
            }
        }
        public List<Variable> Variables
        {
            get
            {
                _variables.Sort();
                return _variables;
            }
            set
            {
                _variables = value;
            }
        }
        public void Clear()
        {
            _variables.Clear();
        }
        public abstract double Value { get; set; }
        public virtual double Coeficient(Variable v)
        {
            return 0;
        }
        public virtual string Parse(string expr)
        {
            return expr.TrimStart(new char[] { ' ', '\n', '\r', '\t' });
        }
    }
}