using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    class Program
    {
        private static string _filePath = @"C:\Users\Mataan Abucar\workspace\team4-c-week4-pair-exercises\c#-capstone\etc\vendingmachine.csv";
        private static List<VendingItems> vMachine = new List<VendingItems>();
        private static Money money = new Money();

        static void Main(string[] args)
        {
            bool startMenu = true;

            try
            {
                using (StreamReader sr = new StreamReader(_filePath))
                {

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        VendingItems item = new VendingItems(line);
                        vMachine.Add(item);
                    }
                }
            }
            catch (IOException e) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e);
            }


            while (startMenu)
            {
                Console.WriteLine("Vendo-Matic 500\nWhat would yo like to do?");
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");

                string mainMenu = Console.ReadLine();
                if (mainMenu == "1")
                {
                    Console.Clear();
                    foreach (VendingItems itm in vMachine)
                    {
                        Console.WriteLine(CreateRow(itm.Location, itm.ProductName, itm.Price.ToString("c"), 15));

                    }
                    Console.Write("\nPress any key to return to main menu...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (mainMenu=="2")
                {
                    startMenu = false;
                    Console.Clear();
                }

            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Purchase Menu!\n");
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine($"\nCurrent balance = {money.CurrentBalance.ToString("c")}");
                
                string purchaseMenuSelection = Console.ReadLine();

                bool feedMoney = true;

                if (purchaseMenuSelection == "1")
                {
                    while (feedMoney)
                    {
                        Console.Clear();
                        Console.Write("Please insert a ($1 $2 $5 $10)");
                        Console.WriteLine($"\nCurrent balance = {money.CurrentBalance.ToString("c")}");
                        Console.Write("$");
                        int.TryParse(Console.ReadLine(), out int selection);

                        switch (selection)
                        {
                            case 1:
                                money.FeedMoney(1);
                                break;
                            case 2:
                                money.FeedMoney(2);
                                break;
                            case 5:
                                money.FeedMoney(5);
                                break;
                            case 10:
                                money.FeedMoney(10);
                                break;

                            //case 0:
                            //    feedMoney = false;
                            //    break;
                        }
                        Console.Clear();
                        Console.WriteLine($"New balance = {money.CurrentBalance.ToString("c")}");
                        Console.WriteLine("Do you want to add more money?\n(Y)es or (N)o");
                        if (Console.ReadLine().ToUpper() == "N")
                        {
                            feedMoney = false;
                        }
                    }
                } //<----------FEED MONEY
                if (purchaseMenuSelection == "2") //<----------- Select product
                {
                    foreach (VendingItems itm in vMachine)
                    {
                        Console.WriteLine(CreateRow(itm.Location, itm.ProductName, itm.Price.ToString("c"), 15));

                    }

                    string userSelection = Console.ReadLine().ToUpper();
                    MasterTransaction(userSelection);
                    
                }
                if (purchaseMenuSelection == "3")
                {

                    ChangeReturn(money.CurrentBalance)





                }


            }


        }













        private static void ChangeReturn(decimal balanceDueBack)
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


        private static string CreateRow(string col1, string col2, string col3, int colWidth)
        {
            string result = "";
            result += CreateColumn(col1, colWidth-11);
            result += CreateColumn(col2, colWidth+5);
            result += CreateColumn(col3, colWidth);
            return result;
        }
        private static string CreateColumn(string col, int colWidth)
        {
            string result = "";
            if (col.Length > colWidth)
            { result += col.Substring(0, colWidth); }
            else
            {
                result += col;
                int padding = colWidth - col.Length;
                for (int i = 0; i < padding; i++)
                {
                    result += " ";
                }
            }
            return result;
        }



        private static void MasterTransaction(string userSelect)
        {
            string result = "";
            foreach (VendingItems item in vMachine)
            {
                if (userSelect == item.Location && item.QuantityOnHand > 0 && money.CurrentBalance>= item.Price)
                {
                    item.Transaction();
                    money.Transaction(item.Price);
                    result = "thank you for your purchase!";
                }
                else if (userSelect!= item.Location)
                {
                    result = "Not a valid Item selection";
                }
                else if (money.CurrentBalance < item.Price)
                {
                    result = "Not enough money";
                }
                else if (item.QuantityOnHand == 0)
                {
                    result = "Out of stock";
                }
                

            }
            
            Console.WriteLine(result);

        }
    }
}
