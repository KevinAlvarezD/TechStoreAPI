using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechStoreAPI.Controllers.V1.Categories
{
    public partial class CategoriesController : ControllerBase
    {
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRepository.CheckExistence(id);
            if (category == false)
            {
                return NotFound();
            }

            await _categoryRepository.Delete(id);

            return NoContent();
        }
    }
}