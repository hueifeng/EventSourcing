using System.Threading.Tasks;
using MediatR;

namespace Domain.Events
{
    public class EventBus:IEventBus
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;
        
        public EventBus(IMediator mediator,IEventStore eventStore)
        {
            _mediator = mediator;
            _eventStore = eventStore;
        }
        public async Task Publish<TEvent>(params TEvent[] events) where TEvent : IEvent
        {
            foreach (var @event in events)
            {
                await _mediator.Publish(@event);
            }
        }
        
        public Task RaiseEvent<TEvent>(TEvent @event) where TEvent : IEvent
        {
             _eventStore.SaveAsync(@event);
             return Task.CompletedTask;
             //return Publish(@event);
        }
    }
}