using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;
using TechStoreAPI.Repositories;

namespace TechStoreAPI.Services;

public class CategoryServices : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(Category category)
    {
        if (category == null)
        {
            throw new ArgumentNullException(nameof(category), "La categoria no puede ser nula.");
        }

        try
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al agregar La categoria a la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al agregar la categoria.", ex);
        }
    }
    public async Task Delete(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _context.Categories.ToListAsync();
    }
    public async Task<Category?> GetById(int id)
    {
        return await _context.Categories.FindAsync(id);
    }
    public async Task Update(Category category)
    {
        if (category == null)
        {
            throw new ArgumentNullException(nameof(category), "La categoria no puede ser nulo.");
        }

        try
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al actualizar la categoria en la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al actualizar la categoria.", ex);
        }
    }
    public async Task<bool> CheckExistence(int id)
    {
        try
        {
            return await _context.Categories.AnyAsync(c => c.Id == id);
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al agregar la categoria a la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al agregar la categoria.", ex);
        }

    }
}
