using System.Threading;
using System.Threading.Tasks;
using Domain.Events;

namespace Web.Events
{
    public class OrderEventHandler:
        IEventHandler<OrderCreated>
    {
        private readonly IEventStore _eventStore;

        public OrderEventHandler(IEventStore eventStore)
        {
            this._eventStore = eventStore;
        }
        public Task Handle(OrderCreated notification, CancellationToken cancellationToken)
        {
            _eventStore.SaveAsync(notification);
             return Task.CompletedTask;
        }
    }
}