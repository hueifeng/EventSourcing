using System;

namespace Domain
{
    public class StoredEvent
    {
        public string Id { get; set; }
        public string AggregateId { get; set; }
        public string MessageType { get; set; }
        public string Data { get; set; }
        public string User { get; set; }
        public DateTime Timestamp { get; private set; }
    }
}