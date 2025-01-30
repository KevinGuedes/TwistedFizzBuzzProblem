namespace TwistedFizzBuzz.Models;

/// <summary>
/// Represents a custom FizzBuzz token received from a third-party API, where a specific number 
/// is associated with a word.
/// </summary>
public sealed class ThirdyPartyToken(long number, string word)
{
    /// <summary>
    /// Gets the number associated with the token. 
    /// When solving FizzBuzz, numbers divisible by this value will be replaced with the corresponding <see cref="Word"/>.
    /// </summary>
    public long Number { get; init; } = number;

    /// <summary>
    /// Gets the word associated with the token. 
    /// This word will be used as output when the number is a multiple of <see cref="Number"/>.
    /// </summary>
    public string Word { get; init; } = word;

    /// <summary>
    /// Gets a dictionary representation of the token, where the key is the number and the value is the word.
    /// This allows the token to be integrated into FizzBuzz logic dynamically.
    /// </summary>
    public Dictionary<long, string> Tokens => new() { [Number] = Word };
}

