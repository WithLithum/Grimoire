using Grimoire.Archetypes.Parameters;
using Grimoire.Exceptions;
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
    
    public override Angle ReadArgument(CommandReader reader)
    {
        var word = reader.ReadUnquotedString(IsAllowedInAngle);

        if (string.IsNullOrWhiteSpace(word))
        {
            throw CommandFormatException.Create(MinecraftCommandErrors.ExpectedType(typeof(Angle)),
                reader);
        }
        
        if (!Angle.TryParse(word, out var result))
        {
            throw CommandFormatException.Create(MinecraftCommandErrors.InvalidType(typeof(Angle)),
                reader); 
        }

        return result;
    }
}