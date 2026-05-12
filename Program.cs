using System;

class Product
{
    private int id;
    private string name;
    private string category;
    private double price;
    private int remainingStock;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Category
    {
        get { return category; }
        set { category = value; }
    }

    public double Price
    {
        get { return price; }
        set { price = value; }
    }

    public int RemainingStock
    {
        get { return remainingStock; }
        set { remainingStock = value; }
    }

    public void Display()
    {
        Console.WriteLine($"{Id}. {Name} ({Category}) - ₱{Price:F2} (Stock: {RemainingStock})");
    }
}

class Order
{
    private int receiptNo;
    private DateTime date;
    private double finalTotal;

    public int ReceiptNo
    {
        get { return receiptNo; }
        set { receiptNo = value; }
    }

    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

    public double FinalTotal
    {
        get { return finalTotal; }
        set { finalTotal = value; }
    }
}

class Program
{
    static int receiptCounter = 1;

    static void Main()
    {
        Product[] products =
        {
            new Product { Id = 1, Name = "Spanish Latte", Category = "Drinks", Price = 120, RemainingStock = 10 },
            new Product { Id = 2, Name = "Matcha Latte", Category = "Drinks", Price = 120, RemainingStock = 15 },
            new Product { Id = 3, Name = "Ube Latte", Category = "Drinks", Price = 120, RemainingStock = 15 },
            new Product { Id = 4, Name = "Tiramisu Cake", Category = "Dessert", Price = 150, RemainingStock = 8 },
            new Product { Id = 5, Name = "Chocolate Chip Cookie", Category = "Dessert", Price = 30, RemainingStock = 30 },
            new Product { Id = 6, Name = "Macaron", Category = "Dessert", Price = 30, RemainingStock = 40 },
            new Product { Id = 7, Name = "Croissant", Category = "Dessert", Price = 50, RemainingStock = 35 },
            new Product { Id = 8, Name = "Loaded Fries", Category = "Savory", Price = 70, RemainingStock = 30 },
            new Product { Id = 9, Name = "Breakfast Sandwich", Category = "Savory", Price = 70, RemainingStock = 30 },
            new Product { Id = 10, Name = "Lemonade", Category = "Drinks", Price = 70, RemainingStock = 20 },
            new Product { Id = 11, Name = "Crème Brûlée", Category = "Dessert", Price = 70, RemainingStock = 15 },
            new Product { Id = 12, Name = "Soufflé", Category = "Dessert", Price = 50, RemainingStock = 25 }
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
                    foreach (var p in products)
                        p.Display();
                    break;

                case 2:
                    Console.Write("Search: ");
                    string search = Console.ReadLine().ToLower();

                    foreach (var p in products)
                    {
                        if (p.Name.ToLower().Contains(search))
                            p.Display();
                    }
                    break;

                case 3:
                    Console.WriteLine("1. Drinks\n2. Dessert");

                    int catChoice = ReadInt("Choose category: ");

                    string category = catChoice == 1 ? "Drinks" : "Dessert";

                    foreach (var p in products)
                    {
                        if (p.Category == category)
                            p.Display();
                    }
                    break;

                case 4:
                    ManageCart(products, cart, qty, ref count, history, ref historyCount);
                    break;

                case 5:
                    Console.WriteLine("\n=== ORDER HISTORY ===");

                    for (int i = 0; i < historyCount; i++)
                    {
                        Console.WriteLine(
                            $"Receipt #{history[i].ReceiptNo:0000} | " +
                            $"{history[i].Date:MMMM dd, yyyy hh:mm tt} | " +
                            $"₱{history[i].FinalTotal:F2}");
                    }
                    break;

                case 6:
                    return;
            }
        }
    }
