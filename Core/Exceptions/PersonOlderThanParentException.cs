using System;

namespace FamTrees.Core.Exceptions
{
    public class PersonOlderThanParentException : Exception
    {
        public PersonOlderThanParentException(string message) : base(message)
        {

        }
    }
}
