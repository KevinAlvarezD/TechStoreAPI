using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStore.Models;

namespace TechStoreAPI.Repositories
{
    public interface IProductRepository
    {
        Task Add(Product product);
        Task<IEnumerable<Product>> GetAll();
        Task<Product?> GetById(int id);
        Task Update(Product product);
        Task Delete(int id);
        Task<bool> CheckExistence(int id);
    }
}