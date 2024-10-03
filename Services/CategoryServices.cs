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
            throw new Exception("Ocurrió un error inesperado al agregar La categoria.", ex);
        }
    }
}
