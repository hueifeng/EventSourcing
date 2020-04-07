using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Commands;
using Domain.Events;
using MediatR;
using Web.Events;
using Web.Domain;

namespace Web.Commands
{
    public class CreateOrderCommandHandler:ICommandHandler<CreateOrderRequestModel>
    {
       
        private readonly IEventBus _eventBus;

        public CreateOrderCommandHandler(IEventBus eventBus)
        {
            this._eventBus = eventBus;
        }
        // public Task Handle(OrderCreated notification, CancellationToken cancellationToken)
        // {
        //     return _eventStore.SaveAsync(new[] {notification});
        //     // throw new System.NotImplementedException();
        // }
        public async Task<Unit> Handle(CreateOrderRequestModel request, CancellationToken cancellationToken)
        {
            var order = new Order(Guid.NewGuid().ToString());
            await _eventBus.Publish(order.PendingEvents.ToArray());
           return  Unit.Value;
        }
    }
}