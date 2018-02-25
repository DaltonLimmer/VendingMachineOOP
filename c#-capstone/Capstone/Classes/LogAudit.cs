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

        public static List<string> _boughtItems = new List<string>();

        public static void GiveChangeLog( decimal currentBalance)
        {
            using (StreamWriter sw = new StreamWriter($@"C:\VendingMachineFolder\log.txt", true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")}   " + Rows.CreateRow3("GIVE CHANGE:", currentBalance.ToString("c"),  "$0.00",10));
            }
        }


        public static void FeedMoneyLog(decimal money, decimal currentBalance)
        {

            Directory.CreateDirectory(@"C:\VendingMachineFolder");

            using (StreamWriter sw = new StreamWriter($@"C:\VendingMachineFolder\log.txt", true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")}   " + Rows.CreateRow3("FEED MONEY:", money.ToString("c"), currentBalance.ToString("c"),10));

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
                sw.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")}   " + Rows.CreateRow3(itemName, currentBalance.ToString("c"), (currentBalance - itemPrice).ToString("c"), 10));
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
