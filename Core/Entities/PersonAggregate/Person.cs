using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;
using FamTrees.Core.Entities.TreeAggregate;
using FamTrees.Core.Interfaces;

namespace FamTrees.Core.Entities.PersonAggregate
{
    public class Person : BaseEntity, IAggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DeathDate { get; set; }
        public Sex Sex { get; set; }
        public int TreeId { get; set; }
        public Tree Tree { get; set; }
        public List<PersonParent> PersonParents { get; set; }
        public List<PersonParent> PersonOfParents { get; set; }

        private Person()
        {
            // EF requirement
        }

        public Person(int treeId, string firstName, string lastName, Sex sex, DateTime birthday, DateTime deathDate)
        {
            Guard.Against.DateInFuture(birthday, nameof(birthday));
            Guard.Against.DateInFuture(deathDate, nameof(deathDate));

            try
            {
                DeathDate = Guard.Against.OutOfSQLDateRange(deathDate, nameof(deathDate));
                Guard.Against.DeadBeforeBorn(birthday, deathDate);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                DeathDate = default;
            }

            TreeId = Guard.Against.NegativeOrZero(treeId, nameof(treeId));
            FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
            LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            Birthday = Guard.Against.OutOfSQLDateRange(birthday, nameof(birthday));
            Sex = Guard.Against.UnknownSex(sex);
        }

        public void UpdateDetails(string firstName, string lastName, DateTime birthday, DateTime deathDate)
        {
            Guard.Against.DateInFuture(birthday, nameof(birthday));
            Guard.Against.DateInFuture(deathDate, nameof(deathDate));

            try
            {
                DeathDate = Guard.Against.OutOfSQLDateRange(deathDate, nameof(deathDate));
                Guard.Against.DeadBeforeBorn(birthday, deathDate);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                DeathDate = default;
            }

            FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
            LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            Birthday = Guard.Against.OutOfSQLDateRange(birthday, nameof(birthday));
        }

        public override string ToString()
        {
            return $"{Id}: FirstName: {FirstName} {LastName}, ({Birthday})";
        }
    }
}