using System;
using System.Collections.Generic;

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

    public bool HasEnoughStock(int qty)
    {
        return qty <= RemainingStock;
    }

    public void DeductStock(int qty)
    {
        RemainingStock -= qty;
    }

    public double GetTotal(int qty)
    {
        return Price * qty;
    }
}

class Program
{
    static void Main()
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Spanish Latte", Price = 120, RemainingStock = 10 },
            new Product { Id = 2, Name = "Matcha Latte", Price = 120, RemainingStock = 15 }
        };

        List<Product> cart = new List<Product>();
        List<int> qtyList = new List<int>();

        Console.WriteLine("=== CAFE MENU ===");
        foreach (var p in products)
            p.DisplayProduct();

        Console.Write("\nSelect product: ");
        int choice = int.Parse(Console.ReadLine());

        Product selected = products[choice - 1];

        Console.Write("Enter quantity: ");
        int qty = int.Parse(Console.ReadLine());

        if (!selected.HasEnoughStock(qty))
        {
            Console.WriteLine("Not enough stock.");
            return;
        }

        int index = cart.FindIndex(p => p.Id == selected.Id);

        if (index != -1)
        {
            qtyList[index] += qty;
        }
        else
        {
            cart.Add(selected);
            qtyList.Add(qty);
        }

        selected.DeductStock(qty);

        Console.WriteLine("Item added to cart.");
    }
}
