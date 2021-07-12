using Microsoft.EntityFrameworkCore;
using PrApplication00.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrApplication00.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DataContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testdb;Username=postgres;Password=sa");
        }
    }


}
