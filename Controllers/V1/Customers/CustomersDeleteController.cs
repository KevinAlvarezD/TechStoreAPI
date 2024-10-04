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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerRepository.CheckExistence(id);
            if (customer == false)
            {
                return NotFound();
            }

            await _customerRepository.Delete(id);

            return NoContent();
        }
    }
}