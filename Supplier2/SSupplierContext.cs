using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplier2
{
    public class SSupplierContext : DbContext
    {
        public SSupplierContext(DbContextOptions<SSupplierContext> options)
          : base(options)
        {

        }
        //public DbSet<Flight> Flights { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
        public SSupplierContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {
            modelBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TicketSupplier2;Trusted_Connection=True;");
        }
    }
}
