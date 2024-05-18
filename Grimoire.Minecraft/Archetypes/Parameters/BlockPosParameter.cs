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
            throw CommandFormatException.Create(MinecraftCommandErrors.ExpectedBlockPosComponent,
                reader);
        }

        // Parse the component.
        BlockPositionComponent result;

        try
        {
            result = BlockPositionComponent.Parse(word);
        }
        catch (FormatException ex)
        {
            throw CommandFormatException.Create(MinecraftCommandErrors.InvalidBlockPosComponent,
                reader,
                ex);
        }

        return result;
    }

    public override BlockPosition ReadArgument(CommandReader reader)
    {
        var x = ReadPositionComponent(reader);
        reader.SkipSingleWhitespace();
        var y = ReadPositionComponent(reader);
        reader.SkipSingleWhitespace();
        var z = ReadPositionComponent(reader);

        var result = new BlockPosition(x, y, z);
        if (!result.IsValid())
        {
            throw CommandFormatException.Create(MinecraftCommandErrors.MixLocalAndWorld,
                reader);
        }

        return result;
    }
}
