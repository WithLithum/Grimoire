namespace Grimoire.Minecraft.Archetypes.Parameters;

using Grimoire;
using Grimoire.Archetypes.Parameters;
using Grimoire.Exceptions;
using MineJason;

public class ResourceLocationParameter : CommandParameter<ResourceLocation>
{
    private static bool IsAllowedChar(char c)
    {
        return c >= '0' && c <= '9'
            || c >= 'A' && c <= 'Z'
            || c >= 'a' && c <= 'z'
            || c == '_' || c == '-'
            || c == '/' || c == ':';
    }

    public override ResourceLocation ReadArgument(CommandReader reader)
    {
        var word = reader.ReadUnquotedString(IsAllowedChar);

        if (string.IsNullOrWhiteSpace(word))
        {
            throw CommandFormatException.Create(MinecraftCommandErrors.ExpectedResourceLocation, reader);
        }

        if (!ResourceLocation.TryParse(word, out var resourceLocation))
        {
            throw CommandFormatException.Create(MinecraftCommandErrors.InvalidResourceLocation, reader);
        }

        return resourceLocation;
    }
}
