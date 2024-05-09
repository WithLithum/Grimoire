namespace Grimoire.Archetypes.Parameters;

using Grimoire.Exceptions;

public sealed class SingleParameter : CommandParameter<float>
{
    public SingleParameter(float? minimum = null, float? maximum = null)
    {
        Minimum = minimum;
        Maximum = maximum;
    }

    public float? Minimum { get; set; }
    public float? Maximum { get; set; }

    public override float ReadArgument(CommandReader reader)
    {
        var retVal = reader.ReadSingle();

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
