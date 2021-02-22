using Ardalis.GuardClauses;
using FamTrees.Core.Interfaces;

namespace FamTrees.Core.Entities.PersonAggregate
{
    public class PersonParent : BaseEntity, IAggregateRoot
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int ParentId { get; set; }
        public Person Parent { get; set; }

        private PersonParent()
        {
            // Ef requirement
        }

        public PersonParent(Person person, Person parent)
        {
            Guard.Against.KidOlderThanParent(person.Birthday, parent.Birthday);

            PersonId = Guard.Against.NegativeOrZero(person.Id, nameof(person.Id));
            ParentId = Guard.Against.NegativeOrZero(parent.Id, nameof(parent.Id));
        }
    }
}
