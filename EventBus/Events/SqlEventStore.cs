namespace Domain.Events
{
    public class SqlEventStore:IEventStore
    {
        public void SaveAsync<T>(T theEvent) where T : IEvent
        {
            throw new System.NotImplementedException();
        }
    }
}