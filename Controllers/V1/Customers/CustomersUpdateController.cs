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
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerDTO updatedCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var checkCustomer = await _customerRepository.CheckExistence(id);
            if (checkCustomer == false)
            {
                return NotFound();
            }

            var customer = await _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.Name = updatedCustomer.Name;
            customer.Address = updatedCustomer.Address;
            customer.Phone = updatedCustomer.Phone;
            customer.Email = updatedCustomer.Email;
            

            await _customerRepository.Update(customer);
            return NoContent();
        }
    }
}