using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStoreAPI.DTOs.Request
{
    public class OrderProductDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}