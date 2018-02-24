using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Menu
    {

        public static void StartMenu()
        {
            bool startMenu = true;

            while (startMenu)
            {
                Console.WriteLine("Welcome to the Vendo-Matic 500\nWhat would to like to do?\n");
                Console.WriteLine("(1) Display Vending Machine Items\n\n(2) Enter Purchase Menu");


                string mainMenu = Console.ReadLine();
                if (mainMenu == "1")
                {
                    Console.Clear();
                    foreach (VendingItem item in VendingItem.list)
                    {
                        Console.WriteLine(Rows.CreateRow(item.Location, item.ProductName, item.Price.ToString("c"), 15));
                    }

                    Console.Write("\nPress any key to return to main menu...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (mainMenu == "2")
                {
                    startMenu = false;
                    Console.Clear();
                }

            }
        }

        public static void FeedMoneyMenu()
        {
            bool feedMoney = true;

            while (feedMoney)
            {
                Console.Clear();
                Console.WriteLine("Please insert a ($1 $2 $5 $10)");
                Console.WriteLine($"Current balance = {Program.money.CurrentBalance.ToString("c")}");
                Console.Write("....$");
                int.TryParse(Console.ReadLine(), out int selection);
                switch (selection)
                {
                    case 1:
                        Program.money.FeedMoney(1);
                        break;
                    case 2:
                        Program.money.FeedMoney(2);
                        break;
                    case 5:
                        Program.money.FeedMoney(5);
                        break;
                    case 10:
                        Program.money.FeedMoney(10);
                        break;
                }
                Console.Clear();
                Console.WriteLine("Do you want to add more money?");
                Console.WriteLine($"New balance = {Program.money.CurrentBalance.ToString("c")}");
                Console.Write("Press (ENTER) for Yes or (N) for No ");


                if (Console.ReadLine().ToUpper() == "N")
                {
                    feedMoney = false;
                }
            }

        }

        public static void SelectProductMenu()
        {
            Console.WriteLine("Please Select Your Product Below\n");
            Console.WriteLine($"Current balance = {Program.money.CurrentBalance.ToString("c")}\n");

            foreach (VendingItem itm in VendingItem.list)
            {
                Console.WriteLine(Rows.CreateRow(itm.Location, itm.ProductName, itm.Price.ToString("c"), 15));
            }
            string userSelection = Console.ReadLine().ToUpper();

            string result = "";

            foreach (VendingItem item in VendingItem.list)
            {
                if (userSelection == item.Location)
                {
                    if (Program.money.CurrentBalance >= item.Price)
                    {
                        if (item.QuantityOnHand > 0)
                        {
                            LogAudit._boughtItems.Add(userSelection);
                            item.Transaction();
                            Program.money.Transaction(item.Price);
                            Program.money._totalSales += item.Price;
                            result = "thank you for your purchase!";
                            LogAudit.MasterTransaction(item.ProductName, item.Price, Program.money.CurrentBalance);
                            break;
                        }
                        else
                        {
                            result = "Out of stock";
                            break;
                        }
                    }
                    else
                    {
                        result = "Not enough money";
                        break;
                    }
                }
                else if (userSelection == "")
                {
                    result = "PLEASE SELECT AN ITEM";
                }
                else
                {
                    result = "Not a valid Item selection";
                }
            }
            Console.WriteLine(result);
            System.Threading.Thread.Sleep(1000);
        }
        public static void Checkout()
        {
            foreach (VendingItem item in VendingItem.list)
            {
                foreach (string i in LogAudit._boughtItems)
                {
                    if (i == item.Location)
                    {
                        Console.WriteLine(item.ProductTypeSound);
                    }
                }
            }

            string grandTotal = Program.money.CurrentBalance.ToString("c");

            LogAudit.GiveChangeLog(Program.money.CurrentBalance);
            Program.money.ChangeReturn(Program.money.CurrentBalance);
            Console.Write("\nYour Change is...\n");
            Console.WriteLine(Rows.CreateRow2($"{Program.money._quarters} Quarters", $"{Program.money._dimes} Dimes", $"{Program.money._nickels} Nickels", 15));
            Console.WriteLine($"\nFor a Grand Total of {grandTotal}");


            Console.ReadKey();



        }
    }
}
