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
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDTO updatedProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var checkProduct = await _productRepository.CheckExistence(id);
            if (checkProduct == false)
            {
                return NotFound();
            }

            var product = await _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.Quantity = updatedProduct.Quantity;
            product.CategoryId = updatedProduct.CategoryId;
            

            await _productRepository.Update(product);
            return NoContent();
        }
    }
}