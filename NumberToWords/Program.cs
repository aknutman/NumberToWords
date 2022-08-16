using NumberToWords.Solutions;

Console.WriteLine("Input number below:");

string s;
while ((s = Console.ReadLine()) != null)
{
    if (Int64.TryParse(s, out long j))
    {
        string result = "";

        SolutionRunner sr = new SolutionRunner(new SolutionOne());
        result = sr.getResult(j);

        Console.WriteLine($"{result}");
    }
}