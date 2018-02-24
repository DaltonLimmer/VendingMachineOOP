using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Rows
    {
        public static string CreateRow2(string col1, string col2, string col3, int colWidth)
        {
            string result = "";
            result += CreateColumn(col1, colWidth);
            result += CreateColumn(col2, colWidth);
            result += CreateColumn(col3, colWidth);
            return result;
        }

        public static string CreateRow(string col1, string col2, string col3, int colWidth)
        {
            string result = "";
            result += CreateColumn(col1, colWidth - 11);
            result += CreateColumn(col2, colWidth + 5);
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

    }
}
