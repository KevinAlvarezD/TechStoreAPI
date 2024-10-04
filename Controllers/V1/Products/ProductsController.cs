using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStoreAPI.Repositories;

namespace TechStoreAPI.Controllers.V1.Products
{
    [ApiController]
    [Route("api/v1/products")]
    public partial class ProductsController(IProductRepository productRepository) : ControllerBase
    {
        protected readonly IProductRepository _productRepository = productRepository;
    }
}
