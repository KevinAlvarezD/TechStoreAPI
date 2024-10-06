using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.Models;
using TechStoreAPI.DTOs.Request;

namespace TechStoreAPI.Controllers.V1.Customers
{
    public partial class CustomersController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Customer>> Create(CustomerDTO inputCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCustomer = new Customer();

            await _customerRepository.Add(newCustomer);

            return Ok(newCustomer);
        }
    }
}