using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.Models;
using TechStoreAPI.DTOs.Request;
using TechStoreAPI.Repositories;

namespace TechStoreAPI.Controllers.V1.Orders
{
    public partial class OrdersController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Order>> Create(OrderDTO inputOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newOrder = new Order();

            await _orderRepository.Add(newOrder);

            return Ok(newOrder);
        }
    }
}
