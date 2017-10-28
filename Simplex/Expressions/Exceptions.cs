using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplex.Expressions
{
    public class NotRecognizedException : Exception
    {
    }
    public class BadSyntaxException : Exception
    {
        public BadSyntaxException(string text)
            : base(text)
        {
        }
    }
    public class DuplicateVariable : Exception
    {
        public DuplicateVariable(string text)
            : base(text)
        {
        }
    }
    public class BadNumber : Exception
    {
        public BadNumber(double n)
            : base(n.ToString())
        {
        }
    }
}
