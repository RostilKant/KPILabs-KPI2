using AirplaneTicketService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneTicketService.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {
            modelBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PlaneTickets;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder?.Entity<Employee>().HasNoKey();
        }
    }
}
