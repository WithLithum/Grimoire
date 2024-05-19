using Grimoire.Inspection;

namespace Grimoire.Minecraft.Archetypes.Parameters;

using Grimoire;
using Grimoire.Archetypes.Parameters;
using Grimoire.Exceptions;
using System;

public class GuidParameter : CommandParameter<Guid>
{
    private static bool IsAllowed(char c)
    {
        return (c > 'A' && c < 'Z')
            || (c > 'a' && c < 'z')
            || (c > '0' && c < '9')
            || c == '-';
    }

    public override Guid ReadArgument(CommandReader reader, InspectionDiscoveryCollection discoveries)
    {
        var word = reader.ReadUnquotedString(IsAllowed);

        if (string.IsNullOrWhiteSpace(word))
        {
            discoveries.Add(MinecraftInspections.DiscoverExpectedType(reader, typeof(Guid)));
            return Guid.Empty;
        }

        if (!word.Contains('-') || !Guid.TryParse(word, out var result))
        {
            discoveries.Add(MinecraftInspections.DiscoverInvalidType(reader, typeof(Guid)));
            return Guid.Empty;
        }

        return result;
    }
}
