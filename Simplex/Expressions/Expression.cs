using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplex.Expressions
{
    public class Expression : ExpressionBase
    {
        protected List<Term> _terms = new List<Term>();

        public Expression()
            : base()
        {
        }

        public override double Value
        {
            get
            {
                double val = 0;
                foreach (Term t in _terms)
                {
                    val += t.Value;
                }
                return Math.Round(val, Precision);
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public override string Parse(string expr)
        {
            _terms.Clear();
            string sexpr = base.Parse(expr);
            if (!string.IsNullOrEmpty(sexpr))
            {
                Term t0 = new Term(this);
                sexpr = t0.Parse(sexpr);
                _terms.Add(t0);
                sexpr = base.Parse(sexpr);
                while (!string.IsNullOrEmpty(sexpr) && !sexpr.StartsWith(":"))
                {
                    if ((sexpr[0] == '+') || (sexpr[0] == '-'))
                    {
                        if (sexpr.Length > 1)
                        {
                            if (sexpr[0] == '+')
                            {
                                sexpr = base.Parse(sexpr.Substring(1));
                            }
                            Term tn = new Term(this);
                            sexpr = base.Parse(tn.Parse(sexpr));
                            _terms.Add(tn);
                        }
                        else
                        {
                            throw new BadSyntaxException(sexpr);
                        }
                    }
                    else
                    {
                        throw new BadSyntaxException(sexpr);
                    }
                }
                return sexpr;
            }
            throw new NotRecognizedException();
        }

        public override double Coeficient(Variable v)
        {
            foreach (Term t in _terms)
            {
                double c = t.Coeficient(v);
                if (!double.IsNaN(c))
                {
                    return c;
                }
            }
            return 0;
        }
    }
}
