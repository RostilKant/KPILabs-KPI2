using AirplaneTicketService.Data;
using AirplaneTicketService.NewFolder;
using AirplaneTicketService.Persistance;
using AirplaneTicketService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneTicketService.Controllers
{
    public class UnityOfWork : IDisposable
    {
        ApplicationContext context;
        PlaneRepository plane;
        ClientRepository client;
        FlightRepository flight;
        TicketRepository ticket;
        public UnityOfWork(ApplicationContext context)
        {
            this.context = context;
        }
        public PlaneRepository Planes
        {
            get
            {
                if (plane == null)
                {
                    plane = new PlaneRepository(context);
                }
                return plane;
            }
        }
        public ClientRepository Clients
        {
            get
            {
                if(client == null)
                {
                    client = new ClientRepository(context);
                }
                return client;
            }
        }
        public FlightRepository Flights
        {
            get
            {
                if (flight == null)
                {
                    flight = new FlightRepository(context);
                }
                return flight;
            }
        }
        public TicketRepository Tickets
        {
            get
            {
                if (ticket == null)
                {
                    ticket = new TicketRepository(context);
                }
                return ticket;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
