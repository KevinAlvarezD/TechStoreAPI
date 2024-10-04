using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStore.Models;

namespace TechStoreAPI.Repositories
{
    public interface IOrderRepository
    {
        Task Add(Order order);
        Task<IEnumerable<Order>> GetAll();
        Task<Order?> GetById(int id);
        Task Update(Order order);
        Task Delete(int id);
        Task<bool> CheckExistence(int id);
    }
}