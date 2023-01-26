using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircus_Cafe
{
    public class Item
    {
        //properties
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
        //public string Size { get; set; }
        public decimal Price { get; set; }
        //public int LoyaltyPoints { get; set; }


        //constructor
        public Item(string _category, string _name, string _description, decimal _price)
        {
            Category = _category;
            Name = _name;
            Description = _description;
            Price = _price;
            //ID = _id;    
        }



        //methods

    }
}
