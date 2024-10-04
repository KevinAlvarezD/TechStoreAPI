using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStoreAPI.DTOs.Request;

namespace TechStoreAPI.Controllers.V1.Categories
{
    public partial class CategoriesController : ControllerBase
    {
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryDTO updatedCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var checkCategory = await _categoryRepository.CheckExistence(id);
            if (checkCategory == false)
            {
                return NotFound();
            }

            var category = await _categoryRepository.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            category.Name = updatedCategory.Name;
            category.Description = updatedCategory.Description;

            await _categoryRepository.Update(category);
            return NoContent();
        }
    }
}