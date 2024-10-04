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

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task Update(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "El usuario no puede ser nulo.");
            }

            try
            {
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Error al actualizar el usuario en la base de datos.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado al actualizar el usuario.", ex);
            }
        }
    }
}