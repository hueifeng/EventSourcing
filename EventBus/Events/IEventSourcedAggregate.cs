using System.Collections.Generic;

namespace Domain.Events
{
    public interface IEventSourcedAggregate:IAggregates
    {
        Queue<IEvent> PendingEvents { get;}
    }
}