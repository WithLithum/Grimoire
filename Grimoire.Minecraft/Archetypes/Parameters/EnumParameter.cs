using Grimoire.Inspection;

namespace Grimoire.Minecraft.Archetypes.Parameters;

using Grimoire;
using Grimoire.Archetypes.Parameters;
using Grimoire.Exceptions;

public abstract class EnumParameter<T> : CommandParameter<T>
    where T : Enum
{
    private static bool IsAllowed(char c)
    {
        return c > 'a' && c < 'z';
    }

    public override T? ReadArgument(CommandReader reader, InspectionDiscoveryCollection discoveries)
    {
        var word = reader.ReadUnquotedString(IsAllowed);

        if (string.IsNullOrWhiteSpace(word))
        {
            discoveries.Add(InspectionDiscovery.Create(MinecraftInspections.ExpectedType,
                reader,
                typeof(T)));
            return default;
        }

        if (!Enum.TryParse(typeof(T), word, true, out var result))
        {
            discoveries.Add(InspectionDiscovery.Create(MinecraftInspections.InvalidType,
                reader,
                typeof(T)));
            return default;
        }

        return (T)result;
    }
}
