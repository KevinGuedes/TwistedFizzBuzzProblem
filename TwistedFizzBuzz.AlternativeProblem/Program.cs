using TwistedFizzBuzz;

Console.WriteLine("Alternative FizzBuzz problem solution:\n");

var customTokens = new Dictionary<long, string>
{
    [5] = "Fizz",
    [9] = "Buzz",
    [27] = "Bar"
};
var alternativeProblemResult = TwistedFizzBuzzSolver.SolveForRange(-20, 127, customTokens);
alternativeProblemResult.ToList().ForEach(Console.WriteLine);
