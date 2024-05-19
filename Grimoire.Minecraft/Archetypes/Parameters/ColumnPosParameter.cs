using Grimoire.Inspection;

namespace Grimoire.Minecraft.Archetypes.Parameters;

using Grimoire;
using Grimoire.Archetypes.Parameters;
using Grimoire.Exceptions;
using Grimoire.Minecraft.Models;

public sealed class ColumnPosParameter : CommandParameter<ColumnPosition>
{
    public override ColumnPosition ReadArgument(CommandReader reader, InspectionDiscoveryCollection discoveries)
    {
        var x = BlockPosParameter.ReadPositionComponent(reader);
        reader.SkipSingleWhitespace();
        var z = BlockPosParameter.ReadPositionComponent(reader);

        var result = new ColumnPosition(x, z);
        if (!result.IsValid())
        {
            discoveries.Add(InspectionDiscovery.Create(MinecraftInspections.MixLocalAndWorld,
                reader));
        }

        return result;
    }
}
