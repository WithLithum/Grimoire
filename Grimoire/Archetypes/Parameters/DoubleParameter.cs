using Grimoire.Inspection;

namespace Grimoire.Archetypes.Parameters;

public sealed class DoubleParameter : CommandParameter<double>
{
    public DoubleParameter(double? minimum = null, double? maximum = null)
    {
        Minimum = minimum;
        Maximum = maximum;
    }

    public double? Minimum { get; set; }
    public double? Maximum { get; set; }

    public override double ReadArgument(CommandReader reader, InspectionDiscoveryCollection discoveries)
    {
        var retVal = reader.ReadDouble();

        if (retVal < Minimum || retVal > Maximum)
        {
            discoveries.Add(InspectionDiscovery.Create(InspectionMessage.InvalidObject,
                reader,
                typeof(double)));
            return default;
        }

        return retVal;
    }
}
