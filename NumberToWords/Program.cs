using NumberToWords;
using NumberToWords.Solutions;

Console.WriteLine("Input number below:");

string? s;
while ((s = Console.ReadLine()) != null)
{
    string result = "";

    SolutionRunner sr = new SolutionRunner(new SolutionOne());
    result = sr.getResult(s);

    Console.WriteLine($"{result}");
}