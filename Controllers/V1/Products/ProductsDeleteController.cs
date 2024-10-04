using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.Models;
using TechStoreAPI.DTOs.Request;

namespace TechStoreAPI.Controllers.V1.Products
{
    public partial class ProductsController : ControllerBase
    {
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.CheckExistence(id);
            if (product == false)
            {
                return NotFound();
            }

            await _productRepository.Delete(id);

            return NoContent();
        }
    }
}