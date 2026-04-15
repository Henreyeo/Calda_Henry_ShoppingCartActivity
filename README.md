#  ༘ ˚⋆🛍️ ｡⋆ 🛒 Shopping Cart Activity 🛒 ⋆ 𖦹 🛍️ .✧˚  

![C#](https://img.shields.io/badge/Language-C%23-blue?logo=csharp)
![.NET](https://img.shields.io/badge/Framework-.NET-purple?logo=dotnet)
![Status](https://img.shields.io/badge/Status-Completed-success)
![Project Type](https://img.shields.io/badge/Type-Console%20Application-orange)

This Shopping Cart System is a simple C# console application that simulates a café ordering process. It allows users to view a menu, select items, input quantities, and add them to a cart.

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

## AI Prompts used:

- **Identify errors and fix the flow of the code.**  
  I used AI to identify and correct errors in my code. For example, I initially misused `int.TryParse()`, which prevented proper input validation from working as intended. In addition, I relied on AI to improve the overall flow of my program, as it was previously messy and unorganized. It also helped me add clear comments, making it easier to understand the purpose of each section of the code.

- **Fix errors**  
  There were errors in my code that I could not fully understand, locate, or fix on my own, so I used AI to help identify and resolve them.

- **Paraphrase and fix text.**  
  While working on the documentation, I used paraphrasing to make my explanations clearer and more coherent. This helped ensure that the content was well-structured, easy to understand, and suitable for evaluation.
