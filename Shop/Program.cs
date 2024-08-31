using Shop.Context;
using Shop.Entities;

namespace Shop
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ShopDbContext context = new ShopDbContext())
            {

                var categories = new List<Category>
                {
                    new Category { Name = "Electronics" },
                    new Category { Name = "Books" },
                    new Category { Name = "Clothing" },
                    new Category { Name = "Toys" },
                    new Category { Name = "Home Appliances" },
                    new Category { Name = "Sports" }
                };

                var products = new List<Product>
                {
                    new Product { Name = "Laptop", Category = categories[0] },
                    new Product { Name = "Smartphone", Category = categories[0] },
                    new Product { Name = "Novel", Category = categories[1] },
                    new Product { Name = "T-shirt", Category = categories[2] },
                    new Product { Name = "Basketball", Category = categories[5] },
                    new Product { Name = "Blender", Category = categories[4] }
                };


                var orders = new List<Order>
                {
                    new Order { Adress = "123 Main St", Products = new List<Product> { products[0], products[2] } },
                    new Order { Adress = "456 Oak St", Products = new List<Product> { products[1], products[3] } },
                    new Order { Adress = "789 Maple St", Products = new List<Product> { products[4] } },
                    new Order { Adress = "101 Pine St", Products = new List<Product> { products[5], products[0] } },
                    new Order { Adress = "202 Elm St", Products = new List<Product> { products[1] } },
                    new Order { Adress = "303 Cedar St", Products = new List<Product> { products[2], products[4] } }
                };


                context.Categories.AddRange(categories);
                context.Products.AddRange(products);
                context.Orders.AddRange(orders);

                context.SaveChanges();
            }
        }
    }
}
