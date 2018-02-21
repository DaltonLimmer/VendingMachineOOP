using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDExercises
{
    public class StringCalculator
    {

        /// <summary>
        /// intput string of anything with number, add number's in string together!
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>returns sum of numbers in string</returns>
        /// 
        public int Add(string numbers)
        {
            int result = 0;


            char delimeter = ';';


            if (numbers.Contains('\n')||(numbers.Contains(',')))
            {
                string[] multiNum;

                multiNum = numbers.Split('\n',',',delimeter);

                foreach (string n in multiNum)
                {
                    int.TryParse(n, out int num);

                    result += num;
                }
            }
            else
            {
                int.TryParse(numbers, out int singleNum);

                result = singleNum;
            }

            return result;
        }

    }
}
