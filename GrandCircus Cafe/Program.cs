using GrandCircus_Cafe;
using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
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
    new Item("Food", "Cream Cheese Bagel", "Bagel + Cheez", 4.99m),
    new Item("Drink", "Chai", "Freshly brewed spiced tea", 4.99m),
    new Item("Food", "COOKIE", "Definitely not from Subway", 2.00m),
    new Item("Drink", "Matcha", "Green matcha", 2.50m),
    new Item("Drink", "Baja Blast", "Nectar of the Coding Gods", 0.00m)
};

List<Item> cart = new List<Item>();

Console.WriteLine("Welcome to Grand Circus Cafe! Home to the 'Nectar of the Coding Gods'.\n");

//Restart Entire Program
bool restart = true;
while (restart)
{
    DisplayMenu(Menu);

    bool runProgram = true;
    do
    {
        int choice = 0;
        while (true)
        {
            try
            {
                //User Input
                Console.Write("Please select an item number: ");
                choice = int.Parse(Console.ReadLine());
                if (choice > Menu.Count)
                {
                    Console.WriteLine($"The Choice you entered does not exist please input a value between 1-{Menu.Count}.");
                }
                else
                {
                    break;
                }
            }

            catch (Exception)
            {
                Console.WriteLine("Please enter valid input.");
            }
        }
        if (Menu.Where(i => i.ID == choice).Count() == 1)
        {
            Item SelectItem = Menu.First(i => i.ID == choice);
            Console.Write($"You selected {SelectItem.Name}, would you like to order more than one? (y/n): ");
            while (true)
            {
                string multipleChoice = Console.ReadLine().Trim().ToLower();
                try
                {
                    if (multipleChoice == "y")
                    {
                        Console.WriteLine($"How many {SelectItem.Name}s would you like to order?");
                        int quantity = int.Parse(Console.ReadLine());

                        for (int q = 1; q <= quantity; q++)
                        {
                            cart.Add(SelectItem);
                        }
                        break;
                    }
                    else if (multipleChoice == "n")
                    {
                        cart.Add(SelectItem);
                        break;
                    }
                    else
                    {
                    }
                }

                catch(Exception)
                {
                    Console.WriteLine("Please enter valid input.");
                }
            }

            Console.Write($"{SelectItem.Name} has been added to your cart.  Would you like to add anything else to your order? (y/n): ");
            while (true)
            {
                string cont = Console.ReadLine().ToLower().Trim();
                if (cont == "y")
                {
                    runProgram = true;
                    Console.Write("Would you like to see the Menu again? (y/n): ");
                    string menuAgain = Console.ReadLine().ToLower().Trim();

                    while (true)
                    {
                        if (menuAgain == "y")
                        {
                            DisplayMenu(Menu);
                            break;
                        }
                        else if (menuAgain == "n")
                        {
                            break;
                        }
                        else
                        {
                            Console.Write("Invalid input, please enter (y/n): ");
                            menuAgain = Console.ReadLine().ToLower().Trim();
                        }
                    }
                    break;
                }
                else if (cont == "n")
                {
                    runProgram = false;

                    break;
                }
                else
                {
                    Console.WriteLine("Please respond with a \"y\" or a \"n\"");
                }
            }
            Console.WriteLine();
        }

    } while (runProgram == true);

    decimal SubTotal = 0;
    decimal Tax = 0;
    decimal GrandTotal = 0;
    int num = 1;

    List<Item> DistinctCategories = cart.GroupBy(dc => dc.ID).Select(dc => dc.First()).ToList();

    foreach (Item c in DistinctCategories)
    {
        num = cart.Where(i => i.ID == c.ID).Count();
        Console.WriteLine(string.Format("{0,-5} {1,-25} ${2,0}", num, c.Name, (c.Price * num)));

        SubTotal = SubTotal + (c.Price * num);
    }

    Tax = 0.06m * SubTotal;
    GrandTotal = SubTotal + Tax;

    //Display Bill
    Console.WriteLine($"BILL");
    Console.WriteLine($"Subtotal:${Decimal.Round(SubTotal, 2)} Tax:${Decimal.Round(Tax, 2)} Total:${Decimal.Round(GrandTotal, 2)}\n");

    Console.Write("How would you like to pay? Cash, Credit, or Check? ");
    string paymentMethod = Console.ReadLine().ToLower().Trim();
    while (true)
    {
        if (paymentMethod != "cash" && paymentMethod != "credit" && paymentMethod != "check")
        {
            Console.WriteLine("You done fucked up, please enter valid payment method.");
            paymentMethod = Console.ReadLine().ToLower().Trim();
        }
        else
        {
            break;
        }
    }

    decimal cashTender = 0m;

    //Accepting payment
    switch (paymentMethod)
    {
        case ("cash"):
        {
                while (true)
                {
                    Console.Write("Please enter the amount of cash provided: ");
                    cashTender = decimal.Parse(Console.ReadLine());

                    if (cashTender >= GrandTotal)
                    {
                        break;
                    }
                    else if (cashTender < GrandTotal)
                    {
                        Console.WriteLine("Insufficient funds.");
                    }
                }
                break;
        }

        case ("credit"):
        {
                while (true)
                {
                    Console.WriteLine("Please type in your Credit Card number");
                    string ccNumber = Console.ReadLine();

                    if (Regex.IsMatch(ccNumber, "^4[0-9]{12}(?:[0-9]{3})?$"))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error: Please try again.");
                    }
                }
                while (true)
                {

                    Console.WriteLine("Enter Exp Date: (MM/YYYY)");
                    string ccExp = Console.ReadLine();

                    if (Regex.IsMatch(ccExp, "(0[1-9]|10|11|12)/20[0-9]{2}$"))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error: Please try again.");
                    }
                }
                while (true)
                {
                    Console.WriteLine("Enter CVV");
                    string cvv = Console.ReadLine();

                    if (Regex.IsMatch(cvv, "^[0-9]{3}$")|| Regex.IsMatch(cvv, "^[0-9]{4}$"))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error: Please try again.");
                    }
                }
                break;
        }

        case ("check"):
        {
                while (true)
                {
                    Console.WriteLine("Please enter check number:");
                    string checkNumber = Console.ReadLine();
                    if (Regex.IsMatch(checkNumber, "^[0-9]{4}$"))
                    {
                        Console.WriteLine("Here is a pen, please sign the bottom:");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This check is VOID; give me money");
                    }
                }
                break;
        }

        default:
            {
                Console.WriteLine("You have you no money, go wash dishes");
                break;
            }
    }

    //Display Receipt
    Console.WriteLine("Receipt");
    Console.WriteLine("========================================");
    Console.WriteLine(string.Format("{0,-5} {1,-25} {2,0}", "Quantity", "Name", "Price"));

    Console.WriteLine("========================================");
    Console.WriteLine($"Subtotal:{Decimal.Round(SubTotal, 2)} Tax:{Decimal.Round(Tax, 2)} Grand Total: {Decimal.Round(GrandTotal, 2)}");
    if(paymentMethod== "cash")
    {
        Console.WriteLine($"${Decimal.Round(cashTender-GrandTotal, 2)} is your change");
    }

    Console.WriteLine();
    exitProgram(ref restart);
}

Console.WriteLine("Thank you and have a wonderful day!");


//Methods
static void DisplayMenu(List<Item> AllItems)
{
    int counter = 1;
    Console.WriteLine("Drinks");
    Console.WriteLine("============================");
    foreach (Item i in AllItems.Where(i => i.Category.ToLower() == "drink").OrderBy(i => i.Name))
    {
        i.ID = counter;
        Console.WriteLine($"{i.ID}: {i.Name}");
        Console.WriteLine($"\t{i.Description}");
        counter++;
    }
    Console.WriteLine("");
    Console.WriteLine("Food");
    Console.WriteLine("============================");
    foreach (Item i in AllItems.Where(i => i.Category.ToLower() == "food").OrderBy(i => i.Name))
    {
        i.ID = counter;
        Console.WriteLine($"{i.ID}: {i.Name}");
        Console.WriteLine($"\t{i.Description}");
        counter++;
    }

    Console.WriteLine();
}

static void exitProgram(ref bool x)
{
    while (true)
    {
        Console.Write("Would you like to start another order? (y/n) : ");
        string answer = Console.ReadLine().ToLower().Trim();

        if (answer == "y")
        {
            break;
        }
        else if (answer == "n")
        {
            x = false;
            break;
        }
        else
        {
            Console.WriteLine("Invalid Entry.");
        }
    }
}