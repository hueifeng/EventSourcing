using Domain.Events;
using System;

namespace Web.Events
{
    public class OrderCreated: Event
    {
        public string UserId { get; set; }

        public string Remark { get; set; }
        public Guid Id { get; set; }

        public OrderCreated(Guid id,string userId,string remark)
        {
            this.UserId = userId;
            this.Remark = remark;
            this.Id = Guid.NewGuid();
            this.AggregateId = id;
        }
    }
}