using System;
using System.Collections.Generic;

namespace InternalApi.Domain
{
    public interface IDomainEntity
    {
        public List<IDomainEvent> DomainEvents { get; }
        void QueueEvent(IDomainEvent @event);
        void RaiseEvent(IDomainEvent @event);
        // void UpdateCreationProperties(DateTime createdOn, string createdBy);
        // void UpdateModifiedProperties(DateTime? lastModifiedOn, string lastModifiedBy);
        // void UpdateIsDeleted(bool isDeleted);
        
    }
}