using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Money
    {

        public decimal CurrentBalance { get; private set; }


        



        public void FeedMoney(decimal money)
        {
            CurrentBalance += money;
        }


        public void Transaction(decimal money)
        {
            
            CurrentBalance -= money;
        }

        public static void ChangeReturn(decimal balanceDueBack)
        {
            decimal totalMoneyBack = balanceDueBack;

            decimal remainer = totalMoneyBack;
            decimal quarters = 0;
            decimal dimes = 0;
            decimal nickels = 0;
            decimal pennies = 0;

            if (totalMoneyBack % 0.25m == 0)
            {
                quarters = totalMoneyBack / 0.25m;
            }
            else if (totalMoneyBack % 0.25m != 0)
            {
                remainer = totalMoneyBack % 0.25m;

                totalMoneyBack -= remainer;

                quarters = totalMoneyBack / 0.25m;
            }
            totalMoneyBack = remainer;

            if (remainer % 0.10m != 0)
            {
                remainer = remainer % 0.10m;

                totalMoneyBack -= remainer;

                dimes = totalMoneyBack / 0.10m;
            }
            totalMoneyBack = remainer;

            if (remainer % 0.05m != 0 && remainer > 0.05m)
            {
                remainer = remainer % 0.05m;

                totalMoneyBack -= remainer;

                nickels = totalMoneyBack / 0.05m;
            }
            pennies = remainer / 0.01m;



        }










        //Currency.Add("Ten", 10);
        //Currency.Add("Five", 5);
        //Currency.Add("Dollar", 1);
        //Currency.Add("Quarter", 0.25m);
        //Currency.Add("Dime", 0.10m);
        //Currency.Add("Nickel", 0.05m);
        //Currency.Add("Penny", 0.01m);
    }
}
