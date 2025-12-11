using eUseControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eUseControl.BusinessLogic.DBModel
{
    public class DiscountContext : DbContext
    {
        public DiscountContext()
        {
        }
        
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
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
            modelBuilder.Entity<DiscountDbTable>().ToTable("DiscountCodes");
        }
        
        public DbSet<DiscountDbTable> DiscountCodes { get; set; }
    }
}
