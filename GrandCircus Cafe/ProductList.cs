using System;
using System.Reflection.PortableExecutable;

namespace GrandCircus_Cafe
{
	public class ProductList
	{
        //Displays Menu in txt file
		public static List<Item> MenuFile()
		{
            string filePath = "../../../file.txt";

            //If file doesn't exist
            if (File.Exists(filePath) == false)
            {
                StreamWriter tempWriter = new StreamWriter(filePath);
                tempWriter.WriteLine("Drink|Cappuccino|Espresso with milk|3.99");
                tempWriter.WriteLine("Drink|Affogato|Espresso with Ice Cream|4.99");
                tempWriter.WriteLine("Drink|Iced Pistachio latte|Pistachio, Milk and Espresso|4.99");
                tempWriter.WriteLine("Drink|Americano|Espresso and Water|3.99");
                tempWriter.WriteLine("Drink|While Chocolate Mocha|Coffee, White Chocolate, Milk and Espresso|5.99");
                tempWriter.WriteLine("Food|Chocolate Croissant|Buttery Flaky pastry with chocolate filling|3.50");
                tempWriter.WriteLine("Food|Ham and Cheese Croissant|Buttery Flaky pastry with Ham and Cheddar|5.00");
                tempWriter.WriteLine("Drink|Redeye|Brewed Coffee with a shot of Espresso|3.99");
                tempWriter.WriteLine("Food|Blueberry Muffin|Freshly Baked Muffins|2.99");
                tempWriter.WriteLine("Food|Cream Cheese Bagel|Bagel + Cheez|4.99");
                tempWriter.WriteLine("Drink|Chai|Freshly brewed spiced tea|4.99");
                tempWriter.WriteLine("Food|COOKIE|Definitely not from Subway|2.00");
                tempWriter.WriteLine("Drink|Matcha|Green matcha|2.50");
                tempWriter.WriteLine("Drink|Baja Blast|Nectar of the Coding Gods|0.00");

                tempWriter.Close();
            }

            List<Item> Shop = new List<Item>();

            StreamReader reader = new StreamReader(filePath);

            while (true)
            {
                string line = reader.ReadLine();
                if (line == null) //If line is empty
                {
                    break;
                }
                else //If line is not empty
                {
                    string[] parts = line.Split("|");
                    Item product = new Item(parts[0], (parts[1]), (parts[2]), decimal.Parse(parts[3]));
                    Shop.Add(product);
                }
            }

            reader.Close(); //Always close when done
            return Shop;
        }

        //Adds items to txt file
        public static void WriteMenu(List<Item> writeItem)
        {
            string filePath = "../../../file.txt";
            StreamWriter writer = new StreamWriter(filePath); //Open
            foreach (Item i in writeItem)
            {
                writer.WriteLine($"{i.Category}|{i.Name}|{i.Description}|{i.Price}");
            }
            writer.Close(); //Always close
        }
    }
}