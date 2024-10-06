using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Helpers;
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

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new ArgumentException("La contraseña no puede ser nula o vacía.", nameof(user.Password));
            }

            try
            {
                
                user.Password = PasswordHasher.HashPassword(user.Password);

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
        public async Task<User?> ValidateUser(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return null;
            }

            bool isPasswordValid = PasswordHasher.VerifyPassword(password, user.Password);

            if (!isPasswordValid)
            {
                return null;
            }

            return user;
        }
        public async Task<string?> login(string email, string password, string secretKey)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return null;
            }

            bool isPasswordValid = PasswordHasher.VerifyPassword(password, user.Password);

            if (!isPasswordValid)
            {
                return null;

            }
            return JwtTokenHelper.GenerateToken(user.Username, user.Role, secretKey);
        }

        public User GetUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty", nameof(email));
            }

            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
    }

}