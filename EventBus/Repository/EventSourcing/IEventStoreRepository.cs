using System;
using System.Collections.Generic;

namespace Domain.Repository.EventSourcing
{
    public interface IEventStoreRepository: IDisposable
    {
        void Store(string data);
        IList<string> All(Guid aggregateId);
    }
}
