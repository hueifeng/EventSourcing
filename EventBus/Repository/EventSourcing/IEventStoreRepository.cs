using System;
using System.Collections.Generic;

namespace Domain.Repository.EventSourcing
{
    public interface IEventStoreRepository: IDisposable
    {
        void Store(StoredEvent data);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
