using AirplaneTicketService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneTicketService.NewFolder
{
    public interface IClient
    {
        Task<List<Models.Client>> GetClients();
        Task<Models.Client> GetClient(int? id);
        Task<Models.Client> AddClient(Models.Client client);
        Task<int> DeleteClient(int? id);
        Task UpdateClient(Models.Client client);
    }
}
