using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;
using FamTrees.Core.Entities.PersonAggregate;
using FamTrees.Core.Interfaces;

namespace FamTrees.Core.Entities.TreeAggregate
{
    public class Tree : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public TreeState TreeState { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Person> People { get; set; }

        private Tree()
        {
            // EF requirement
        }

        public Tree(string name)
        {
            Name = name;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateDetails(string name)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
        }
    }
}