using System;
using eUseControl.Domain.Entities.EventTable;
using Microsoft.EntityFrameworkCore;

namespace eUseControl.BusinessLogic.DBModel
{
    public class EventContext : DbContext
    {
        public EventContext()
        {
        }
        
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=eUseControl.db");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventTable>().ToTable("Events");
        }
        
        public virtual DbSet<EventTable> Events { get; set; }
    }
}
