using NumberToWords.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords.SolutionRunner
{
    internal class FirstSR
    {
        public ISolution ntwSolution;

        public FirstSR(ISolution ntwSolution)
        {
            this.ntwSolution = ntwSolution;
        }

        public string getResult(string num)
        {
            try
            {
                return ntwSolution.NumberToWords(num);
            }
            catch
            {
                return "Something wrong happening. Please restart the apps.";
            }
        }
    }
}
