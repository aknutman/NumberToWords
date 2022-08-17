using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToWords.Helpers;
using NumberToWords.Solutions;

namespace NumberToWords.UnitTests.Solutions
{
    [TestClass]
    public class SolutionOneTests
    {
        [TestMethod]
        public void ConvertNumberToWords_EmptyInput_ReturnEmptyInputMessage()
        {
            SolutionOne solOne = new();

            Exception ex = Assert.ThrowsException<Exception>(() => solOne.ConvertNumberToWords(""));

            Assert.AreEqual(ex.Message, ErrorMessagesEnum.shouldNotBeEmpty);
        }

        [TestMethod]
        public void ConvertNumberToWords_DotSeparatorInput_ReturnDotErrorMessage()
        {
            SolutionOne solOne = new();

            Exception ex = Assert.ThrowsException<Exception>(() => solOne.ConvertNumberToWords("123,45"));

            Assert.AreEqual(ex.Message, ErrorMessagesEnum.useDotOnly);
        }

        [TestMethod]
        public void ConvertNumberToWords_InputMoreThanTwoDecimal_ReturnMoreThanTwoDecimalMessage()
        {
            SolutionOne solOne = new();

            Exception ex = Assert.ThrowsException<Exception>(() => solOne.ConvertNumberToWords("1.234"));

            Assert.AreEqual(ex.Message, ErrorMessagesEnum.twoDecimalOnly);
        }

        [TestMethod]
        public void ConvertNumberToWords_InvalidNumberInput_ReturnInvalidInputMessage()
        {
            SolutionOne solOne = new();

            Exception ex = Assert.ThrowsException<Exception>(() => solOne.ConvertNumberToWords("1w.23"));

            StringAssert.Contains(ex.Message, ErrorMessagesEnum.invalidNumber);
        }

        [TestMethod]
        public void ConvertNumberToWords_VeryBigNumberInput_ReturnInvalidInputMessage()
        {
            SolutionOne solOne = new();

            Exception ex = Assert.ThrowsException<Exception>(() => solOne.ConvertNumberToWords("123456789098765432123456789.23"));

            StringAssert.Contains(ex.Message, ErrorMessagesEnum.invalidNumber);
        }
    }
}
