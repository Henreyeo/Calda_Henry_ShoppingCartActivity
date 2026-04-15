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

        Console.Write("\nEnter product number: ");

        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        if (choice < 1 || choice > products.Length)
        {
            Console.WriteLine("Invalid product selection.");
            return;
        }

        Console.WriteLine($"You selected: {products[choice - 1].Name}");
    }
}
