using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStore.Models;

namespace TechStoreAPI.Repositories
{
    public interface ICustomerRepository
    {
        Task Add(Customer customer);
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer?> GetById(int id);
        Task Update(Customer customer);
        Task Delete(int id);
        Task<bool> CheckExistence(int id);
    }
}