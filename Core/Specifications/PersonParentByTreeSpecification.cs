using Ardalis.Specification;
using FamTrees.Core.Entities.PersonAggregate;

namespace FamTrees.Core.Specifications
{
    public class PersonParentByTreeSpecification : Specification<PersonParent>
    {
        public PersonParentByTreeSpecification(int treeId)
        {
            Query.Include(tp => tp.Person)
                .Where(i => i.Person.TreeId == treeId);
        }
    }
}
