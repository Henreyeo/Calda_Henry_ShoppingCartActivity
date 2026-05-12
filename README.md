#  ◞🛒ˊˎ - Shopping Cart Activity (Enhanced) 🛒ᯓᡣ𐭩

![C#](https://img.shields.io/badge/Language-C%23-blue?logo=csharp)
![.NET](https://img.shields.io/badge/Framework-.NET-purple?logo=dotnet)
![Status](https://img.shields.io/badge/Status-Completed-success)
![Project Type](https://img.shields.io/badge/Type-Console%20Application-orange)

This Shopping Cart System is a simple C# console application that simulates a café ordering process. It allows users to view a menu, select items, input quantities, and add them to a cart.

## Enhanced Features
This enhanced cart version improves the overall shopping experience by making item handling more efficient, accurate, and user-friendly. It includes better quantity management, improved update and removal functions, and added safeguards to ensure smoother and more reliable cart operations.

##  Product Features

###  View All Products

```csharp
foreach (var p in products)
{
    p.Display();
}
```

###  Search Products by Name

```csharp
string search = Console.ReadLine().ToLower();

foreach (var p in products)
{
    if (p.Name.ToLower().Contains(search))
        p.Display();
}
```

###  Filter Products by Category

```csharp
string category = catChoice == 1 ? "Drinks" : "Dessert";

foreach (var p in products)
{
    if (p.Category == category)
        p.Display();
}
```

---

##  Cart System

* Add items to cart

```csharp
cart[count] = selected;
qty[count++] = q;
```

* Prevent duplicate items

```csharp
int index = FindItem(cart, count, selected.Id);

if (index != -1)
    qty[index] += q;
```

* Update quantity

```csharp
int diff = newQty - oldQty;
cart[u].RemainingStock -= diff;
qty[u] = newQty;
```

* Remove items

```csharp
cart[r].RemainingStock += qty[r];

for (int i = r; i < count - 1; i++)
{
    cart[i] = cart[i + 1];
    qty[i] = qty[i + 1];
}
count--;
```

* Clear cart

```csharp
for (int i = 0; i < count; i++)
    cart[i].RemainingStock += qty[i];

count = 0;
```

* Stock validation system

```csharp
if (q > selected.RemainingStock)
{
    Console.WriteLine("Not enough stock.");
}
```

---

##  Checkout System

* Auto receipt generation

```csharp
Console.WriteLine($"{cart[i].Name} x{qty[i]} = ₱{sub:F2}");
```

* Discount system (10% if ₱5000+)

```csharp
double discount = total >= 5000 ? total * 0.10 : 0;
```

* Payment validation

```csharp
if (double.TryParse(Console.ReadLine(), out payment) && payment >= finalTotal)
```

* Change computation

```csharp
Console.WriteLine($"Change: ₱{payment - finalTotal:F2}");
```

---

##  Order History

* Stores past transactions

```csharp
history[historyCount++] = new Order
{
    ReceiptNo = receiptCounter - 1,
    Date = DateTime.Now,
    FinalTotal = finalTotal
};
```

* Displays receipt number and date

```csharp
Console.WriteLine($"Receipt #{history[i].ReceiptNo:0000} | {history[i].Date}");
```

---

##  Stock System

* Automatic stock deduction

```csharp
selected.RemainingStock -= q;
```

* Stock restoration when removing items

```csharp
cart[r].RemainingStock += qty[r];
```

* Low stock alerts (≤ 5 items)

```csharp
if (p.RemainingStock <= 5)
{
    Console.WriteLine($"{p.Name} only {p.RemainingStock} left!");
}
```

---

# Commit History

## 1. Initial Commit – Basic System
- Product class implementation  
- Basic menu system  
- Simple cart functionality  

## 2. Input Validation + Discount System
- Added `int.TryParse()` validation  
- Implemented discount logic  
- Improved stock checking  

## 3. Part 2 System Upgrade
- Added search and category filtering  
- Added cart management system

## 4. Finalizing 
- Added order history tracking  
- Expanded product list  

---




The program uses a `Product` class to organize item details and includes basic features such as input validation, stock checking, duplicate item handling, cart limiting, and discount calculation. It was developed to apply fundamental programming concepts and to create a functional and easy-to-understand ordering system.

---


## Initial Coding

To begin this project, I reviewed the requirements and planned the overall structure of my program. I created the `Product` class with its fields and methods like `DisplayProduct()`, `GetItemTotal()`, `HasEnoughStock()`, and `DeductStock()`. Then I set up the store menu using an array of products and began coding the main flow, including user input with `int.TryParse()`, basic validations, and adding items to a cart with duplicate handling. My focus for this stage was to get the core structure working and ensure everything follows the required logic.

```csharp
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
```

---

## Code Improvement and Debugging

Following this, I created a concept for the type of shop I wanted to build, and I decided on a café setup. After that, I reviewed and refined my rough code with the help of ChatGPT to make it more organized, functional, and easier to understand. I specifically prompted ChatGPT to help format the code properly and identify possible errors or missing parts.

During this process, I discovered several issues in my initial version, such as the program not handling alphabetic or non-numeric inputs when selecting items from the menu, which required proper implementation of `int.TryParse()` for validation. I also realized that I had missed important requirements like setting a maximum cart capacity and applying a discount condition for totals above a certain amount. These improvements helped make my code more complete, user-friendly, and aligned with the given instructions.

```csharp
if (!int.TryParse(Console.ReadLine(), out productChoice))
{
    Console.WriteLine("Invalid input! Please enter a number.");
    continue;
}
```

```csharp
const int CART_LIMIT = 10;

if (cart.Count >= CART_LIMIT)
{
    Console.WriteLine("Cart is full.");
    break;
}
```

```csharp
double discount = 0;

if (grandTotal >= 5000)
{
    discount = grandTotal * 0.10;
}
```

---

## Finalizing and Debugging pt.2

I updated the menu by adding more desserts and drinks to make the café concept more complete. After that, I used AI during the final debugging phase to fix remaining issues, improve the readability of the code, and avoid spaghetti-like structure. I then created a verbose flowchart to clearly represent the program’s process. Finally, I conducted a last round of testing to ensure everything was working correctly before submitting the project.

---

## Conclusion

This Shopping Cart System was developed to apply key programming concepts such as object-oriented programming, input validation, loops, arrays, and list management in a practical console-based application. It successfully simulates a café ordering system where users can select products, manage quantities, and generate a final receipt with discount computation.

Through this activity, the program was improved through planning, debugging, and refinement, which helped enhance its structure, functionality, and usability. Overall, it demonstrates how core programming principles can be combined to build a working and organized system.

## Updated AI Prompts used:

- **Identify errors and fix the flow of the code.**  
  I used AI to identify and correct errors in my code. For example, I initially misused `int.TryParse()`, which prevented proper input validation from working as intended. In addition, I relied on AI to improve the overall flow of my program, as it was previously messy and unorganized. It also helped me add clear comments, making it easier to understand the purpose of each section of the code.

- **Fix errors**  
  There were errors in my code that I could not fully understand, locate, or fix on my own, so I used AI to help identify and resolve them.

- **Paraphrase and fix text.**  
  While working on the documentation, I used paraphrasing to make my explanations clearer and more coherent. This helped ensure that the content was well-structured, easy to understand, and suitable for evaluation.

- **Improve validation and program reliability.**
 I used AI to refine input validation using TryParse to prevent crashes from invalid inputs, as it was super confusing. It also assisted in improving the logic for payment validation, ensuring that insufficient payments are properly handled and that the system only proceeds when valid input is provided.

- **Improve Cart Functions.**
  I used AI to refine and improve the cart functionality of my system, especially in handling how items are added, updated, and removed. It helped me identify logic issues such as incorrect quantity updates and missing validations that could cause errors in the cart process.
  
---
