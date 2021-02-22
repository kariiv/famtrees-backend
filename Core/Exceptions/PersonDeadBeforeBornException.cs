using System;

namespace FamTrees.Core.Exceptions
{
    public class PersonDeadBeforeBornException : Exception
    {
        public PersonDeadBeforeBornException() : base("Person date of death can not be before birthday")
        {
        }
    }
}
