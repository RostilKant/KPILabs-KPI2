using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirplaneTicketService.Data;
using AirplaneTicketService.Models;
using AirplaneTicketService.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirplaneTicketService.Persistance
{
    public class PlaneRepository : IRepository<Plane>
    {
        ApplicationContext context;
        public PlaneRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<Plane> Create(Plane plane)
        {
            if (context != null)
            {
                await context.Planes.AddAsync(plane);
                await context.SaveChangesAsync().ConfigureAwait(false);

                return plane;
            }
            return null;
        }

        public async Task<int> Delete(int id)
        {
            int result = 0;
            if (context != null)
            {
                var plane = await context.Planes.FirstOrDefaultAsync(c => c.PlaneId == id).ConfigureAwait(false);
                if (plane != null)
                {
                    context.Planes.Remove(plane);
                    result = await context.SaveChangesAsync().ConfigureAwait(false);
                }
                return result;
            }
            return 0;
        }

        public async Task<Plane> Retrieve(int id)
        {
            if (context != null)
            {
                return await context.Planes.FirstOrDefaultAsync(c => c.PlaneId == id).ConfigureAwait(false);
                //if(plane != null)
                //{
                //    await context.Planes.FindAsync(id);
                //    await context.SaveChangesAsync().ConfigureAwait(false);
                //}
                //return plane;
            }
            return null;
        }

        public async Task<List<Plane>> RetrieveAll ()
        {
            if (context != null)
            {
                return await context.Planes.ToListAsync().ConfigureAwait(false);
            }
            return null;
        }

        public async Task Update(Plane plane)
        {
            if(context != null)
            {
                context.Planes.Update(plane);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
