using Grimoire.Inspection;

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

    public override float ReadArgument(CommandReader reader, InspectionDiscoveryCollection discoveries)
    {
        var retVal = reader.ReadSingle();

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
