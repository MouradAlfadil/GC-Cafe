using GrandCircus_Cafe;
using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

List<Item> Menu = new List<Item>()
{
    new Item("Drink", "Cappuccino", "Espresso with milk", 3.99m),
    new Item("Drink", "Affogato", "Espresso with Ice Cream", 4.99m),
    new Item("Drink", "Iced Pistachio latte", "Pistachio, Milk and Espresso", 4.99m),
    new Item("Drink", "Americano", "Espresso and Water", 3.99m),
    new Item("Drink", "While Chocolate Mocha", "Coffee, White Chocolate, Milk, and Espresso", 5.99m),
    new Item("Food", "Chocolate Croissant", "Buttery Flaky pastry with chocolate filling", 3.50m),
    new Item("Food", "Ham and Cheese Croissant", "Buttery Flaky pastry with Ham and Cheddar", 5.00m),
    new Item("Drink", "Redeye", "Brewed Coffee with a shot of Espresso", 3.99m),
    new Item("Food", "Blueberry Muffin", "Freshly Baked Muffins", 2.99m),
    new Item("Food", "Cheeam Cheese Bagel", "Bagel + Cheez", 4.99m),
    new Item("Drink", "Chai", "Freshly brewed spiced tea", 4.99m),
    new Item("Food", "COOKIE", "Defiently not from Subway", 2.00m),
    new Item("Drink", "Matcha", "Green matcha", 2.50m),
    new Item("Drink", "Baja Blast", "Nectar of the coding gods", 0.00m)
};

List<Item> cart = new List<Item>();

Console.WriteLine("Welcome to Grand Circus Cafe! Home to the 'Nectar of the Coding Gods'.");

Console.WriteLine();


Console.Write("Here is our Menu, please select a number: ");

bool runProgram = true;

//User Input
do
{

        DisplayMenu(Menu);

    int choice = int.Parse(Console.ReadLine());
    if (Menu.Where(i => i.ID == choice).Count() == 1)
    {
        Item SelectItem = Menu.First(i => i.ID == choice);
        Console.Write($"You selected {SelectItem.Name}, would you like to order more than one? (y/n): ");
        string multipleChoice = Console.ReadLine();
        if (multipleChoice == "y")
        {
            Console.WriteLine($"How many {SelectItem.Name} would you like to order?");
            int quantity = int.Parse(Console.ReadLine());

            for (int q = 1; q <= quantity; q++)
            {
                cart.Add(SelectItem);
            }
        }
        else if (multipleChoice == "n")
        {
            cart.Add(SelectItem);
        }
        else
        {
            Console.WriteLine("Please respond with a \"y\" or a \"n\"");
            Console.ReadLine();
        }
        Console.WriteLine($"{SelectItem.Name} has been added to your cart.  Would you like to add anything else to your order? (y/n)");
        string cont = Console.ReadLine().ToLower().Trim();
        if(cont == "y")
        {
            runProgram = true;
        }
        else if(cont == "n")
        {
            runProgram = false;
            break;
        }
        else
        {
            Console.WriteLine("Please respond with a \"y\" or a \"n\"");
            Console.ReadLine();
        }

    }
} while (runProgram=true);




decimal subTotal = 0;


foreach (Item c in cart)
{
    Console.WriteLine(c.Name);
    subTotal = subTotal + c.Price;
}
Console.WriteLine(subTotal);










static void DisplayMenu(List<Item> AllItems)
{
    int counter = 1;
    Console.WriteLine("Drinks");
    Console.WriteLine("============================");
    foreach (Item i in AllItems.Where(i => i.Category.ToLower() == "drink").OrderBy(i => i.Name))
    {
        i.ID = counter;
        Console.WriteLine($"{i.ID}: {i.Name}");
        counter++;
    }
    Console.WriteLine("");
    Console.WriteLine("Food");
    Console.WriteLine("============================");
    foreach (Item i in AllItems.Where(i => i.Category.ToLower() == "food").OrderBy(i => i.Name))
    {
        i.ID = counter;
        Console.WriteLine($"{i.ID}: {i.Name}");
        counter++;
    }
}
