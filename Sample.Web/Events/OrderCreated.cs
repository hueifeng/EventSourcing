using Domain.Events;
using System;

namespace Web.Events
{
    public class OrderCreated: IEvent
    {
        public string UserId { get; set; }

        public string Remark { get; set; }
        public Guid Id { get; set; }

        public OrderCreated(Guid Id,string userId,string remark)
        {
            this.UserId = userId;
            this.Remark = remark;
            this.Id = Id;
            this.AggregateId = Id;
        }
        public int Version { get; set; }
        public string AggregateType { get; set; }
        public Guid AggregateId { get; set; }
    }
}