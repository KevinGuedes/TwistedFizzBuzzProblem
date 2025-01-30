# Twisted Fizz Buzz

## General Overview
The TwistedFizzBuzzSolver is a flexible library for solving FizzBuzz-style problems with customizable tokens. It extends the traditional FizzBuzz concept by allowing dynamic rules, supporting large numbers and datasets efficiently, and enabling seamless integration with third-party token sources.

## Highlights
* Supports Large Numbers – Uses `long` to handle large numbers (e.g., 40,000,000,000).
* Memory-Efficient – Library methods uses `yield` to stream results instead of storing them all in memory.
* Custom Tokens – Allows custom rules beyond the default FizzBuzz (e.g., "7 → Foo", "11 → Bar").
* Third-Party Integration – Works with external APIs via ThirdPartyToken.
* Unit Testing – Ensures correctness across various scenarios.

## Examples

### Solving the standard FizzBuzz problem
```csharp
var standardProblemResult = TwistedFizzBuzzSolver.SolveStandardProblem(100);
standardProblemResult.ToList().ForEach(Console.WriteLine);
```
### Processing Large Ranges Efficiently
```csharp
foreach (var result in TwistedFizzBuzzSolver.SolveForRange(1, 3_000_000_000))
{
    Console.WriteLine(result); // Outputs results one at a time without excessive memory usage
}
```

### Handling Non Sequential Number
```csharp
var nonSquentialNumbersResult = TwistedFizzBuzzSolver.SolveForNumbers([-5, 6, 300, 12, 15]);
nonSquentialNumbersResult.ToList().ForEach(Console.WriteLine);
```

### Working With Custom Token Rules
```csharp
var customTokens = new Dictionary<long, string>
{
    [7] = "Poem",
    [17] = "Writer",
    [3] = "College"
};
var customTokensResult = TwistedFizzBuzzSolver.SolveForNumbers([119, 51, 21, 357], customTokens);
customTokensResult.ToList().ForEach(Console.WriteLine);
```

### Using Third-Party Tokens from an API Response
```csharp
const string API_URL = "https://pie-healthy-swift.glitch.me";
const string CHROME_USER_AGENT = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36";

try
{
    using var httpClient = new HttpClient()
    {
        BaseAddress = new Uri(API_URL),
        DefaultRequestHeaders = { { "User-Agent", CHROME_USER_AGENT } },
    };

    var response = await httpClient.GetAsync("/word");
    response.EnsureSuccessStatusCode();

    var responseContentAsString = await response.Content.ReadAsStringAsync();
    var thirdyPartyToken = JsonSerializer.Deserialize<ThirdyPartyToken>(
        responseContentAsString,
        options: new() { PropertyNameCaseInsensitive = true });

    var thirdPartyTokensResult = TwistedFizzBuzzSolver.SolveForRange(1, 100, thirdyPartyToken!);
    thirdPartyTokensResult.ToList().ForEach(Console.WriteLine);
}
catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.ServiceUnavailable)
{
    Console.WriteLine("The API was shut down due to being idle. Please wait a moment for it to restart and try again.");
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred while handling custom tokens from the API: {0}", ex.Message);
}
```

