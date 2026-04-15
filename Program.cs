using System;

class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int RemainingStock;

    public void DisplayProduct()
    {
        Console.WriteLine($"{Id}. {Name} - ₱{Price:F2} (Stock: {RemainingStock})");
    }
}

class Program
{
    static void Main()
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Spanish Latte", Price = 120, RemainingStock = 10 },
            new Product { Id = 2, Name = "Matcha Latte", Price = 120, RemainingStock = 15 },
            new Product { Id = 3, Name = "Ube Latte", Price = 120, RemainingStock = 15 }
        };

        Console.WriteLine("=== CAFE MENU ===");
        foreach (Product p in products)
        {
            p.DisplayProduct();
        }
    }
}
