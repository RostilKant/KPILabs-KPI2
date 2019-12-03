using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplier1
{
    public class FSupplierContext : DbContext
    {
        public FSupplierContext(DbContextOptions<FSupplierContext> options)
          : base(options)
        {

        }
        //public DbSet<Flight> Flights { get; set; }
        
        public DbSet<Ticket> Tickets { get; set; }
        public FSupplierContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {
            modelBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TicketSupplier1;Trusted_Connection=True;");
        }

    }
}
