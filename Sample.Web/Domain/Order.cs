using System;
using Domain;
using Web.Events;

namespace Web.Domain
{
    public class Order:EventSourcedAggregate
    {
        public string Id { get; set; }

        public Order(string id)
        {
            this.Id = id;
            Append(new OrderCreated(Guid.NewGuid(), id,"remark"));
        }
    }
}