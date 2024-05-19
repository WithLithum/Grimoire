using Grimoire.Inspection;

namespace Grimoire.Archetypes.Parameters;

public abstract class CommandParameter<T> : CommandArchetype
{
    public abstract T? ReadArgument(CommandReader reader, InspectionDiscoveryCollection discoveries);

    public override void Read(CommandReader reader, InspectionDiscoveryCollection discoveries)
    {
        // Disregard the final value.
        ReadArgument(reader, discoveries);
    }
}
