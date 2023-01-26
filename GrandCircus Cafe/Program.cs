using GrandCircus_Cafe;
using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

List<Item> Menu = new List<Item>()
{
    new Item("Drink", "Cappuccino", "Espresso with milk"),
    new Item("Drink", "Affogato", "Espresso with Ice Cream"),
    new Item("Drink", "Iced Pistachio latte", "Pistachio, Milk and Espresso"),
    new Item("Drink", "Americano", "Espresso and Water"),
    new Item("Drink", "While Chocolate Mocha", "Coffee, White Chocolate, Milk, and Espresso"),
    new Item("Food", "Chocolate Croissant", "Buttery Flaky pastry with chocolate filling"),
    new Item("Food", "Ham and Cheese Croissant", "Buttery Flaky pastry with Ham and Cheddar"),
    new Item("Drink", "Redeye", "Brewed Coffee with a shot of Espresso"),
    new Item("Food", "Blueberry Muffin", "Freshly Baked Muffins"),
    new Item("Food", "Cheeam Cheese Bagel", "Bagel + Cheez"),
    new Item("Drink", "Chai", "Freshly brewed spiced tea"),
    new Item("Food", "COOKIE", "Defiently not from Subway"),
    new Item("Drink", "Matcha", "Green matcha"),
    new Item("Drink", "Baja Blast", "Nectar of the coding gods")
};

DisplayMenu(Menu);











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
