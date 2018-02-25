using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    public class Program
    {
        public static Money money = new Money();

        static void Main(string[] args)
        {
            File.Delete(@"C:\VendingMachineFolder\Sales_Report.txt");
            File.Delete(@"C:\VendingMachineFolder\log.txt");

            bool applicationRunning = true;

            VendingItem.PopulateList();

            Menu.StartMenu();

            while (applicationRunning)
            {
                Console.Clear();
                Console.WriteLine($"Purchase Menu!\n\n(1) Feed Money\n(2) Select Product\n(3) Finish Transaction\n\nCurrent balance = {money.CurrentBalance.ToString("c")}");
                Console.Write("\nSelect an option...");
                string purchaseMenuSelection = Console.ReadLine();
                Console.Clear();

                switch (purchaseMenuSelection)
                {
                    case "1":
                        Menu.FeedMoneyMenu();
                        break;
                    case "2":
                        Menu.SelectProductMenu();
                        break;
                    case "3":
                        Menu.Checkout();

                        Console.WriteLine("\nWould you like to (Q)uit or (R)estart?");

                        if (Console.ReadLine().ToUpper() == "Q")
                        {
                            applicationRunning = false;
                        }
                        break;
                }

            }
            LogAudit.FinalSalesReport(money._totalSales);


        }
    }
}
