using System;
using NerdStore.Core.Messages;

namespace NerdStore.Core.DomainObject
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}