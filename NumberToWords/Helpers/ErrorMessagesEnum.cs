using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords.Helpers
{
    internal static class ErrorMessagesEnum
    {
        private const string formatMessage = @"
==========================================
* Accepted format is 123.45
* Number can be up to a Quintillion
* Accept 2 digit decimal only
==========================================
";
        public const string shouldNotBeEmpty = "Please input a number!\n" + formatMessage;
        public const string useDotOnly = "Only accept dot in decimal separator.\n" + formatMessage;
        public const string tooMuchDot = "Too much dot there...:P\n" + formatMessage;
        public const string twoDecimalOnly = "Only accept 2 digit decimal only\n" + formatMessage;
        public const string invalidNumber = "should be a number, positive number, and under 18 Quintillion \n" + formatMessage;
    }
}
