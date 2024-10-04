using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Models;


[Table("orders")]
public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("status")]
    public string? Status { get; set; }

    [Column("order_date")]
    public DateTime OrderDate { get; set; }

    [Column("total_amount")]
    public double TotalAmount { get; set; }

    [Column("customer_id")]
    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public Customer? Customer { get; set; }

    public Order() { }

    public Order(string status, DateTime order_date, double total_amount, int customer_id)
    {
        Status = status.ToLower().Trim();
        OrderDate = order_date;
        TotalAmount = total_amount;
        CustomerId = customer_id;
    }

}
