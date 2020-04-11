using System;
using Domain;
using Domain.Aggregates;
using Web.Events;

namespace Web.Domain
{
    public class Order:EventSourcedAggregate
    {

        public Order(Guid id)
        {
            for (int i = 0; i < 2; i++)
            {
                var @event = new OrderCreated(id, "1", "remark");
                Enqueue(@event);
            }
        }

    }
}