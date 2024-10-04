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
        public async Task<IActionResult> Update(int id, OrderDTO updatedOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var checkOrder = await _orderRepository.CheckExistence(id);
            if (checkOrder == false)
            {
                return NotFound();
            }

            var order = await _orderRepository.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            order.Status = updatedOrder.Status;
            order.OrderDate = updatedOrder.OrderDate;
            order.TotalAmount = updatedOrder.TotalAmount;
            order.CustomerId = updatedOrder.CustomerId;
            

            await _orderRepository.Update(order);
            return NoContent();
        }
    }
}
