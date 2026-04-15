
 ༘ ˚⋆🛍️ ｡⋆ 🛒 Shopping Cart Activity 🛒 ⋆ 𖦹 🛍️ .✧˚  
---
## Initial Coding
To begin the project, I reviewed the requirements and planned the overall structure of the program. I implemented a `Product` class with its corresponding fields and methods:
````markdown




```csharp
class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int RemainingStock;

    public void DisplayProduct() { }
    public double GetItemTotal(int quantity) { return Price * quantity; }
    public bool HasEnoughStock(int quantity) { return quantity <= RemainingStock; }
    public void DeductStock(int quantity) { RemainingStock -= quantity; }
}
````

After defining the class, I created the store menu using an array of products:

```csharp
Product[] products = new Product[]
{
    new Product { Id = 1, Name = "Spanish Latte", Price = 120, RemainingStock = 10 },
    new Product { Id = 2, Name = "Matcha Latte", Price = 120, RemainingStock = 15 }
};
```

I then began implementing the main program flow, including user input handling using `int.TryParse()`:

```csharp
int productChoice;
if (!int.TryParse(Console.ReadLine(), out productChoice))
{
    Console.WriteLine("Invalid input! Please enter a number.");
}
```

Basic validation and cart functionality were also added, including handling duplicate items:

```csharp
int index = cart.FindIndex(p => p.Id == selected.Id);

if (index != -1)
{
    quantities[index] += qty;
}
else
{
    cart.Add(selected);
    quantities.Add(qty);
}
```

The main goal at this stage was to establish a working structure that follows the required program logic.

---

##  Code Improvement and Debugging

After completing the initial version, I decided to develop a **café-themed shopping system**. I reviewed and refined my code with the assistance of AI to improve its structure, readability, and functionality.

One major issue I encountered was improper input handling. The program initially failed to handle non-numeric inputs, which was resolved by correctly implementing:

```csharp
if (!int.TryParse(Console.ReadLine(), out productChoice))
{
    Console.WriteLine("Invalid input! Please enter a number.");
    continue;
}
```

I also identified missing requirements, such as implementing a cart limit:

```csharp
const int CART_LIMIT = 10;

if (cart.Count >= CART_LIMIT)
{
    Console.WriteLine("Cart is full.");
    break;
}
```

Additionally, I implemented a discount feature for large purchases:

```csharp
double discount = 0;

if (grandTotal >= 5000)
{
    discount = grandTotal * 0.10;
}
```

These improvements enhanced the program’s reliability, usability, and alignment with the given instructions.

---

##  Finalizing and Debugging (Phase 2)

In the final phase, I expanded the menu by adding more desserts and beverages to match the café concept better.

I then performed final debugging and code refinement to improve readability and avoid a disorganized or “spaghetti code” structure. This included organizing logic and ensuring consistent formatting.

Additionally, I created a **detailed flowchart** to visually represent the program’s logic and processes.

Finally, I conducted comprehensive testing to ensure all features were working correctly before submission.

---

##  AI Prompts Used:

###  "Identify errors and fix code flow."

AI was used to detect and correct errors in the program. One example was the incorrect use of `int.TryParse()`, which initially caused input validation issues. AI also helped restructure the code for better readability and added comments to clarify each section.

---

###  "Fix errors."

Some errors were difficult to understand and locate independently. AI assistance helped identify and resolve these issues efficiently.

---

###  "Paraphrase and improve documentation."

During the documentation process, paraphrasing was used to improve clarity and coherence. This ensured that the explanations were well-structured, easy to understand, and appropriate for academic evaluation.

---



