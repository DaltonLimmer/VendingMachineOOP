using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VendingItems
    {
        public string Location { get; }

        public string ProductName { get; }

        public decimal Price { get; }

        public int QuantityOnHand { get; set; }

        public string ProductTypeSound
        {
            get
            {
                string result = "";
                if (Location.Contains('A')) //     Chips
                {
                    result = "Crunch Crunch, Yum!";
                }
                if (Location.Contains('B')) //     Candy
                {
                    result = "Munch Munch, Yum!";
                }
                if (Location.Contains('C')) //    Drinks
                {
                    result = "Glug Glug, Yum!";
                }
                if (Location.Contains('D')) //     Gum
                {
                    result = "Chew Chew, Yum!";
                }

                return result;
            }
        }


        public VendingItems(string line)
        {
            string[] wholeLine = line.Split('|');

            Location = wholeLine[0];
            ProductName = wholeLine[1];
            Price = decimal.Parse(wholeLine[2]);
            QuantityOnHand = 5;

        }

        public void Transaction()
        {
            
            
                QuantityOnHand--;
            
            
        }
    }
}
