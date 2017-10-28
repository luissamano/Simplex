using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplex.Expressions
{
    public class ExConstraint : Expression
    {
        private Number _restriction;

        public ExConstraint()
        {
        }

        public override double Value
        {
            get
            {
                return _restriction.Value;
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public override string Parse(string expr)
        {
            string sexpr = base.Parse(expr);
            if ((!sexpr.StartsWith(":")) || (sexpr.Length < 2))
            {
                throw new BadSyntaxException(sexpr);
            }
            _restriction = new Number();
            sexpr = _restriction.Parse(sexpr.Substring(1));
            if (_restriction.Value == 0)
            {
                throw new BadNumber(0);
            }
            return sexpr;
        }
    }
}
