using Grimoire.Exceptions;

namespace Grimoire.Archetypes;

public class LiteralArchetype : CommandArchetype
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LiteralArchetype"/> class.
    /// </summary>
    /// <param name="literal">The literal text to verify.</param>
    public LiteralArchetype(string literal)
    {
        Literal = literal;
    }
    
    /// <summary>
    /// Gets the literal to validate.
    /// </summary>
    public string Literal { get; }
    
    public override void Read(CommandReader reader)
    {
        var word = reader.ReadUnquotedString();

        if (!word.Equals(Literal, StringComparison.Ordinal))
        {
            throw CommandFormatException.Create(CommandFormatError.ExpectedWord(Literal),
                reader);
        }
    }
}