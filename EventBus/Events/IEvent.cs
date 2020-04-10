using System;
using System.Threading.Tasks;
using MediatR;

namespace Domain.Events
{
    public interface IEvent:INotification
    {
        Guid AggregateId { get; set; }
        int Version { get; set; }
        string AggregateType { get; set; }
    }
}