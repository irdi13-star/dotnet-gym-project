using System;
using Microsoft.EntityFrameworkCore;
using eUseControl.Domain.Entities;

namespace eUseControl.BusinessLogic.DBModel
{
    public class CoachContext : DbContext
    {
        public CoachContext()
        {
        }

        public CoachContext(DbContextOptions<CoachContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=eUseControl.db");
            }
        }

        public virtual DbSet<Coach> Coaches { get; set; }
    }
}
