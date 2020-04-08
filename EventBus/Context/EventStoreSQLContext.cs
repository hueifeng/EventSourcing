using Microsoft.EntityFrameworkCore;

namespace Domain.Context
{
    public class EventStoreSQLContext: DbContext
    {
        public EventStoreSQLContext(DbContextOptions<EventStoreSQLContext> options):base(options) { }
    }
}
