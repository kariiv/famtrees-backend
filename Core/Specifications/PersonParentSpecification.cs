using Ardalis.Specification;
using FamTrees.Core.Entities.PersonAggregate;

namespace FamTrees.Core.Specifications
{
    public class PersonParentSpecification : Specification<PersonParent>
    {
        public PersonParentSpecification(int personId)
        {
            Query.Where(i => i.PersonId == personId)
                .Include(p => p.Parent);
        }
        public PersonParentSpecification(int personId, int parentId)
        {
            Query.Where(i => i.PersonId == personId && i.ParentId == parentId);
        }
    }
}