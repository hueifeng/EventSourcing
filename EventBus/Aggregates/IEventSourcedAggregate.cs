using System.Collections.Generic;
using Domain.Events;

namespace Domain
{
    public interface IEventSourcedAggregate: IAggregates
    {
        Queue<IEvent> PendingEvents { get; }
    }
}