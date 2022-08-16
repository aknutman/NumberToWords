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
        /*
            * This runner class, can run various Solutions, as long it has the same class signature
            * This class caller, Program class, injector, tester, or other type of class, no need to create and use any other SolutionRunner
            * As long as the Solutions has the same signature
            * 
            * EXAMPLE of other type Solution signature
            * getResult(string num, string locale, string decimalSeparator)
            * getResult(string num, string decimalSeparator)
            * etc..
            * 
            * This runner class will definitely accept the various type of available algorithm provided by the class caller, Program class, injector, etc
         */
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
