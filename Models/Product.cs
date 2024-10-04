using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Models;

[Table("products")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("price")]
    public double Price { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }



    public Product() { }

    public Product(string name, string description, double price, int quantity, int categoryId) 
    {
        Name = name.ToLower().Trim();
        Description = description.ToLower().Trim();
        Price = price;
        Quantity = quantity;
        CategoryId = categoryId;
    }
}
