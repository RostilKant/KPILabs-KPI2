using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneTicketService.Repositories
{
    interface IRepository<T> where T : class
    {
        Task<List<T>> RetrieveAll();
        Task<T> Retrieve(int id);
        Task<T> Create(T t);
        Task<int> Delete(int id);
        Task Update(T t);
    }
}
