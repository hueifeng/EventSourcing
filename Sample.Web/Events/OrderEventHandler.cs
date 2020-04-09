using System.Threading;
using System.Threading.Tasks;
using Domain.Events;

namespace Web.Events
{
    public class OrderEventHandler:
        IEventHandler<OrderCreated>
    {
        private readonly IEventStore _eventStore;
        private readonly IEventBus _bus;
        public OrderEventHandler(IEventStore eventStore,IEventBus bus)
        {
            this._eventStore = eventStore;
            this._bus = bus;
        }
        public Task Handle(OrderCreated notification, CancellationToken cancellationToken)
        {
            //_eventStore.SaveAsync(notification);
            _bus.RaiseEvent(notification);
             return Task.CompletedTask;
        }
    }
}