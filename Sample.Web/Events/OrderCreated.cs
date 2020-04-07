using Domain.Commands;
using Domain.Events;

namespace Web.Events
{
    public class OrderCreated: IEvent
    {
        public string UserId { get; set; }

        public string Remark { get; set; }

        public OrderCreated(string userId,string remark)
        {
            this.UserId = userId;
            this.Remark = remark;
        }
        public int Version { get; set; }
        public string AggregateType { get; set; }
    }
}