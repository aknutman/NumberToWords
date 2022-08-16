using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords.Solutions
{
    internal class SolutionOne : ISolution
    {
        /*
         * This class responsible for this particular algorithm only
         * Accept string input, convert to number, convert number to words, and return the words string
         */

        public string NumberToWords(string inputValue)
        {
            string result = "";

            if (UInt64.TryParse(inputValue, out ulong num))
            {
                ulong qn = (num / 1000000000000000000) % 1000;
                ulong qd = (num / 1000000000000000) % 1000;
                ulong tn = (num / 1000000000000) % 1000;
                ulong bn = (num / 1000000000) % 1000;
                ulong mn = (num / 1000000) % 1000;
                ulong th = (num / 1000) % 1000;
                ulong hd = num % 1000;

                if ((qn + qd + tn + bn + mn + th + hd) == 0)
                {
                    result = $"{result}Zero";
                }
                if (qn > 0)
                {
                    result = $"{result}{Words(qn)}Quintillion ";
                }
                if (qd > 0)
                {
                    result = $"{result}{Words(qd)}Quadrillion ";
                }
                if (tn > 0)
                {
                    result = $"{result}{Words(tn)}Trillion ";
                }
                if (bn > 0)
                {
                    result = $"{result}{Words(bn)}Billion ";
                }
                if (mn > 0)
                {
                    result = $"{result}{Words(mn)}Million ";
                }
                if (th > 0)
                {
                    result = $"{result}{Words(th)}Thousand ";
                }
                if (hd > 0)
                {
                    result = $"{result}{Words(hd)}";
                }
            }
            else
            {
                result = "Input is not a number, negative number, or being too big!";
            }

            return result;

        }

        private static string Words(ulong num)
        {
            string[] digits = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            string result = "";

            if ((num / 100) > 0)
            {
                result = $"{result}{digits[num / 100]} Hundred ";
            }

            if ((num % 100) < 20 && (num % 100) > 0)
            {
                result = $"{result}{digits[num % 100]} ";
            }
            else
            {
                result = $"{result}{tens[(num / 10) % 10]} ";
                if ((num % 10) > 0)
                {
                    result = $"{result}{digits[num % 10]} ";
                }
            }

            return result;
        }
    }
}
