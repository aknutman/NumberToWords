using NumberToWords.Helpers;
using NumberToWords.ISolutions;

namespace NumberToWords.Solutions
{
    public class SolutionOne : ISolution
    {
        /*
         * This class responsible for this particular algorithm only
         * Accept string input, convert to number, convert number to words, and return the words string
         */

        public string ConvertNumberToWords(string inputValue)
        {
            string[] inputs = ValidateInputString(inputValue);

            var firstPart = SeparateIntoThousandBased(inputs[0]);
            var secondPart = SeparateIntoThousandBased(inputs[1]);

            string result = $"{firstPart}Dollars And {secondPart}cents";

            return result.ToUpper();

        }

        private static string[] ValidateInputString(string inputString)
        {
            if(inputString.Length == 0)
            {
                throw new Exception(ErrorMessagesEnum.shouldNotBeEmpty);
            }

            string[] result = inputString.Split('.'); ;

            if (!inputString.Contains('.'))
            {
                throw new Exception(ErrorMessagesEnum.useDotOnly);
            }

            if (result.Length > 2)
            {
                throw new Exception(ErrorMessagesEnum.tooMuchDot);
            }

            if (result[1].Length != 2)
            {
                throw new Exception(ErrorMessagesEnum.twoDecimalOnly);
            }

            foreach (string item in result)
            {
                if (!UInt64.TryParse(item, out ulong itemNum))
                {
                    throw new Exception($"\"{item}\" {ErrorMessagesEnum.invalidNumber}");
                }
            }

            return result;
        }

        private static string SeparateIntoThousandBased(string numString)
        {
            string result = "";

            ulong num = Convert.ToUInt64(numString);

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
                result = $"{result}{ConvertNumberIntoWords(qn)}Quintillion, ";
            }
            if (qd > 0)
            {
                result = $"{result}{ConvertNumberIntoWords(qd)}Quadrillion, ";
            }
            if (tn > 0)
            {
                result = $"{result}{ConvertNumberIntoWords(tn)}Trillion, ";
            }
            if (bn > 0)
            {
                result = $"{result}{ConvertNumberIntoWords(bn)}Billion, ";
            }
            if (mn > 0)
            {
                result = $"{result}{ConvertNumberIntoWords(mn)}Million, ";
            }
            if (th > 0)
            {
                result = $"{result}{ConvertNumberIntoWords(th)}Thousand, ";
            }
            if (hd > 0)
            {
                result = $"{result}{ConvertNumberIntoWords(hd)}";
            }

            return result;
        }

        private static string ConvertNumberIntoWords(int num)
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
