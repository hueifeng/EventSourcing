using Domain.Commands;
using Domain.Events;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Web.Domain;

namespace Web.Commands
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderRequestModel>
    {
        private readonly IEventBus _eventBus;

        public CreateOrderCommandHandler(IEventBus eventBus)
        { 
            this._eventBus = eventBus;
        }

        public async Task<Unit> Handle(CreateOrderRequestModel request, CancellationToken cancellationToken)
        {
            var order = new Order(Guid.NewGuid());
            await _eventBus.Publish(order.PendingEvents.ToArray());
            return Unit.Value;
        }
    }
}