using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStoreAPI.Repositories;

namespace TechStoreAPI.Controllers.V1.Customers;

[ApiController]
[Route("api/v1/customer")]

public partial class CustomersController(ICustomerRepository customerRepository)  : ControllerBase
{
    protected readonly ICustomerRepository _customerRepository = customerRepository;
    
}
