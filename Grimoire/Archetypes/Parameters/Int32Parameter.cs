using Grimoire.Inspection;

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

    public override int ReadArgument(CommandReader reader, InspectionDiscoveryCollection discoveries)
    {
        var retVal = reader.ReadInt32();

        if (retVal < Minimum || retVal > Maximum)
        {
            discoveries.Add(InspectionDiscovery.Create(InspectionMessage.InvalidObject,
                reader,
                typeof(int)));
            return default;
        }

        return retVal;
    }
}
