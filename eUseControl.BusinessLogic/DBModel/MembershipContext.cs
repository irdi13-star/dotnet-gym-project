using System;
using eUseControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eUseControl.BusinessLogic.DBModel
{
    public class MembershipContext : DbContext
    {
        public MembershipContext()
        {
        }
        
        public MembershipContext(DbContextOptions<MembershipContext> options) : base(options)
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
            modelBuilder.Entity<MDbTable>().ToTable("Memberships");
        }
        
        public DbSet<MDbTable> Memberships { get; set; }
    }
}
