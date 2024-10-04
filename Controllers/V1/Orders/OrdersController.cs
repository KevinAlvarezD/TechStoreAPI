using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStoreAPI.Repositories;

namespace TechStoreAPI.Controllers.V1.Orders
{
    [ApiController]
    [Route("api/v1/orders")]
    public partial class OrdersController(IOrderRepository orderRepository) : ControllerBase
    {
        protected readonly IOrderRepository _orderRepository = orderRepository;
    }
}
