using System;
using NoobStore.Core.Messages;

namespace NoobStore.Core.DomainObjects
{
    public class DomainEvent : Evento
    {
        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}