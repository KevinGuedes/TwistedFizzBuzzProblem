using System.Text;
using TwistedFizzBuzz.Models;

namespace TwistedFizzBuzz;

/// <summary>
/// Provides methods for solving variations of the FizzBuzz problem.
/// This class supports standard and customized FizzBuzz solutions, allowing the use of custom tokens 
/// and handling large numerical ranges efficiently.
/// </summary>
public static class TwistedFizzBuzzSolver
{
    /// <summary>
    /// A dictionary of default FizzBuzz problem tokens where the key is a divisor and the value is the corresponding output string.
    /// </summary>
    private static readonly Dictionary<long, string> DEFAULT_TOKENS = new()
    {
        [3] = "Fizz",
        [5] = "Buzz"
    };

    /// <summary>
    /// Solves the FizzBuzz problem for a given number by applying custom or default tokens to determine the result string.
    /// </summary>
    /// <param name="number">
    /// The number to evaluate. If it is divisible by any of the keys in the token dictionary, 
    /// the corresponding values will be appended to the result.
    /// long is used to support large numbers.
    /// </param>
    /// <param name="customTokens">
    /// A dictionary of custom tokens where the key is a divisor and the value is the corresponding output string. 
    /// If null, the method uses a default set of tokens.
    /// </param>
    /// <returns>
    /// A string representing the result. If the number is divisible by any keys in the token dictionary, 
    /// the corresponding values are concatenated. If no divisors match, the number itself is returned as a string.
    /// </returns>
    internal static string SolveForNumber(long number, Dictionary<long, string>? customTokens = null)
    {
        //StringBuilder for better memory usage and preparing the library for more complex scenarios
        var result = new StringBuilder();
        var actualTokens = customTokens ?? DEFAULT_TOKENS;

        foreach (var token in actualTokens)
        {
            if (number % token.Key == 0)
                result.Append(token.Value);
        }

        return result.Length > 0 ? result.ToString() : number.ToString();
    }

    /// <summary>
    /// Solves the standard FizzBuzz problem for all numbers from 1 to the specified number using the problem's default tokens.
    /// </summary>
    /// <param name="number">
    /// The upper or lower limit of the range (inclusive) for which the problem will be solved. 
    /// long is used to support large numbers.
    /// </param>
    /// <returns>
    /// An enumerable collection of strings representing the result for each number in the range from 1 to <paramref name="number"/>.
    /// </returns>
    public static IEnumerable<string> SolveStandardProblem(long number)
    {
        var step = Math.Sign(number);

        for (long i = 1; i != number + step; i += step)
            yield return SolveForNumber(i);
    }

    /// <summary>
    /// Solves the FizzBuzz problem for a sequence of numbers using custom or default tokens.
    /// </summary>
    /// <param name="numbers">
    /// A collection of numbers to evaluate. long is used to support large numbers.
    /// </param>
    /// <param name="customTokens">
    /// A dictionary of custom tokens where the key is a divisor and the value is the corresponding output string. 
    /// If null, the method uses the FizzBuzz problem's default tokens.
    /// </param>
    /// <returns>
    /// A enumerable collection of strings representing the results for each number in the input sequence.
    /// </returns>
    public static IEnumerable<string> SolveForNumbers(
        IEnumerable<long> numbers,
        Dictionary<long, string>? customTokens = null)
    {
        foreach (var number in numbers)
            yield return SolveForNumber(number, customTokens);
    }

    /// <summary>
    /// Solves the FizzBuzz problem for a sequence of numbers using a third-party token.
    /// The method delegates the actual logic to another <see cref="SolveForNumbers"/> method,
    /// passing the tokens from the third-party token object.
    /// </summary>
    /// <param name="numbers">
    /// A collection of numbers to evaluate. long is used to support large numbers.
    /// </param>
    /// <param name="thirdPartyToken">
    /// A <see cref="ThirdyPartyToken"/> object containing the third party tokens to use.
    /// </param>
    /// <returns>
    /// An enumerable collection of strings representing the results for each number in the input 
    /// sequence, where each string is the result of applying the token rules defined in 
    /// <paramref name="thirdPartyToken"/>.
    /// </returns>
    public static IEnumerable<string> SolveForNumbers(
        IEnumerable<long> numbers,
        ThirdyPartyToken thirdPartyToken)
        => SolveForNumbers(numbers, thirdPartyToken.Tokens);

    /// <summary>
    /// Solves the problem for all numbers within a specified range using custom or default tokens.
    /// </summary>
    /// <param name="start">
    /// The starting value of the range (inclusive). long is used to support large numbers.
    /// </param>
    /// <param name="end">
    /// The ending value of the range (inclusive). Can be smaller than <paramref name="start"/> for reverse iteration.
    /// long is used to support large numbers.
    /// </param>
    /// <param name="customTokens">
    /// A dictionary of custom tokens where the key is a divisor and the value is the corresponding output string. 
    /// If null, the method uses the FizzBuzz problem's default tokens.
    /// </param>
    /// <returns>
    /// A collection of strings representing the results for each number in the specified range. 
    /// If <paramref name="start"/> equals <paramref name="end"/>, the result contains only one entry.
    /// </returns>
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

    /// <summary>
    /// Solves the FizzBuzz problem for a range of numbers using a third-party token.
    /// The method delegates the actual logic to another <see cref="SolveForRange"/> method,
    /// passing the tokens from the third-party token object.
    /// </summary>
    /// <param name="start">
    /// The starting value of the range (inclusive). long is used to support large numbers.
    /// </param>
    /// <param name="end">
    /// The ending value of the range (inclusive). Can be smaller than <paramref name="start"/> for reverse iteration.
    /// long is used to support large numbers.
    /// </param>
    /// <param name="thirdPartyToken">
    /// A <see cref="ThirdyPartyToken"/> object containing the third party tokens to use.
    /// </param>
    /// <returns>
    /// An enumerable collection of strings representing the results for each number in the specified range, 
    /// where each string is the result of applying the token rules defined in <paramref name="thirdPartyToken"/>.
    /// </returns>
    public static IEnumerable<string> SolveForRange(
        long start,
        long end,
        ThirdyPartyToken thirdPartyToken)
        => SolveForRange(start, end, thirdPartyToken.Tokens);
}
