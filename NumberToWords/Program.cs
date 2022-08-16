using NumberToWords;
using NumberToWords.SolutionRunner;
using NumberToWords.Solutions;

Console.WriteLine("Input number below:");

string? s;
while ((s = Console.ReadLine()) != null)
{
    FirstSR sr = new FirstSR(new SolutionOne());
    string result = sr.getResult(s);

    Console.WriteLine($"{result}");
}