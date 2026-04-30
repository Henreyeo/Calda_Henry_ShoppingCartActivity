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
