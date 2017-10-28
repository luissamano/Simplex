using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplex.Expressions
{
    public class Number : ExpressionBase
    {
        private double _value = double.NaN;
        private int _decimalpos = 0;
        private int _sign = 1;

        public Number()
            : base()
        {
        }
        public Number(ExpressionBase root)
            : base(root)
        {
        }

        public override double Value
        {
            get
            {
                return Math.Round(_value * _sign, Precision);
            }
            set
            {
                throw new NotSupportedException();
            }
        }
        public override string Parse(string expr)
        {
            string snum = base.Parse(expr);
            if (string.IsNullOrEmpty(snum))
            {
                throw new NotRecognizedException();
            }
            if ((snum[0] == '-') || (snum[0] == '+'))
            {
                if (snum[0] == '-')
                {
                    _sign = -1;
                }
                if (snum.Length > 1)
                {
                    snum = base.Parse(snum.Substring(1));
                }
                else
                {
                    throw new BadSyntaxException(snum);
                }                
            }
            if (char.IsNumber(snum, 0))
            {
                _value = Convert.ToDouble(snum[0].ToString());
                if (snum.Length > 1)
                {
                    return RNumber(snum.Substring(1));
                }
                return "";
            }
            else if ((snum[0] == ',') || (snum[0] == '.'))
            {
                if (snum.Length > 1)
                {
                    _value = 0;
                    _decimalpos = 1;
                    return RDecimal(snum.Substring(1));
                }
                throw new BadSyntaxException(snum);
            }
            _value = 1;
            return snum;
        }
        public override string ToString()
        {
            return _value.ToString();
        }
        private string RNumber(string expr)
        {
            if (char.IsNumber(expr, 0))
            {
                _value = Math.Round((10 * _value) + Convert.ToDouble(expr[0].ToString()), Precision);
                if (expr.Length > 1)
                {
                    return RNumber(expr.Substring(1));
                }
                return "";
            }
            else if ((expr[0] == ',') || (expr[0] == '.'))
            {
                if (expr.Length > 1)
                {
                    _decimalpos = 1;
                    return RDecimal(expr.Substring(1));
                }
                throw new BadSyntaxException(expr);
            }
            return expr;
        }
        private string RDecimal(string expr)
        {
            if (char.IsNumber(expr, 0))
            {
                _value += Math.Round(Convert.ToDouble(expr[0].ToString()) / (10 * _decimalpos), Precision);
                _decimalpos++;
                if (expr.Length > 1)
                {
                    return FDecimal(expr.Substring(1));
                }
                return "";
            }
            throw new BadSyntaxException(expr);
        }
        private string FDecimal(string expr)
        {
            if (char.IsNumber(expr, 0))
            {
                _value += Math.Round(Convert.ToDouble(expr[0].ToString()) / (10 * _decimalpos), Precision);
                _decimalpos++;
                if (expr.Length > 1)
                {
                    return FDecimal(expr.Substring(1));
                }
                return "";
            }
            return expr;
        }
    }
}
