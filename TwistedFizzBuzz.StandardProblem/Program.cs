using TwistedFizzBuzz;

Console.WriteLine("Standard FizzBuzz problem solution:\n");

var standardProblemResult = TwistedFizzBuzzSolver.SolveStandardProblem(100);
standardProblemResult.ToList().ForEach(Console.WriteLine);
