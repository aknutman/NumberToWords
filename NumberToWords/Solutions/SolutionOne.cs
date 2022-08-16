using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords.Solutions
{
    internal class SolutionOne : ISolution
    {
        public string NumberToWords(long num)
        {
            long tn = num / 1000000000000;
            long bn = (num / 1000000000) % 1000;
            long mn = (num / 1000000) % 1000;
            long th = (num / 1000) % 1000;
            long hd = num % 1000;

            string result = "";

            if ((tn + bn + mn + th + hd) == 0)
            {
                result = $"{result}Zero";
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

            return result;
        }

        private static string Words(long num)
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
