namespace WebAPIDynamicLinq.Model
{
    public static class DataSource
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200, Category = "Electronics" },
            new Product { Id = 2, Name = "Smartphone", Price = 800, Category = "Electronics" },
            new Product { Id = 3, Name = "Table", Price = 150, Category = "Furniture" },
            new Product { Id = 4, Name = "Chair", Price = 85, Category = "Furniture" },
            new Product { Id = 5, Name = "Headphones", Price = 200, Category = "Electronics" },
        };
        }
    }
}
