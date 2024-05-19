using Grimoire.Exceptions;
using Grimoire.Inspection;

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
    
    public override void Read(CommandReader reader, InspectionDiscoveryCollection discoveries)
    {
        var word = reader.ReadUnquotedString();

        if (!word.Equals(Literal, StringComparison.Ordinal))
        {
            discoveries.Add(InspectionDiscovery.Create(InspectionMessage.ExpectedObjectButFound,
                reader,
                Literal,
                word));
        }
    }
}