using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository.EventSourcing
{
    public class EventStoreSqlRepository : IEventStoreRepository
    {
        public IList<string> All(Guid aggregateId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Store(string data)
        {
            throw new NotImplementedException();
        }
    }
}
