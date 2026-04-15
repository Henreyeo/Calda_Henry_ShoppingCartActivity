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

    public double GetItemTotal(int quantity)
    {
        return Price * quantity;
    }

    public bool HasEnoughStock(int quantity)
    {
        return quantity <= RemainingStock;
    }

    public void DeductStock(int quantity)
    {
        RemainingStock -= quantity;
    }
}

class Program
{
    static void Main()
    {
        // STORE MENU
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Spanish Latte", Price = 120, RemainingStock = 10 },
            new Product { Id = 2, Name = "Matcha Latte", Price = 120, RemainingStock = 15 },
            new Product { Id = 3, Name = "Ube Latte", Price = 120, RemainingStock = 15 },
            new Product { Id = 4, Name = "Tiramisu Cake", Price = 150, RemainingStock = 8 },
            new Product { Id = 5, Name = "Chocolate Chip Cookie", Price = 30, RemainingStock = 30 },
            new Product { Id = 6, Name = "Macaron", Price = 30, RemainingStock = 40 },
            new Product { Id = 7, Name = "Croissant", Price = 50, RemainingStock = 35 },
            new Product { Id = 8, Name = "Loaded Fries", Price = 70, RemainingStock = 30 },
            new Product { Id = 9, Name = "Breakfast Sandwich", Price = 70, RemainingStock = 30 },
            new Product { Id = 10, Name = "Lemonade", Price = 70, RemainingStock = 20 },
            new Product { Id = 11, Name = "Crème Brûlée", Price = 70, RemainingStock = 15 },
            new Product { Id = 12, Name = "Soufflé", Price = 50, RemainingStock = 25 }

        };

        // CART (using List but with limit)
        List<Product> cart = new List<Product>();
        List<int> quantities = new List<int>();
        const int CART_LIMIT = 10;

        bool continueShopping = true;

        while (continueShopping)
        {
            Console.WriteLine("\n=== Cafe Menu ===");
            foreach (Product p in products)
            {
                p.DisplayProduct();
            }

            // CHECK CART LIMIT
            if (cart.Count >= CART_LIMIT)
            {
                Console.WriteLine("Cart is full.");
                break;
            }

            // INPUT PRODUCT
            Console.Write("\nEnter product number: ");
            int productChoice;

            if (!int.TryParse(Console.ReadLine(), out productChoice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

            if (productChoice < 1 || productChoice > products.Length)
            {
                Console.WriteLine("Invalid product number.");
                continue;
            }

            Product selected = products[productChoice - 1];

            // OUT OF STOCK CHECK
            if (selected.RemainingStock == 0)
            {
                Console.WriteLine("This product is out of stock.");
                continue;
            }

            // INPUT QUANTITY
            Console.Write("Enter quantity: ");
            int qty;

            if (!int.TryParse(Console.ReadLine(), out qty) || qty <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                continue;
            }

            if (!selected.HasEnoughStock(qty))
            {
                Console.WriteLine("Not enough stock available.");
                continue;
            }

            // CHECK DUPLICATE
            int index = cart.FindIndex(p => p.Id == selected.Id);

            if (index != -1)
            {
                quantities[index] += qty;
                Console.WriteLine("Cart updated (duplicate item).");
            }
            else
            {
                cart.Add(selected);
                quantities.Add(qty);
                Console.WriteLine("Item added to cart.");
            }

            // DEDUCT STOCK
            selected.DeductStock(qty);

            // CONTINUE SHOPPING VALIDATION
            Console.Write("Add more items? (Y/N): ");
            string choice = Console.ReadLine().ToUpper();

            if (choice != "Y" && choice != "N")
            {
                Console.WriteLine("Invalid choice. Assuming YES.");
                continue;
            }

            if (choice == "N")
            {
                continueShopping = false;
            }
        }

        // RECEIPT
        Console.WriteLine("\n=== RECEIPT ===");
        double grandTotal = 0;

        for (int i = 0; i < cart.Count; i++)
        {
            double subtotal = cart[i].GetItemTotal(quantities[i]);
            Console.WriteLine($"{cart[i].Name} x{quantities[i]} = ₱{subtotal:F2}");
            grandTotal += subtotal;
        }

        // DISCOUNT
        double discount = 0;
        if (grandTotal >= 5000)
        {
            discount = grandTotal * 0.10;
        }

        double finalTotal = grandTotal - discount;

        Console.WriteLine($"\nGrand Total: ₱{grandTotal:F2}");
        Console.WriteLine($"Discount: ₱{discount:F2}");
        Console.WriteLine($"Final Total: ₱{finalTotal:F2}");

        // UPDATED STOCK
        Console.WriteLine("\n=== Updated Stock ===");
        foreach (Product p in products)
        {
            p.DisplayProduct();
        }

        Console.WriteLine("\nThank you for purchasing!");
    }
}
