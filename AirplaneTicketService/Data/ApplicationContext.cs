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
        //public DbSet<Employee> Employees { get; set; }
        public DbSet<Flight> Flights { get; set; }
        //public DbSet<FlightDetails> FlightDetails { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        //public DbSet<TicketDetails> TicketDetails { get; set; }
        public DbSet<Client> Clients { get; set; }
       // public DbSet<Registration> Registrations { get; set; }
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {
            modelBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PlaneTickets;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder?.Entity<Employee>().HasNoKey();
            //modelBuilder?.Entity<FlightDetails>().HasNoKey();
            //modelBuilder?.Entity<TicketDetails>().HasNoKey();
            //modelBuilder?.Entity<Client>().HasAlternateKey(k => new { k.PassportSerial, k.PassportNumber });
            //modelBuilder?.Entity<Flight>().HasKey(k => k.FlightId);
            //modelBuilder?.Entity<Plane>().HasKey(k => k.PlaneId);
            //modelBuilder?.Entity<Ticket>().HasKey(k => k.TicketId);
            //modelBuilder?.Entity<Client>().HasKey(k => k.ClientId);

        }
    }
}
