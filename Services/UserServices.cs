using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;
using TechStoreAPI.Repositories;

namespace TechStoreAPI.Services
{
    public class UserServices : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "El usuario no puede ser nulo.");
            }

            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Error al agregar el usuario a la base de datos.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado al agregar el usuario.", ex);
            }
        }

        public async Task<bool> CheckExistence(int id)
        {
            try
            {
                return await _context.Users.AnyAsync(u => u.Id == id);
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Error al agregar el usuario a la base de datos.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado al agregar el usuario.", ex);
            }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}