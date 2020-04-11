using System;
using MediatR;

namespace Domain.Events
{
    public class Event:INotification
    {
        public Guid AggregateId { get; protected set; }
    }
}