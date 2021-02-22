using System;

namespace FamTrees.Core.Exceptions
{
    public class PersonHasParentsException : Exception
    {
        public PersonHasParentsException(string message) : base(message)
        {

        }
    }
}
