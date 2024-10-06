using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.Models;
using TechStoreAPI.Repositories;

namespace TechStoreAPI.Controllers.V1.Orders
{
    public partial class OrdersController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            var order = await _orderRepository.GetAll();
            if (order == null || !order.Any())
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            var order = await _orderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
