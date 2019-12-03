using AirplaneTicketService.Data;
using AirplaneTicketService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneTicketService.Repositories
{
    public class TicketRepository : IRepository<Ticket>
    {
        ApplicationContext context;
        public TicketRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<Ticket> Create(Ticket ticket)
        {
            if (context != null)
            {
                await context.Tickets.AddAsync(ticket);
                await context.SaveChangesAsync().ConfigureAwait(false);

                return ticket;
            }
            return null;
        }

        public async Task<int> Delete(int id)
        {
            int result = 0;
            if (context != null)
            {
                var ticket = await context.Tickets.FirstOrDefaultAsync(c => c.TicketId == id).ConfigureAwait(false);
                if (ticket != null)
                {
                    context.Tickets.Remove(ticket);
                    result = await context.SaveChangesAsync().ConfigureAwait(false);
                }
                return result;
            }
            return 0;
        }

        public async Task<Ticket> Retrieve(int id)
        {
            if (context != null)
            {
                var ticket = await context.Tickets.FirstOrDefaultAsync(c => c.TicketId == id).ConfigureAwait(false);
                if (ticket != null)
                {
                    await context.Tickets.FindAsync(id);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
                return ticket;
            }
            return null;
        }

        public async Task<List<Ticket>> RetrieveAll()
        {
            if (context != null)
            {
                return await context.Tickets.ToListAsync().ConfigureAwait(false);
            }
            return null;
        }
        public async Task<List<Ticket>> GetTicketsWithFlight()
        {
            if (context != null)
            {
                var tickets = await (from m in context.Tickets
                                     from t in context.Flights
                                     where m.FlightId == t.FlightId
                                     select new Ticket
                                     {
                                         TicketId = m.TicketId,
                                         Status = m.Status,
                                         Price = m.Price,
                                         Class = m.Class,
                                         Row = m.Row,
                                         Column = m.Column,
                                         Flight = new Flight
                                         {
                                             ArriveAirport = t.ArriveAirport,
                                             DepartureAirport = t.DepartureAirport,
                                             DepartureGate = t.DepartureGate,
                                             Status = t.Status
                                         }
                                     }).ToListAsync().ConfigureAwait(false);
                
                return tickets;
            }
            return null;
        }

        public async Task Update(Ticket ticket)
        {
            if (context != null)
            {
                context.Tickets.Update(ticket);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
