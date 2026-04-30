using System;

class Product
{
    public int Id;
    public string Name;
    public string Category;
    public double Price;
    public int RemainingStock;

    public void Display()
    {
        Console.WriteLine($"{Id}. {Name} ({Category}) - ₱{Price:F2} (Stock: {RemainingStock})");
    }
}

class Order
{
    public int ReceiptNo;
    public DateTime Date;
    public double FinalTotal;
}

class Program
{
    static int receiptCounter = 1;

    static void Main()
    {
        Product[] products =
        {
            new Product { Id=1, Name="Spanish Latte", Category="Drinks", Price=120, RemainingStock=10 },
            new Product { Id=2, Name="Matcha Latte", Category="Drinks", Price=120, RemainingStock=15 },
            new Product { Id=3, Name="Ube Latte", Category="Drinks", Price=120, RemainingStock=15 },
            new Product { Id=4, Name="Tiramisu Cake", Category="Dessert", Price=150, RemainingStock=8 },
            new Product { Id=5, Name="Cookie", Category="Dessert", Price=30, RemainingStock=30 }
        };

        const int LIMIT = 10;
        Product[] cart = new Product[LIMIT];
        int[] qty = new int[LIMIT];
        int count = 0;

        Order[] history = new Order[100];
        int historyCount = 0;

        while (true)
        {
            Console.WriteLine("\n=== MAIN MENU ===");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Search Product");
            Console.WriteLine("3. Filter by Category");
            Console.WriteLine("4. Manage Cart");
            Console.WriteLine("5. View Order History");
            Console.WriteLine("6. Exit");

            int choice = ReadInt("Choose: ");

            switch (choice)
            {
                case 1:
                    foreach (var p in products) p.Display();
                    break;

                case 2:
                    Console.Write("Search: ");
                    string search = Console.ReadLine().ToLower();
                    foreach (var p in products)
                        if (p.Name.ToLower().Contains(search))
                            p.Display();
                    break;

                case 3:
                    Console.WriteLine("1. Drinks\n2. Dessert");
                    int catChoice = ReadInt("Choose category: ");
                    string category = catChoice == 1 ? "Drinks" : "Dessert";

                    foreach (var p in products)
                        if (p.Category == category)
                            p.Display();
                    break;

                case 4:
                    ManageCart(products, cart, qty, ref count, history, ref historyCount);
                    break;

                case 5:
                    Console.WriteLine("\n=== ORDER HISTORY ===");
                    for (int i = 0; i < historyCount; i++)
                    {
                        Console.WriteLine($"Receipt #{history[i].ReceiptNo:0000} | {history[i].Date:MMMM dd, yyyy hh:mm tt} | ₱{history[i].FinalTotal:F2}");
                    }
                    break;

                case 6:
                    return;
            }
        }
    }

    static void ManageCart(Product[] products, Product[] cart, int[] qty,
        ref int count, Order[] history, ref int historyCount)
    {
        while (true)
        {
            Console.WriteLine("\n=== CART MENU ===");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. View Cart");
            Console.WriteLine("3. Update Quantity");
            Console.WriteLine("4. Remove Item");
            Console.WriteLine("5. Clear Cart");
            Console.WriteLine("6. Checkout");
            Console.WriteLine("7. Back");

            int choice = ReadInt("Choose: ");

            switch (choice)
            {
                case 1:
                    foreach (var p in products) p.Display();

                    int id = ReadInt("Product #: ");
                    Product selected = products[id - 1];

                    if (selected.RemainingStock == 0)
                    {
                        Console.WriteLine("Out of stock.");
                        break;
                    }

                    int q = ReadInt("Quantity: ");
                    if (q > selected.RemainingStock)
                    {
                        Console.WriteLine("Not enough stock.");
                        break;
                    }

                    int index = FindItem(cart, count, selected.Id);

                    if (index != -1)
                        qty[index] += q;
                    else
                    {
                        cart[count] = selected;
                        qty[count++] = q;
                    }

                    selected.RemainingStock -= q;

                    ShowLowStock(products);
                    break;

                case 2:
                    for (int i = 0; i < count; i++)
                        Console.WriteLine($"{i + 1}. {cart[i].Name} x{qty[i]}");
                    break;

                case 3:
                    int u = ReadInt("Item #: ") - 1;

                    int newQty = ReadInt("New quantity: ");
                    int oldQty = qty[u];
                    int diff = newQty - oldQty;

                    if (diff > 0 && diff > cart[u].RemainingStock)
                    {
                        Console.WriteLine("Not enough stock.");
                        break;
                    }

                    cart[u].RemainingStock -= diff;
                    qty[u] = newQty;
                    break;

                case 4:
                    int r = ReadInt("Remove item #: ") - 1;

                    cart[r].RemainingStock += qty[r];

                    for (int i = r; i < count - 1; i++)
                    {
                        cart[i] = cart[i + 1];
                        qty[i] = qty[i + 1];
                    }
                    count--;
                    break;

                case 5:
                    for (int i = 0; i < count; i++)
                        cart[i].RemainingStock += qty[i];

                    count = 0;
                    Console.WriteLine("Cart cleared.");
                    break;

                case 6:
                    double finalTotal;
                    Checkout(cart, qty, count, products, out finalTotal);

                    history[historyCount++] = new Order
                    {
                        ReceiptNo = receiptCounter - 1,
                        Date = DateTime.Now,
                        FinalTotal = finalTotal
                    };

                    count = 0;
                    break;

                case 7:
                    return;
            }
        }
    }

    static void Checkout(Product[] cart, int[] qty, int count,
        Product[] products, out double finalTotal)
    {
        Console.WriteLine("\n=== RECEIPT ===");

        double total = 0;
        for (int i = 0; i < count; i++)
        {
            double sub = cart[i].Price * qty[i];
            Console.WriteLine($"{cart[i].Name} x{qty[i]} = ₱{sub:F2}");
            total += sub;
        }

        double discount = total >= 5000 ? total * 0.10 : 0;
        finalTotal = total - discount;

        Console.WriteLine($"Total: ₱{total:F2}");
        Console.WriteLine($"Discount: ₱{discount:F2}");
        Console.WriteLine($"Final Total: ₱{finalTotal:F2}");

        double payment;
        while (true)
        {
            Console.Write("Payment: ");
            if (double.TryParse(Console.ReadLine(), out payment) && payment >= finalTotal)
                break;

            Console.WriteLine("Invalid or insufficient payment.");
        }

        Console.WriteLine($"Change: ₱{payment - finalTotal:F2}");

        Console.WriteLine($"\nReceipt No: {receiptCounter++:0000}");
        Console.WriteLine($"Date: {DateTime.Now:MMMM dd, yyyy hh:mm tt}");

        ShowLowStock(products);
    }

    static int ReadInt(string message)
    {
        int value;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out value))
                return value;

            Console.WriteLine("Invalid input. Enter a number.");
        }
    }

    static int FindItem(Product[] cart, int count, int id)
    {
        for (int i = 0; i < count; i++)
            if (cart[i].Id == id) return i;

        return -1;
    }

    static void ShowLowStock(Product[] products)
    {
        Console.WriteLine("\nLOW STOCK ALERT:");
        bool found = false;

        foreach (var p in products)
        {
            if (p.RemainingStock <= 5)
            {
                Console.WriteLine($"{p.Name} only {p.RemainingStock} left!");
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No low stock items.");
    }
}
