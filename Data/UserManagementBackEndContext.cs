using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserManagementBackEnd.Models;


namespace UserManagementBackEnd.Data
{
    public class UserManagementBackEndContext : DbContext
    {
        public UserManagementBackEndContext (DbContextOptions<UserManagementBackEndContext> options)
            : base(options)
        {
        }

        public DbSet<UserManagementBackEnd.Models.Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Province> Province { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DbSeederExtensions dbSeeding = new DbSeederExtensions(modelBuilder);
        }
    }
}
