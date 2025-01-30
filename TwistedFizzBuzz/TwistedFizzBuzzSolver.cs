using TwistedFizzBuzz.Models;

namespace TwistedFizzBuzz;

public static class TwistedFizzBuzzSolver
{
    private static readonly Dictionary<long, string> DEFAULT_TOKENS = new()
    {
        [3] = "Fizz",
        [5] = "Buzz"
    };

    internal static string SolveForNumber(long number, Dictionary<long, string>? customTokens = null)
    {
        var result = "";
        var actualTokens = customTokens ?? DEFAULT_TOKENS;

        foreach (var token in actualTokens)
        {
            if (number % token.Key == 0)
                result += token.Value;
        }

        return string.IsNullOrEmpty(result) ? number.ToString() : result.ToString();
    }

    public static IEnumerable<string> SolveStandardProblem(long number)
    {
        var step = Math.Sign(number);

        for (long i = 1; i != number + step; i += step)
            yield return SolveForNumber(i);
    }

    public static IEnumerable<string> SolveForNumbers(
        IEnumerable<long> numbers,
        Dictionary<long, string>? customTokens = null)
    {
        foreach (var number in numbers)
            yield return SolveForNumber(number, customTokens);
    }

    public static IEnumerable<string> SolveForNumbers(
        IEnumerable<long> numbers,
        ThirdyPartyToken thirdPartyToken)
        => SolveForNumbers(numbers, thirdPartyToken.Tokens);

    public static IEnumerable<string> SolveForRange(
        long start,
        long end,
        Dictionary<long, string>? customTokens = null)
    {
        //using yield in order to allow better memory handling when dealing with large ranges (ex: 1-2,000,000,000)
        if (start <= end)
        {
            for (long i = start; i <= end; i++)
                yield return SolveForNumber(i, customTokens);
        }
        else
        {
            for (long i = start; i >= end; i--)
                yield return SolveForNumber(i, customTokens);
        }
    }

    public static IEnumerable<string> SolveForRange(
        long start,
        long end,
        ThirdyPartyToken thirdPartyToken)
        => SolveForRange(start, end, thirdPartyToken.Tokens);
}
