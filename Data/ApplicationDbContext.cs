using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Models;

namespace TechStore.Data;

public class ApplicationDbContext : DbContext
{

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
        
    }




}
