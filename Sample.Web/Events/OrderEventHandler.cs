using System.Threading;
using System.Threading.Tasks;
using Domain.Events;

namespace Web.Events
{
    public class OrderEventHandler :
        IEventHandler<OrderCreated>
    {
    
        public Task Handle(OrderCreated notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}