using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;
using TechStoreAPI.DTOs.Request;
using TechStoreAPI.Models;
using TechStoreAPI.Repositories;

namespace TechStoreAPI.Services;

public class OrderServices : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Order> Add(OrderDTO orderDTO)
    {
        if (orderDTO == null)
        {
            throw new ArgumentNullException(nameof(orderDTO), "La orden no puede ser nula.");
        }

        try
        {
            var newOrder = new Order
            {
                CustomerId = orderDTO.CustomerId,
                OrderDate = orderDTO.OrderDate,
                TotalAmount = orderDTO.TotalAmount,
                Status = orderDTO.Status,
                OrderProducts = new List<OrderProduct>()
            };

            foreach (var orderProductDTO in orderDTO.OrderProducts)
            {
                var product = await _context.Products.FindAsync(orderProductDTO.ProductId);
                if (product == null)
                {
                    throw new ArgumentNullException(nameof(orderDTO), $"Product with ID {orderProductDTO.ProductId} not found.");
                }

                newOrder.OrderProducts.Add(new OrderProduct
                {
                    ProductId = product.Id,
                    Quantity = orderProductDTO.Quantity,
                    Order = newOrder
                });
            }

            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            return newOrder;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al crear la orden", ex);
        }
    }
    public async Task<bool> CheckExistence(int id)
    {
        try
        {
            return await _context.Orders.AnyAsync(o => o.Id == id);
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al agregar la orden a la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al agregar la orden.", ex);
        }
    }
    public async Task Delete(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<IEnumerable<OrderDTO>> GetAll()
    {
        var orders = await _context.Orders
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .ToListAsync();

        return orders.Select(o => new OrderDTO
        {
            Id = o.Id,
            Status = o.Status,
            OrderDate = o.OrderDate,
            TotalAmount = o.TotalAmount,
            CustomerId = o.CustomerId,
            Products = o.OrderProducts.Select(op => new ProductDTO
            {
                Name = op.Product.Name,
                Quantity = op.Quantity,
                Price = op.Product.Price,
                Description = op.Product.Description,
                CategoryId = op.Product.CategoryId

            }).ToList()
        }).ToList();
    }
    public async Task<OrderDTO> GetById(int id)
    {
        var order = await _context.Orders
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
        {
            return null;
        }

        return new OrderDTO
        {
            Id = order.Id,
            Status = order.Status,
            OrderDate = order.OrderDate,
            TotalAmount = order.TotalAmount,
            CustomerId = order.CustomerId,
            Products = order.OrderProducts.Select(op => new ProductDTO
            {
                Name = op.Product.Name,
                Quantity = op.Quantity,
                Price = op.Product.Price,
                Description = op.Product.Description,
                CategoryId = op.Product.CategoryId
            }).ToList()
        };
    }
    public async Task<bool> Update(int id, OrderDTO orderDTO)
    {
        var order = await _context.Orders
            .Include(o => o.OrderProducts)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
        {
            return false;
        }

        order.Status = orderDTO.Status;
        order.OrderDate = orderDTO.OrderDate;
        order.TotalAmount = orderDTO.TotalAmount;
        order.CustomerId = orderDTO.CustomerId;

        order.OrderProducts.Clear();
        foreach (var orderProductDTO in orderDTO.OrderProducts)
        {
            var product = await _context.Products.FindAsync(orderProductDTO.ProductId);
            if (product == null)
            {
                throw new Exception($"Product with ID {orderProductDTO.ProductId} not found.");
            }

            order.OrderProducts.Add(new OrderProduct
            {
                ProductId = product.Id,
                Quantity = orderProductDTO.Quantity,
                Order = order
            });
        }

        await _context.SaveChangesAsync();
        return true;
    }

}
