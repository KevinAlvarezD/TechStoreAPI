using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStore.Models;

namespace TechStoreAPI.Repositories
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(int id);
        Task Update(User user);
        Task Delete(int id);
        Task<bool> CheckExistence(int id);
    }
}