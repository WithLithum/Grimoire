using Grimoire.Inspection;

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

    public override ResourceLocation ReadArgument(CommandReader reader, InspectionDiscoveryCollection discoveries)
    {
        var word = reader.ReadUnquotedString(IsAllowedChar);

        if (string.IsNullOrWhiteSpace(word))
        {
            discoveries.Add(MinecraftInspections.DiscoverExpectedType(reader, typeof(ResourceLocation)));
            return default;
        }

        if (!ResourceLocation.TryParse(word, out var resourceLocation))
        {
            discoveries.Add(MinecraftInspections.DiscoverInvalidType(reader, typeof(ResourceLocation)));
        }

        return resourceLocation;
    }
}
