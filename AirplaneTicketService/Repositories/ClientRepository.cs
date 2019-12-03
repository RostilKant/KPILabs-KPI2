using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirplaneTicketService.Data;
using AirplaneTicketService.Models;
using AirplaneTicketService.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirplaneTicketService.NewFolder
{
    public class ClientRepository : IRepository<Client>
    {
        ApplicationContext context;
        public ClientRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<Client> Create(Client client)
        {
            if (context != null)
            {
                await context.Clients.AddAsync(client);
                await context.SaveChangesAsync().ConfigureAwait(false);

                return client;
            }
            return null;
        }
        
        public async Task<int> Delete(int id)
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

        public async Task<Client> Retrieve(int id)
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

        public async Task<List<Client>> RetrieveAll()
        {
            if (context != null)
            {
                return await context.Clients.ToListAsync().ConfigureAwait(false);
            }
            return null;
        }
        public async Task<List<Client>> GetClientsByPassport(string passport)
        {
            if (context != null)
            {
                var clients = from m in context.Clients
                              select m;
                if (!String.IsNullOrEmpty(passport))
                {
                    clients = clients.Where(m => m.Passport.Contains(passport));
                    return await clients.ToListAsync().ConfigureAwait(false);
                }
                //return null;
            }
            return null;
        }

        public async Task Update(Client client)
        {
            if (context != null)
            {
                context.Clients.Update(client);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

    }
}
