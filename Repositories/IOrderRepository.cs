using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStore.Models;
using TechStoreAPI.DTOs.Request;

namespace TechStoreAPI.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> Add(OrderDTO orderDTO);
        Task<IEnumerable<OrderDTO>> GetAll();
        Task<OrderDTO> GetById(int id);
        Task<bool> Update(int id, OrderDTO orderDTO);
        Task Delete(int id);
        Task<bool> CheckExistence(int id);
    }
}