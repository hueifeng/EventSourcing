using Domain.Repository.EventSourcing;
using Newtonsoft.Json;
using System;

namespace Domain.Events
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            this._eventStoreRepository = eventStoreRepository;
        }

        public void SaveAsync<T>(T theEvent,int version) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);
            var storedEvent = new StoredEvent
            {
                Data = serializedData,
                Id = Guid.NewGuid().ToString(),
                Type = theEvent.GetType().AssemblyQualifiedName,
                Timestamp = DateTime.Now,
                Version = version,
                AggregateId = theEvent.AggregateId
            };
            _eventStoreRepository.Store(storedEvent);
        }
    }
}