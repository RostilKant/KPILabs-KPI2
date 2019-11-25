using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirplaneTicketService.Data;
using AirplaneTicketService.Models;
using Microsoft.EntityFrameworkCore;

namespace AirplaneTicketService.NewFolder
{
    public class Client : IClient
    {
        ApplicationContext context;
        public Client(ApplicationContext _context)
        {
            context = _context;
        }
        public async Task<Models.Client> AddClient(Models.Client client)
        {
            if (context != null)
            {
                await context.Clients.AddAsync(client);
                await context.SaveChangesAsync().ConfigureAwait(false);

                return client;
            }
            return null;
        }

        public async Task<int> DeleteClient(int? id)
        {
            int result = 0;
            if (context != null)
            {
                var client = await context.Clients.FirstOrDefaultAsync(c => c.ClientId == id).ConfigureAwait(false);
                if (client != null)
                {
                    context.Clients.Remove(client);
                    result = await context.SaveChangesAsync().ConfigureAwait(false);
                }
                return result;
            }
            return 0;
        }

        public async Task<Models.Client> GetClient(int? id)
        {
            if (context != null)
            {
                var client = await context.Clients.FirstOrDefaultAsync(c => c.ClientId == id).ConfigureAwait(false);
                if (client != null)
                {
                    await context.Clients.FindAsync(id);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
                return client;
            }
            return null;
        }

        public async Task<List<Models.Client>> GetClients()
        {
            if (context != null)
            {
                return await context.Clients.ToListAsync().ConfigureAwait(false);
            }
            return null;
        }

        public async Task UpdateClient(Models.Client client)
        {
            if (context != null)
            {
                context.Clients.Update(client);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
