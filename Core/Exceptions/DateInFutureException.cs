using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamTrees.Core.Exceptions
{
    public class DateInFutureException : Exception
    {
        public DateInFutureException(string message) : base(message)
        {
        }
    }
}
