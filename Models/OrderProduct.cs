using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TechStore.Models;

namespace TechStoreAPI.Models;

public class OrderProduct
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("order_id")]
    public int OrderId { get; set; }

    [ForeignKey("OrderId")]
    public Order Order { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }
}
