using Domain.Events;
using System;
using System.Collections.Generic;

namespace Domain.Aggregates
{
    public class EventSourcedAggregate: IEventSourcedAggregate
    {
        public Guid Id { get;protected set;}
        public Queue<Event> PendingEvents { get; private set; }

        public int Version { get; protected set; }

        protected EventSourcedAggregate()
        {
            PendingEvents = new Queue<Event>();
        }
        protected void Dequeue()
        {
            PendingEvents.Dequeue();
        }


        protected void Enqueue(Event @event)
        {
            Version++;
            PendingEvents.Enqueue(@event);
        }

    }
}