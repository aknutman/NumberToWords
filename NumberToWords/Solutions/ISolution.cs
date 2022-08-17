namespace NumberToWords.Solutions
{
    internal interface ISolution
    {
        /*
         * This interface hold the abstraction of any type Problem's Solution
         * So the client (Solution Runner) won't have to be troubled when there are multiple algorithm available
         * Because the client is accepting the object being injected as a constructor injector
         * This way, we can replace the end user, Program class, injector, or unit test to do their own goal
         */

        string NumberToWords(string num);
    }
}
