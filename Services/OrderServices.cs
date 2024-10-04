using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;
using TechStoreAPI.Repositories;

namespace TechStoreAPI.Services;

public class OrderServices : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order), "La orden no puede ser nula.");
        }

        try
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al agregar la orden a la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al agregar la orden.", ex);
        }
    }
    public async Task<bool> CheckExistence(int id)
    {
        try
        {
            return await _context.Orders.AnyAsync(o => o.Id == id);
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al agregar la orden a la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al agregar la orden.", ex);
        }
    }
    public async Task Delete(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<IEnumerable<Order>> GetAll()
    {
        return await _context.Orders.Include(o => o.Customer).ToListAsync();
    }
    public async Task<Order?> GetById(int id)
    {
        return await _context.Orders.Include(o => o.Customer).FirstOrDefaultAsync(o => o.Id == id);
    }
    public async Task Update(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order), "La orden no puede ser nula.");
        }

        try
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al actualizar la orden en la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al actualizar la orden.", ex);
        }
    }
}
