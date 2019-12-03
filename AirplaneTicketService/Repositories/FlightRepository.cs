using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirplaneTicketService.Data;
using AirplaneTicketService.Models;
using Microsoft.EntityFrameworkCore;

namespace AirplaneTicketService.Repositories
{
    public class FlightRepository : IRepository<Flight>
    {
        ApplicationContext context;
        public FlightRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<Flight> Create(Flight flight)
        {
            if (context != null)
            {
                await context.Flights.AddAsync(flight);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return flight;
            }
            return null; 
        }

        public async Task<int> Delete(int id)
        {
            int result = 0;
            if (context != null)
            {
                var nFLight = context.Flights.FirstOrDefault(f => f.FlightId == id);
                if (nFLight != null)
                {
                    context.Flights.Remove(nFLight);
                    result = await context.SaveChangesAsync().ConfigureAwait(false);
                    return result;
                }
            }
            return result; 

        }

        public async Task<Flight> Retrieve(int id)
        {
            if (context != null)
            {
                var nFlight = context.Flights.FirstOrDefault(f => f.FlightId == id);
                if(nFlight != null)
                {
                    await context.Flights.FindAsync(id);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                    return nFlight;
                }
               
            }
            return null;
        }

        public async Task<List<Flight>> RetrieveAll()
        {
            if(context != null)
            {
                return await context.Flights.ToListAsync().ConfigureAwait(false);
            }
            return null;
        }

        public async Task<List<Flight>> GetFlightsByDeparture(string airport)
        {
            if(context != null)
            {
                var flights = from f in context.Flights
                              select f;
                if (!String.IsNullOrEmpty(airport))
                {
                    flights = flights.Where(f => f.DepartureAirport.Contains(airport));
                    return await flights.ToListAsync().ConfigureAwait(false);
                }
            }
            return null;
        }

        public async Task Update(Flight flight)
        {
            if (context != null)
            {
                context.Flights.Update(flight);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
