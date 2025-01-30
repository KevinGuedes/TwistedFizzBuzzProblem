using System.Net;
using System.Text.Json;
using TwistedFizzBuzz;
using TwistedFizzBuzz.Models;

Console.WriteLine("Solving FizzBuzz for a large range:\n");
//Printing only first 20 to avoid flooding the console
int count = 20;
foreach (var largeRangeResult in TwistedFizzBuzzSolver.SolveForRange(1, 2_000_000_000))
{
    Console.WriteLine(largeRangeResult);

    count--;
    if (count == 0)
        break;
}

Console.WriteLine("\n\nSolving FizzBuzz for non-sequential set of number:\n");
var nonSquentialNumbersResult = TwistedFizzBuzzSolver.SolveForNumbers([-5, 6, 300, 12, 15]);
nonSquentialNumbersResult.ToList().ForEach(Console.WriteLine);

Console.WriteLine("\n\nSolving FizzBuzz using custom tokens:\n");
var customTokens = new Dictionary<long, string>
{
    [7] = "Poem",
    [17] = "Writer",
    [3] = "College"
};
var customTokensResult = TwistedFizzBuzzSolver.SolveForNumbers([119, 51, 21, 357], customTokens);
customTokensResult.ToList().ForEach(Console.WriteLine);

Console.WriteLine("\n\nSolving FizzBuzz with custom tokens fetched from a 3rd party API:\n");
//API accepts request via browser but not via code, it returns a 403 (Forbidden)
//So, i had to set the User-Agent header to mimic a browser request
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
