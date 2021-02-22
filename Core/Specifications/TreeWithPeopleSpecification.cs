using Ardalis.Specification;
using FamTrees.Core.Entities.TreeAggregate;

namespace FamTrees.Core.Specifications
{
    public class TreeWithPeopleSpecification : Specification<Tree>
    {
        public TreeWithPeopleSpecification(int treeId)
        {
            Query.Where(i => i.Id == treeId)
                .Include(tp => tp.People);
        }
    }
}
