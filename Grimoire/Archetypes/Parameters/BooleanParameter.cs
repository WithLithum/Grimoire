using Grimoire.Inspection;

namespace Grimoire.Archetypes.Parameters;

public sealed class BooleanParameter : CommandParameter<bool>
{
    public override bool ReadArgument(CommandReader reader, InspectionDiscoveryCollection discoveries)
    {
        return reader.ReadBoolean();
    }
}
