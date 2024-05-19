using Grimoire.Archetypes.Parameters;
using Grimoire.Exceptions;
using Grimoire.Inspection;
using Grimoire.Minecraft.Models;

namespace Grimoire.Minecraft.Archetypes.Parameters;

public class AngleParameter : CommandParameter<Angle>
{
    private static bool IsAllowedInAngle(char c)
    {
        return c is >= '0' and <= '9'
            or '~'
            or '.';
    }
    
    public override Angle ReadArgument(CommandReader reader, InspectionDiscoveryCollection discoveries)
    {
        var word = reader.ReadUnquotedString(IsAllowedInAngle);

        if (string.IsNullOrWhiteSpace(word))
        {
            discoveries.Add(MinecraftInspections.DiscoverExpectedType(reader, typeof(Angle)));
            return default;
        }
        
        if (!Angle.TryParse(word, out var result))
        {
            discoveries.Add(MinecraftInspections.DiscoverInvalidType(reader, typeof(Angle)));
            return default; 
        }

        return result;
    }
}