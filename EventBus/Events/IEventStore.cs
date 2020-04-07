namespace Domain.Events
{
    public interface IEventStore
    {
        void SaveAsync<T>(T theEvent) where T : IEvent;
    }
}