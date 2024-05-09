namespace Grimoire.Archetypes.Parameters;

using Grimoire.Exceptions;

public sealed class Int32Parameter : CommandParameter<int>
{
    public Int32Parameter(int? minimum = null, int? maximum = null)
    {
        Minimum = minimum;
        Maximum = maximum;
    }

    public int? Minimum { get; set; }
    public int? Maximum { get; set; }

    public override int ReadArgument(CommandReader reader)
    {
        var retVal = reader.ReadInt32();

        if (Minimum.HasValue && retVal < Minimum.Value)
        {
            throw CommandFormatException.Create(CommandFormatError.DoubleLessThanMinimum(Minimum.Value),
                reader);
        }

        if (Maximum.HasValue && retVal > Maximum.Value)
        {
            throw CommandFormatException.Create(CommandFormatError.DoubleLessThanMinimum(Maximum.Value),
                reader);
        }

        return retVal;
    }
}
