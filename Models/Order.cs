using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Models;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string? Status { get; set; }
    public DateTime OrderDate { get; set; }
    public double TotalAmount { get; set; }
}
