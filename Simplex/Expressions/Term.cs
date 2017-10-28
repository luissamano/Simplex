using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplex.Expressions
{
    public class Term : ExpressionBase
    {
        private Number _number;
        private Variable _variable;

        public Term()
            : base()
        {
        }
        public Term(ExpressionBase root)
            : base(root)
        {
        }

        public override double Value
        {
            get
            {
                return Math.Round(_number.Value * _variable.Value, Precision);
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public override double Coeficient(Variable v)
        {
            if (_variable.Equals(v))
            {
                return _number.Value;
            }
            return double.NaN;
        }
        public override string Parse(string expr)
        {
            try
            {
                _number = new Number(_root);
                expr = _number.Parse(expr);
                if (_number.Value == 0)
                {
                    throw new BadNumber(0);
                }
                _variable = new Variable(_root);
                return _variable.Parse(expr);
            }
            catch (BadSyntaxException)
            {
                throw;
            }
            catch
            {
                throw new BadSyntaxException(expr);
            }
        }
    }
}
