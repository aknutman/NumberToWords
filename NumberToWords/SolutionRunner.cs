using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumberToWords.Solutions;

namespace NumberToWords
{
    internal class SolutionRunner
    {
        public ISolution ntwSolution;

        public SolutionRunner(ISolution ntwSolution)
        {
            this.ntwSolution = ntwSolution;
        }

        public string getResult(string num)
        {
            return ntwSolution.NumberToWords(num);
        }
    }
}
