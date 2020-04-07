using System.Threading.Tasks;
using MediatR;

namespace Domain.Events
{
    public interface IEvent:INotification
    {
        int Version { get; set; }
        string AggregateType { get; set; }
    }
}