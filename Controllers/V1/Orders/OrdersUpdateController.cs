using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStoreAPI.DTOs.Request;
using TechStoreAPI.Repositories;

namespace TechStoreAPI.Controllers.V1.Orders
{
    public partial class OrdersController : ControllerBase
    {
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _orderRepository.Update(id, orderDTO);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();

        }
    }
}
