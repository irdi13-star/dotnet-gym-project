using System;
using System.Collections.Generic;
using eUseControl.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.DBModel
{
    public class UserContext : DbContext 
    {
        public UserContext()
        {
        }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=eUseControl.db");
            }
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserMembership> UserMemberships { get; set; }
    }
}
