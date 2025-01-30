using TwistedFizzBuzz.Models;

namespace TwistedFizzBuzz.Tests;

public class TwistedFizzBuzzTests
{
    [Theory]
    [InlineData(2_000_000_000, "Buzz")]
    [InlineData(3_000_000_000, "FizzBuzz")]
    [InlineData(15, "FizzBuzz")]
    [InlineData(9_999_999_999, "Fizz")]
    public void SolveForNumber_ShouldReturnCorrectResult_WithDefaultTokens(long number, string expected)
    {
        // Act
        var result = TwistedFizzBuzzSolver.SolveForNumber(number);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(-7, "Foo")]
    [InlineData(7, "Foo")]
    [InlineData(-5, "-5")]
    [InlineData(5, "5")]
    [InlineData(-2, "Bar")]
    [InlineData(2, "Bar")]
    [InlineData(14, "FooBar")]
    [InlineData(-14, "FooBar")]
    [InlineData(-4000123124, "Bar")]
    public void SolveForNumber_ShouldReturnCorrectResult_WithCustomTokens(long number, string expected)
    {
        // Arrange
        var customTokens = new Dictionary<long, string>
        {
            [7] = "Foo",
            [2] = "Bar"
        };

        // Act
        var result = TwistedFizzBuzzSolver.SolveForNumber(number, customTokens);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(4, "4")]
    [InlineData(97, "97")]
    [InlineData(98, "98")]
    [InlineData(4_000_123_124, "4000123124")]
    public void SolveForNumber_ShouldReturnNumberAsString_WhenNoTokensMatch(long number, string expected)
    {
        // Act
        var result = TwistedFizzBuzzSolver.SolveForNumber(number);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, new[] { "1", "2", "Fizz", "4", "Buzz" })]
    [InlineData(-5, new[] { "1", "FizzBuzz", "-1", "-2", "Fizz", "-4", "Buzz" })]
    [InlineData(15, new[] { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" })]
    public void SolveStandardProblem_ShouldReturnCorrectResults(long number, string[] expected)
    {
        // Act
        var result = TwistedFizzBuzzSolver.SolveStandardProblem(number);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new long[] { 2, 4, 7, 11, 22, 3_000_000_000 }, new[] { "2", "4", "7", "11", "22", "FizzBuzz" })]
    [InlineData(new long[] { -5, 6, 300, 12, 15 }, new[] { "Buzz", "Fizz", "FizzBuzz", "Fizz", "FizzBuzz" })]
    [InlineData(new long[] { 15, 30, 45, 60 }, new[] { "FizzBuzz", "FizzBuzz", "FizzBuzz", "FizzBuzz" })]
    public void SolveForNumbers_ShouldReturnCorrectResults(long[] numbers, string[] expected)
    {
        // Act
        var result = TwistedFizzBuzzSolver.SolveForNumbers(numbers);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new long[] { 7, 17, 3 }, new[] { "Poem", "Writer", "College" })]
    [InlineData(new long[] { 119, 51, 21, 357 }, new[] { "PoemWriter", "WriterCollege", "PoemCollege", "PoemWriterCollege" })]
    public void SolveForNumbers_ShouldWorkWithCustomTokens(long[] numbers, string[] expected)
    {
        // Arrange
        var customTokens = new Dictionary<long, string>
        {
            [7] = "Poem",
            [17] = "Writer",
            [3] = "College"
        };

        // Act
        var result = TwistedFizzBuzzSolver.SolveForNumbers(numbers, customTokens);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SolveForNumbers_ShouldReturnCorrectResults_WhenUsingThirdPartyTokens()
    {
        // Arrange
        var thirdyPartyToken = new ThirdyPartyToken(5, "Foo");
        List<long> numbers = [3, 6, 7, 12, 13, 28, 40, 45];

        // Act
        var results = TwistedFizzBuzzSolver.SolveForNumbers(numbers, thirdyPartyToken);

        // Assert
        var expectedResults = new List<string> { "3", "6", "7", "12", "13", "28", "Foo", "Foo" };
        Assert.Equal(expectedResults, results);
    }

    [Fact]
    public void SolveForRange_ShouldHandleAscendingRange()
    {
        // Arrange
        long start = -5;
        long end = 5;

        // Act
        var result = TwistedFizzBuzzSolver.SolveForRange(start, end);

        // Assert
        List<string> expected = ["Buzz", "-4", "Fizz", "-2", "-1", "FizzBuzz", "1", "2", "Fizz", "4", "Buzz"];
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SolveForRange_ShouldHandleDescendingRange()
    {
        // Arrange
        long start = -2;
        long end = -27;

        // Act
        var result = TwistedFizzBuzzSolver.SolveForRange(start, end);

        // Assert
        List<string> expected =
            [
                "-2",
                "Fizz",
                "-4",
                "Buzz",
                "Fizz",
                "-7",
                "-8",
                "Fizz",
                "Buzz",
                "-11",
                "Fizz",
                "-13",
                "-14",
                "FizzBuzz",
                "-16",
                "-17",
                "Fizz",
                "-19",
                "Buzz",
                "Fizz",
                "-22",
                "-23",
                "Fizz",
                "Buzz",
                "-26",
                "Fizz"
            ];
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SolveForRange_ShouldOnlyOneResult_WhenStartIsEqualToEnd()
    {
        // Arrange
        long start = 3;
        long end = 3;

        // Act
        var result = TwistedFizzBuzzSolver.SolveForRange(start, end);

        // Assert
        List<string> expected = ["Fizz"];
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 3, new[] { "1", "Foo", "Bar" })]
    [InlineData(-3, 3, new[] { "Bar","Foo", "-1", "FooBar", "1", "Foo", "Bar" })]
    public void SolveForRange_ShouldWorkWithCustomTokens(long start, long end, string[] expected)
    {
        // Arrange
        var customTokens = new Dictionary<long, string>
        {
            [2] = "Foo",
            [3] = "Bar"
        };

        // Act
        var result = TwistedFizzBuzzSolver.SolveForRange(start, end, customTokens);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SolveForRange_ShouldReturnCorrectResults_WhenUsingThirdPartyTokens()
    {
        // Arrange
        var thirdPartyToken = new ThirdyPartyToken(-3, "Fizz");
        long start = 1;
        long end = 5;

        // Act
        var results = TwistedFizzBuzzSolver.SolveForRange(start, end, thirdPartyToken);

        // Assert
        var expectedResults = new List<string> { "1", "2", "Fizz", "4", "5" };
        Assert.Equal(expectedResults, results);
    }
}