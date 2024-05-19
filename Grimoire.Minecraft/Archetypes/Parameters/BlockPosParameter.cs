using Grimoire.Inspection;

namespace Grimoire.Minecraft.Archetypes.Parameters;

using Grimoire;
using Grimoire.Archetypes.Parameters;
using Grimoire.Exceptions;
using MineJason.Data.Coordinates;

public sealed class BlockPosParameter : CommandParameter<BlockPosition>
{
    public static bool IsAllowedInComponent(char c)
    {
        return c >= '0' && c <= '9'
            || c == '~'
            || c == '^';
    }

    public static BlockPositionComponent ReadPositionComponent(CommandReader reader)
    {
        // Read the component.
        var word = reader.ReadUnquotedString(IsAllowedInComponent);

        if (string.IsNullOrWhiteSpace(word))
        {
            throw new CommandFormatException(InspectionDiscovery.Create(MinecraftInspections.ExpectedBlockPosComponent,
                reader));
        }

        // Parse the component.
        BlockPositionComponent result;

        try
        {
            result = BlockPositionComponent.Parse(word);
        }
        catch (FormatException ex)
        {
            throw new CommandFormatException(InspectionDiscovery.Create(MinecraftInspections.InvalidBlockPosComponent,
                reader), ex);
        }

        return result;
    }

    public override BlockPosition ReadArgument(CommandReader reader, InspectionDiscoveryCollection discoveries)
    {
        var x = ReadPositionComponent(reader);
        reader.SkipSingleWhitespace();
        var y = ReadPositionComponent(reader);
        reader.SkipSingleWhitespace();
        var z = ReadPositionComponent(reader);

        var result = new BlockPosition(x, y, z);
        if (!result.IsValid())
        {
            discoveries.Add(InspectionDiscovery.Create(MinecraftInspections.MixLocalAndWorld,
                reader));
        }

        return result;
    }
}
