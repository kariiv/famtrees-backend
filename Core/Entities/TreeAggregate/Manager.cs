namespace FamTrees.Core.Entities.TreeAggregate
{
    public class Manager
    {
        public Tree Tree { get; set; }
        public int TreeId { get; set; }
        public int UserId { get; set; }
        public TreeManagerType ManagerType { get; set; }
    }
}