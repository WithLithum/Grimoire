namespace Grimoire.Archetypes.Parameters;

using Grimoire.Exceptions;

public sealed class DoubleParameter : CommandParameter<double>
{
    public DoubleParameter(double? minimum = null, double? maximum = null)
    {
        Minimum = minimum;
        Maximum = maximum;
    }

    public double? Minimum { get; set; }
    public double? Maximum { get; set; }

    public override double ReadArgument(CommandReader reader)
    {
        var retVal = reader.ReadDouble();

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
