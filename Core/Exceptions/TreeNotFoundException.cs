using System;

namespace FamTrees.Core.Exceptions
{
    public class TreeNotFoundException : Exception
    {
        public TreeNotFoundException(int treeId) : base($"No tree found with id {treeId}")
        {
        }
        public TreeNotFoundException(string message) : base(message)
        {
        }
    }
}
