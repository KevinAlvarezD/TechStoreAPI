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
        [HttpPost]
        public async Task<ActionResult<Product>> Create(ProductDTO inputProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newProduct = new Product();

            await _productRepository.Add(newProduct);

            return Ok(newProduct);
        }
    }
}