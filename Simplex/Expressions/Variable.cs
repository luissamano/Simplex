using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplex.Expressions
{
    public class Variable : ExpressionBase, IComparable<Variable>, IEquatable<Variable>
    {
        private double _value = double.NaN;
        private string _name = null;

        public Variable()
            : base()
        {
        }
        public Variable(ExpressionBase root)
            : base(root)
        {
        }

        public override double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        public override string Parse(string expr)
        {
            string svar = base.Parse(expr);
            if (!string.IsNullOrEmpty(svar))
            {
                if ((char.ToLower(svar[0]) >= 'a') && (char.ToLower(svar[0]) <= 'z'))
                {
                    _name = svar.Substring(0, 1).ToLower();
                    if (svar.Length > 1)
                    {
                        svar = RVar(svar.Substring(1));
                    }
                    else
                    {
                        svar = "";
                    }
                    if (_root.Variables.Contains(this))
                    {
                        throw new DuplicateVariable(_name);
                    }
                    else
                    {
                        _root.Variables.Add(this);
                    }
                    return svar;
                }
            }
            throw new NotRecognizedException();
        }
        public int CompareTo(Variable other)
        {
            return string.Compare(_name, other._name, true);
        }
        public bool Equals(Variable other)
        {
            return string.Compare(_name, other._name, true) == 0;
        }
        public override string ToString()
        {
            return _name;
        }
        private string RVar(string expr)
        {
            if (char.IsLetterOrDigit(expr, 0))
            {
                _name += expr.Substring(0, 1).ToLower();
                if (expr.Length > 1)
                {
                    return RVar(expr.Substring(1));
                }
                expr = "";
            }
            return expr;
        }
    }
}
