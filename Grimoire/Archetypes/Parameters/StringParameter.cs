using Grimoire.Inspection;

namespace Grimoire.Archetypes.Parameters;

public class StringParameter : CommandParameter<string>
{
    public StringParameter(StringType type = StringType.Word)
    {
        Type = type;
    }

    public enum StringType
    {
        /// <summary>
        /// A single unquoted word.
        /// </summary>
        Word,
        /// <summary>
        /// A word or a set of words that may or may not be quoted.
        /// </summary>
        QuotablePhrase,
        /// <summary>
        /// Read to end.
        /// </summary>
        GreedyPhrase
    }

    public StringType Type { get; set; }

    public override string ReadArgument(CommandReader reader, InspectionDiscoveryCollection discoveries)
    {
        if (Type == StringType.GreedyPhrase)
        {
            var text = reader.GetRemaining();
            reader.Position = reader.Length;
            return text;
        }
        else if (Type == StringType.Word)
        {
            return reader.ReadUnquotedString();
        }
        else
        {
            return reader.ReadString();
        }
    }
}
