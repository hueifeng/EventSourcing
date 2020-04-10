using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Context;

namespace Domain.Repository.EventSourcing
{
    public class EventStoreSqlRepository : IEventStoreRepository
    {
        private readonly EventStoreSQLContext _context;

        public EventStoreSqlRepository(EventStoreSQLContext context)
        {
            this._context = context;
        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            return (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Store(StoredEvent data)
        {
            _context.StoredEvent.Add(data);
            _context.SaveChanges();

        }
    }
}
