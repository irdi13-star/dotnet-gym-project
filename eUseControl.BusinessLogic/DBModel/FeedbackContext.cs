using eUseControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eUseControl.BusinessLogic.DBModel
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext()
        {
        }
        
        public FeedbackContext(DbContextOptions<FeedbackContext> options) : base(options)
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
            modelBuilder.Entity<FeedbackDbTable>().ToTable("Feedbacks");
        }
        
        public DbSet<FeedbackDbTable> Feedbacks { get; set; }
    }
}
