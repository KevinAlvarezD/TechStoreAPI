using Bogus;
using TechStore.Data;
using TechStore.Models;

public class DatabaseSeeder
{
    private readonly ApplicationDbContext _context;

    public DatabaseSeeder(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        // 1. Inserta las categorías primero
        if (!_context.Categories.Any())
        {
            var categoryFaker = new Faker<Category>()
                .RuleFor(c => c.Name, f => f.PickRandom(new[]
                {
                    "Electrónica",
                    "Ropa",
                    "Libros",
                    "Hogar y Jardín",
                    "Deportes",
                    "Salud y Belleza",
                    "Juguetes",
                    "Automóviles",
                    "Joyería",
                    "Música"
                }));

            var categories = categoryFaker.Generate(10);
            _context.Categories.AddRange(categories);
            _context.SaveChanges(); // Guarda cambios para asegurar que las categorías estén disponibles
        }

        // 2. Inserta los productos (que dependen de las categorías)
        if (!_context.Products.Any())
        {
            var productFaker = new Faker<Product>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.Price, f => double.Parse(f.Commerce.Price(10, 1000)))
                .RuleFor(p => p.Quantity, f => f.Random.Int(0, 100))
                .RuleFor(p => p.CategoryId, f => f.Random.Int(1, 10)); // Asegúrate de que estos IDs de categoría existan

            var products = productFaker.Generate(100);
            _context.Products.AddRange(products);
            _context.SaveChanges(); // Guarda cambios para asegurar que los productos estén disponibles
        }

        // 3. Inserta los clientes (son independientes)
        if (!_context.Customers.Any())
        {
            var customers = new Faker<Customer>()
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.Address, f => f.Address.FullAddress())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
                .Generate(10);

            _context.Customers.AddRange(customers);
            _context.SaveChanges(); // Guarda cambios para asegurar que los clientes estén disponibles
        }

        // 4. Inserta las órdenes (que dependen de los clientes)
        if (!_context.Orders.Any())
        {
            var orderFaker = new Faker<Order>()
                .RuleFor(o => o.CustomerId, f => f.Random.Int(1, 10)) // Asegúrate de usar IDs válidos de clientes
                .RuleFor(o => o.OrderDate, f => f.Date.Past(1))
                .RuleFor(o => o.Status, f => f.PickRandom(new[] { "pendiente", "enviado", "entregado" }));

            var orders = orderFaker.Generate(20);
            _context.Orders.AddRange(orders);
            _context.SaveChanges(); // Guarda cambios para asegurar que las órdenes estén disponibles
        }
    }
}

