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
