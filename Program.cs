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
}
