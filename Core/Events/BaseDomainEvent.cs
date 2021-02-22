using System;
using MediatR;

namespace FamTrees.Core.Events
{
    public abstract class BaseDomainEvent : INotification
    {
        public DateTime DateOccured { get; protected set; } = DateTime.UtcNow;
    }
}