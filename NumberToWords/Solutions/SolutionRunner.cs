using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords.Solutions
{
    internal class SolutionRunner
    {
        public ISolution ntwSolution;

        public SolutionRunner(ISolution ntwSolution)
        {
            this.ntwSolution = ntwSolution;
        }

        public string getResult(long num)
        {
            return this.ntwSolution.NumberToWords(num);
        }
    }
}
