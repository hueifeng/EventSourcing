using System.Threading.Tasks;

namespace Domain.Events
{
    public interface IEventBus
    {
        Task Publish<TEvent>(params TEvent[] events)where TEvent:IEvent;
        Task RaiseEvent<TEvent>(TEvent @event) where TEvent:IEvent;
    }
}