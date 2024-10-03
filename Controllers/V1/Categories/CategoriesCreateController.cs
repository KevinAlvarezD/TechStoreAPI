using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.Models;
using TechStoreAPI.DTOs.Request;

namespace TechStoreAPI.Controllers.V1.Categories;

public partial class CategoriesController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Category>> Create(CategoryDTO inputCategory)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newCategory = new Category(inputCategory.Name, inputCategory.Description);

        await _categoryRepository.Add(newCategory);

        return Ok(newCategory);
    }
}