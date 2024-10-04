using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStoreAPI.Repositories;

namespace TechStoreAPI.Controllers.V1.Categories;

[ApiController]
[Route("api/[controller]")]
public partial class CategoriesController(ICategoryRepository categoryRepository)  : ControllerBase
{
    protected readonly ICategoryRepository _categoryRepository = categoryRepository;
    
}
