using Microsoft.EntityFrameworkCore;

namespace Domain.Context
{
    public class EventStoreSQLContext: DbContext
    {
        public EventStoreSQLContext(DbContextOptions<EventStoreSQLContext> options):base(options) { }
        public DbSet<StoredEvent> StoredEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<StoredEvent>()
            //     .Property(c => c.Timestamp)
            //     .HasField("CreationDate");
            //
            // modelBuilder.Entity<StoredEvent>()
            //     .Property(c => c.MessageType)
            //     .HasField("Action");
        }

    }
}
