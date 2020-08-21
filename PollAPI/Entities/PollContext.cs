using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAPI.Entities
{
    public class PollContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=PollDb;Trusted_Connection=True;";

        public DbSet<Poll> Polls { get; set; }
        public DbSet<Option> Options { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Poll>().HasMany(m => m.Options).WithOne(l => l.Poll);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
