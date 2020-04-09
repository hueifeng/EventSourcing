using System;
using Domain.Repository.EventSourcing;
using System.Text.Json;

namespace Domain.Events
{
    public class SqlEventStore:IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            this._eventStoreRepository = eventStoreRepository;
        }
        
        public void SaveAsync<T>(T theEvent) where T : IEvent
        {
            var serializedData = JsonSerializer.Serialize(theEvent);
            var storedEvent=new StoredEvent()
            {
              Data = serializedData,
              Id = Guid.NewGuid().ToString()
            };
            _eventStoreRepository.Store(storedEvent);
        }
    }
}