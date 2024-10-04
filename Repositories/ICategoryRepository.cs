using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStore.Models;

namespace TechStoreAPI.Repositories
{
    public interface ICategoryRepository
    {
        Task Add(Category category);
        Task<IEnumerable<Category>> GetAll();
        Task<Category?> GetById(int id);
        Task Update(Category category);
        Task Delete(int id);
        Task<bool> CheckExistence(int id);
    }
}