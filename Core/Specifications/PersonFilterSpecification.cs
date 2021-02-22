using System.Linq;
using Ardalis.Specification;
using FamTrees.Core.Entities.PersonAggregate;

namespace FamTrees.Core.Specifications
{
    class PersonFilterSpecification : Specification<Person>
    {
        public PersonFilterSpecification(params  int[] ids)
        {
            Query.Where(p => ids.Contains(p.Id));
        }
    }
}
