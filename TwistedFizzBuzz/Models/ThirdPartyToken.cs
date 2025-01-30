namespace TwistedFizzBuzz.Models;

public sealed class ThirdyPartyToken(long number, string word)
{
    public long Number { get; init; } = number;

    public string Word { get; init; } = word;

    public Dictionary<long, string> Tokens => new() { [Number] = Word };
}