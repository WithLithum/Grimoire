using Grimoire.Inspection;

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

    public override long ReadArgument(CommandReader reader, InspectionDiscoveryCollection discoveries)
    {
        var retVal = reader.ReadInt64();

        if (retVal < Minimum || retVal > Maximum)
        {
            discoveries.Add(InspectionDiscovery.Create(InspectionMessage.InvalidObject,
                reader,
                typeof(long)));
            return default;
        }
        
        return retVal;
    }
}
