namespace NumberToWords.Solutions
{
    internal class SolutionOne : ISolution
    {
        /*
         * This class responsible for this particular algorithm only
         * Accept string input, convert to number, convert number to words, and return the words string
         */

        static string formatMessage = @"
==========================================
* Accepted format is 123.45
* Number can be up to a Quintillion
* Accept 2 digit decimal only
==========================================
";

        public string NumberToWords(string inputValue)
        {
            string result = "";

            string[] inputs = inputValue.Split('.');

            if (!inputValue.Contains('.'))
            {
                result = "Only accept dot in decimal separator.\n" + formatMessage;
                throw new Exception(result);
            }

            if (inputs.Length > 2)
            {
                result = "Too much dot there...:P\n" + formatMessage;
                throw new Exception(result);
            }

            if (inputs[1].Length != 2)
            {
                result = "Only accept 2 digit decimal only\n" + formatMessage;
                throw new Exception(result);
            }

            var firstPart = Separation(inputs[0]);
            var secondPart = Separation(inputs[1]);

            result = $"{firstPart}Dollars And {secondPart}cents";

            return result.ToUpper();

        }

        private static string Separation(string inputValue)
        {
            string result = "";

            if (UInt64.TryParse(inputValue, out ulong num))
            {
                int qn = Convert.ToInt32((num / 1000000000000000000) % 1000);
                int qd = Convert.ToInt32((num / 1000000000000000) % 1000);
                int tn = Convert.ToInt32((num / 1000000000000) % 1000);
                int bn = Convert.ToInt32((num / 1000000000) % 1000);
                int mn = Convert.ToInt32((num / 1000000) % 1000);
                int th = Convert.ToInt32((num / 1000) % 1000);
                int hd = Convert.ToInt32(num % 1000);

                if ((qn + qd + tn + bn + mn + th + hd) == 0)
                {
                    result = $"{result}Zero ";
                }
                if (qn > 0)
                {
                    result = $"{result}{Words(qn)}Quintillion, ";
                }
                if (qd > 0)
                {
                    result = $"{result}{Words(qd)}Quadrillion, ";
                }
                if (tn > 0)
                {
                    result = $"{result}{Words(tn)}Trillion, ";
                }
                if (bn > 0)
                {
                    result = $"{result}{Words(bn)}Billion, ";
                }
                if (mn > 0)
                {
                    result = $"{result}{Words(mn)}Million, ";
                }
                if (th > 0)
                {
                    result = $"{result}{Words(th)}Thousand, ";
                }
                if (hd > 0)
                {
                    result = $"{result}{Words(hd)}";
                }
            }
            else
            {
                result = "Input is not a number, negative number, or being too big!\n" + formatMessage;
                throw new Exception(result);
            }

            return result;
        }

        private static string Words(int num)
        {
            string[] digits = {
                "",
                "One", "Two", "Three", "Four", "Five",
                "Six", "Seven", "Eight", "Nine", "Ten",
                "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
                "Sixteen", "Seventeen", "Eighteen", "Nineteen"
            };
            string[] tens = { 
                "", 
                "", "Twenty", "Thirty", "Forty", 
                "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" 
            };

            string result = "";

            if ((num / 100) > 0)
            {
                result = $"{result}{digits[num / 100]} Hundred And ";
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
                    result = $"{result.TrimEnd()}-{digits[num % 10]} ";
                }
            }

            return result;
        }
    }
}
