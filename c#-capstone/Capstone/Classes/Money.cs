using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Money
    {
        public decimal CurrentBalance { get; private set; }

        public decimal _quarters = 0;

        public decimal _dimes = 0;

        public decimal _nickels = 0;

        public decimal _pennies = 0;

        public decimal _totalSales = 0;



        public void FeedMoney(decimal money)
        {
            CurrentBalance += money;

            LogAudit.FeedMoneyLog(money, CurrentBalance);
        }

        public void Transaction(decimal money)
        {
            CurrentBalance -= money;
        }


        public void ChangeReturn(decimal balanceDueBack)
        {
            decimal totalMoneyBack = balanceDueBack;

            decimal remainer = totalMoneyBack;

            if (totalMoneyBack % 0.25m == 0)
            {
                _quarters = totalMoneyBack / 0.25m;
                remainer = 0;
            }
            else if (totalMoneyBack % 0.25m != 0)
            {
                remainer = totalMoneyBack % 0.25m;

                totalMoneyBack -= remainer;

                _quarters = totalMoneyBack / 0.25m;
            }

            totalMoneyBack = remainer;

            if (totalMoneyBack % 0.10m == 0)
            {
                _dimes = totalMoneyBack / 0.10m;

                remainer = 0;
            }
            else if (remainer % 0.10m != 0)
            {
                remainer = remainer % 0.10m;

                totalMoneyBack -= remainer;

                _dimes = totalMoneyBack / 0.10m;
            }

            totalMoneyBack = remainer;

            if (totalMoneyBack % 0.05m == 0)
            {
                _nickels = totalMoneyBack / 0.05m;

                remainer = 0;
            }
            else if (remainer % 0.05m != 0 && remainer > 0.05m)
            {
                remainer = remainer % 0.05m;

                totalMoneyBack -= remainer;

                _nickels = totalMoneyBack / 0.05m;
            }
            _pennies = remainer / 0.01m;


            CurrentBalance = 0;

        }





    }
}
