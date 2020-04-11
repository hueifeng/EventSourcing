using System;

namespace Domain
{
    public class StoredEvent
    {
        public string Id { get; set; }
        public Guid AggregateId { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public DateTime Timestamp { get; set; }
        public int Version { get; set; }
    }
}