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

    public override Guid ReadArgument(CommandReader reader)
    {
        var word = reader.ReadUnquotedString(IsAllowed);

        if (string.IsNullOrWhiteSpace(word))
        {
            throw CommandFormatException.Create(MinecraftCommandErrors.ExpectedType(typeof(Guid)),
                reader);
        }

        if (!word.Contains('-') || !Guid.TryParse(word, out var result))
        {
            throw CommandFormatException.Create(MinecraftCommandErrors.InvalidType(typeof(Guid)),
                reader);
        }

        return result;
    }
}
