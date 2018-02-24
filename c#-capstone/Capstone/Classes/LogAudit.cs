using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class LogAudit
    {

        private static DateTime time = DateTime.Now;

        public static List<string> _boughtItems = new List<string>();

        public static void GiveChangeLog( decimal currentBalance)
        {
            using (StreamWriter sw = new StreamWriter($@"C:\VendingMachineFolder\log.txt", true))
            {
                sw.WriteLine($"{time} GIVE CHANGE:  {currentBalance.ToString("c")}  $0.00");
            }
        }


        public static void FeedMoneyLog(decimal money, decimal currentBalance)
        {

            Directory.CreateDirectory(@"C:\VendingMachineFolder");

            using (StreamWriter sw = new StreamWriter($@"C:\VendingMachineFolder\log.txt", true))
            {
                sw.WriteLine($"{time}  FEED MONEY:  {money.ToString("c")}   {currentBalance.ToString("c")}");

            }
        }


        public static void MasterTransaction(string itemName, decimal itemPrice, decimal currentBalance)
        {
            using (StreamWriter sw = new StreamWriter($@"C:\VendingMachineFolder\Sales_Report.txt", true))
            {
                sw.WriteLine($"{itemName}|{itemPrice}");
            }
            using (StreamWriter sw = new StreamWriter($@"C:\VendingMachineFolder\log.txt", true))
            {
                sw.WriteLine($"{time}   {itemName}   {currentBalance.ToString("c")} {(currentBalance - itemPrice).ToString("c")}");
            }

        }


        public static void FinalSalesReport(decimal money)
        {
            using (StreamWriter sw = new StreamWriter($@"C:\VendingMachineFolder\Sales_Report.txt", true))
            {
                sw.WriteLine();
                sw.WriteLine($"***TOTAL SALES*** {money}");
            }

        }




    }
}
