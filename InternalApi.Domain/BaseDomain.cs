using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternalApi.Domain
{
    public abstract class BaseDomain : IDomainEntity
    {
        public List<IDomainEvent> DomainEvents { get; } = new List<IDomainEvent>();
        public void QueueEvent(IDomainEvent @event)
        {
            DomainEvents.Add(@event);
        }

        public void RaiseEvent(IDomainEvent @event)
        {
            DomainEvents.Insert(0, @event);
        }

        // public void UpdateCreationProperties(DateTime createdOn, string createdBy)
        // {
        //     throw new NotImplementedException();
        // }

        // public void UpdateIsDeleted(bool isDeleted)
        // {
        //     throw new NotImplementedException();
        // }

        // public void UpdateModifiedProperties(DateTime? lastModifiedOn, string lastModifiedBy)
        // {
        //     throw new NotImplementedException();
        // }
    }
}