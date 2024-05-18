namespace Grimoire.Minecraft.Archetypes.Parameters;

using Grimoire;
using Grimoire.Archetypes.Parameters;
using Grimoire.Exceptions;
using Grimoire.Minecraft.Models;

public sealed class ColumnPosParameter : CommandParameter<ColumnPosition>
{
    public override ColumnPosition ReadArgument(CommandReader reader)
    {
        var x = BlockPosParameter.ReadPositionComponent(reader);
        var z = BlockPosParameter.ReadPositionComponent(reader);

        var result = new ColumnPosition(x, z);
        if (!result.IsValid())
        {
            throw CommandFormatException.Create(MinecraftCommandErrors.MixLocalAndWorld,
                reader);
        }

        return result;
    }
}
