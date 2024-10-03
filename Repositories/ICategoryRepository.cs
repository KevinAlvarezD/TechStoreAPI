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
    }
}