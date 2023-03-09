using System;

namespace FamTrees.Core.Exceptions
{
    public class DateInFutureException : Exception
    {
        public DateInFutureException(string message) : base(message)
        {
        }
    }
}
