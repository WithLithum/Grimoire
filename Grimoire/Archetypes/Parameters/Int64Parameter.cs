namespace Grimoire.Archetypes.Parameters;

using Grimoire.Exceptions;

public sealed class Int64Parameter : CommandParameter<long>
{
    public Int64Parameter(long? minimum = null, long? maximum = null)
    {
        Minimum = minimum;
        Maximum = maximum;
    }

    public long? Minimum { get; set; }
    public long? Maximum { get; set; }

    public override long ReadArgument(CommandReader reader)
    {
        var retVal = reader.ReadInt64();

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
