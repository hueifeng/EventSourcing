using System.Threading.Tasks;
using MediatR;

namespace Domain.Events
{
    public class EventBus : IEventBus
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public EventBus(IMediator mediator, IEventStore eventStore)
        {
            _mediator = mediator;
            _eventStore = eventStore;
        }
        public Task Publish<TEvent>(params TEvent[] events)
        {
            var i = 0;
            foreach (var @event in events)
            {
                _mediator.Publish(@event);
                if (@event is Event eEvent)
                {
                    _eventStore.SaveAsync(eEvent,i++);
                }
            }
            return Task.CompletedTask;
        }

    }
}