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

            decimal remainder = totalMoneyBack;

            if (totalMoneyBack % 0.25m == 0)
            {
                _quarters = totalMoneyBack / 0.25m;
                remainder = 0;
            }
            else if (totalMoneyBack % 0.25m != 0)
            {
                remainder = totalMoneyBack % 0.25m;

                totalMoneyBack -= remainder;

                _quarters = totalMoneyBack / 0.25m;
            }

            totalMoneyBack = remainder;

            if (totalMoneyBack % 0.10m == 0)
            {
                _dimes = totalMoneyBack / 0.10m;

                remainder = 0;
            }
            else if (remainder % 0.10m != 0)
            {
                remainder = remainder % 0.10m;

                totalMoneyBack -= remainder;

                _dimes = totalMoneyBack / 0.10m;
            }

            totalMoneyBack = remainder;

            if (totalMoneyBack % 0.05m == 0)
            {
                _nickels = totalMoneyBack / 0.05m;

                remainder = 0;
            }
            else if (remainder % 0.05m != 0 && remainder > 0.05m)
            {
                remainder = remainder % 0.05m;

                totalMoneyBack -= remainder;

                _nickels = totalMoneyBack / 0.05m;
            }
            _pennies = remainder / 0.01m;


            CurrentBalance = 0;

        }





    }
}
