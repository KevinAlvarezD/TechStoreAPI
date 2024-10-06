using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Models;
using TechStoreAPI.Models;

namespace TechStore.Data;

public class ApplicationDbContext : DbContext
{

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Order)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(op => op.OrderId);

        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Product)
            .WithMany(p => p.OrderProducts)
            .HasForeignKey(op => op.ProductId);
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
        
    }




}
