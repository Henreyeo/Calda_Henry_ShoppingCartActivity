using System;
using System.Collections.Generic;
using System.Windows.Forms;

class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int RemainingStock;

    public void DisplayProduct()
    {
        // Adapted for GUI display
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

class CafeForm : Form
{
    private Product[] products;
    private List<Product> cart;
    private List<int> quantities;
    private const int CART_LIMIT = 10;

    private ListBox menuListBox;
    private TextBox productTextBox;
    private TextBox quantityTextBox;
    private Button addButton;
    private Button receiptButton;
    private Label statusLabel;
    private ListBox cartListBox;
    private Label totalLabel;

    public CafeForm()
    {
        InitializeProducts();
        InitializeComponents();
        UpdateMenuDisplay();
    }

    private void InitializeProducts()
    {
        products = new Product[]
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

        cart = new List<Product>();
        quantities = new List<int>();
    }

    private void InitializeComponents()
    {
        this.Text = "Cafe Menu";
        this.Size = new System.Drawing.Size(600, 500);

        menuListBox = new ListBox { Location = new System.Drawing.Point(10, 10), Size = new System.Drawing.Size(300, 200) };
        this.Controls.Add(menuListBox);

        productTextBox = new TextBox { Location = new System.Drawing.Point(10, 220), Size = new System.Drawing.Size(100, 20) };
        this.Controls.Add(productTextBox);

        quantityTextBox = new TextBox { Location = new System.Drawing.Point(120, 220), Size = new System.Drawing.Size(100, 20) };
        this.Controls.Add(quantityTextBox);

        addButton = new Button { Text = "Add to Cart", Location = new System.Drawing.Point(230, 220), Size = new System.Drawing.Size(80, 30) };
        addButton.Click += AddToCart;
        this.Controls.Add(addButton);

        receiptButton = new Button { Text = "View Receipt", Location = new System.Drawing.Point(320, 220), Size = new System.Drawing.Size(100, 30) };
        receiptButton.Click += ShowReceipt;
        this.Controls.Add(receiptButton);

        statusLabel = new Label { Location = new System.Drawing.Point(10, 260), Size = new System.Drawing.Size(400, 20) };
        this.Controls.Add(statusLabel);

        cartListBox = new ListBox { Location = new System.Drawing.Point(320, 10), Size = new System.Drawing.Size(250, 200) };
        this.Controls.Add(cartListBox);

        totalLabel = new Label { Location = new System.Drawing.Point(10, 290), Size = new System.Drawing.Size(400, 40) };
        this.Controls.Add(totalLabel);
    }

    private void UpdateMenuDisplay()
    {
        menuListBox.Items.Clear();
        foreach (Product p in products)
        {
            menuListBox.Items.Add($"{p.Id}. {p.Name} - ₱{p.Price:F2} (Stock: {p.RemainingStock})");
        }
    }

    private void AddToCart(object sender, EventArgs e)
    {
        if (cart.Count >= CART_LIMIT)
        {
            statusLabel.Text = "Cart is full.";
            return;
        }

        if (!int.TryParse(productTextBox.Text, out int productChoice) || productChoice < 1 || productChoice > products.Length)
        {
            statusLabel.Text = "Invalid product number.";
            return;
        }

        Product selected = products[productChoice - 1];

        if (selected.RemainingStock == 0)
        {
            statusLabel.Text = "This product is out of stock.";
            return;
        }

        if (!int.TryParse(quantityTextBox.Text, out int qty) || qty <= 0)
        {
            statusLabel.Text = "Invalid quantity.";
            return;
        }

        if (!selected.HasEnoughStock(qty))
        {
            statusLabel.Text = "Not enough stock available.";
            return;
        }

        int index = cart.FindIndex(p => p.Id == selected.Id);
        if (index != -1)
        {
            quantities[index] += qty;
            statusLabel.Text = "Cart updated (duplicate item).";
        }
        else
        {
            cart.Add(selected);
            quantities.Add(qty);
            statusLabel.Text = "Item added to cart.";
        }

        selected.DeductStock(qty);
        UpdateMenuDisplay();
        UpdateCartDisplay();
    }

    private void UpdateCartDisplay()
    {
        cartListBox.Items.Clear();
        for (int i = 0; i < cart.Count; i++)
        {
            cartListBox.Items.Add($"{cart[i].Name} x{quantities[i]}");
        }
    }

    private void ShowReceipt(object sender, EventArgs e)
    {
        double grandTotal = 0;
        string receipt = "=== RECEIPT ===\n";
        for (int i = 0; i < cart.Count; i++)
        {
            double subtotal = cart[i].GetItemTotal(quantities[i]);
            receipt += $"{cart[i].Name} x{quantities[i]} = ₱{subtotal:F2}\n";
            grandTotal += subtotal;
        }

        double discount = grandTotal >= 5000 ? grandTotal * 0.10 : 0;
        double finalTotal = grandTotal - discount;

        receipt += $"\nGrand Total: ₱{grandTotal:F2}\nDiscount: ₱{discount:F2}\nFinal Total: ₱{finalTotal:F2}\n\nThank you for purchasing!";
        MessageBox.Show(receipt, "Receipt");
    }
}

class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new CafeForm());
    }
}