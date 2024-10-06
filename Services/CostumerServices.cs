using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;
using TechStoreAPI.Repositories;

namespace TechStoreAPI.Services;

public class CostumerServices : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CostumerServices(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task Add(Customer customer)
    {
        if (customer == null)
        {
            throw new ArgumentNullException(nameof(customer), "El cliente no puede ser nulo.");
        }

        try
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al agregar el cliente a la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al agregar el cliente.", ex);
        }
    }
    public async Task<bool> CheckExistence(int id)
    {
        try
        {
            return await _context.Customers.AnyAsync(c => c.Id == id);
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al agregar el cliente a la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al agregar el cliente.", ex);
        }
    }
    public async Task Delete(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<IEnumerable<Customer>> GetAll()
    {
        return await _context.Customers.ToListAsync();
    }
    public async Task<Customer> GetById(int id)
    {
        return await _context.Customers.FindAsync(id);
    }
    public async Task Update(Customer customer)
    {
        if (customer == null)
        {
            throw new ArgumentNullException(nameof(customer), "El cliente no puede ser nulo.");
        }

        try
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al actualizar el cleinte en la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al actualizar el cliente.", ex);
        }
    }
}
