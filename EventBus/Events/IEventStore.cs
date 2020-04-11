using System;

namespace Domain.Events
{
    public interface IEventStore
    {
        void SaveAsync<T>(T theEvent, int version) where T : Event;
    }
}