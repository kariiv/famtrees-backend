using System.Collections.Generic;
using FamTrees.Core.Events;

namespace FamTrees.Core.Entities
{
    // This can be modified to BaseEntity<TId> to support multiple key types (e.g. Uuid)
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public List<BaseDomainEvent> Events = new();
    }
}