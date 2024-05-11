namespace Grimoire.Minecraft.Archetypes.Parameters;

using Grimoire;
using Grimoire.Archetypes.Parameters;
using Grimoire.Exceptions;
using MineJason.Data;

public sealed class GameModeParameter : CommandParameter<GameMode>
{
    public override GameMode ReadArgument(CommandReader reader)
    {
        var word = reader.ReadUnquotedString();

        return word switch
        {
            "survival" => GameMode.Survival,
            "creative" => GameMode.Creative,
            "adventure" => GameMode.Adventure,
            "spectator" => GameMode.Spectator,
            _ => throw CommandFormatException.Create(MinecraftCommandErrors.InvalidGameMode,
                reader)
        };
    }
}
