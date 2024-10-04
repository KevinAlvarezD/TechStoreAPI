using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStoreAPI.Repositories;

namespace TechStoreAPI.Controllers.V1.Orders
{
    public partial class OrdersController : ControllerBase
    {
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderRepository.CheckExistence(id);
            if (order == false)
            {
                return NotFound();
            }

            await _orderRepository.Delete(id);

            return NoContent();
        }
    }
}
