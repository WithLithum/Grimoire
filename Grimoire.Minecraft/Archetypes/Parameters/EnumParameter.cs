namespace Grimoire.Minecraft.Archetypes.Parameters;

using Grimoire;
using Grimoire.Archetypes.Parameters;
using Grimoire.Exceptions;

public abstract class EnumParameter<T> : CommandParameter<T>
    where T : notnull, Enum
{
    private static bool IsAllowed(char c)
    {
        return c > 'a' && c < 'z';
    }

    public override T ReadArgument(CommandReader reader)
    {
        var word = reader.ReadUnquotedString(IsAllowed);

        if (string.IsNullOrWhiteSpace(word))
        {
            throw CommandFormatException.Create(MinecraftCommandErrors.ExpectedType(typeof(T)),
                reader);
        }

        if (!Enum.TryParse(typeof(T), word, true, out var result))
        {
            throw CommandFormatException.Create(MinecraftCommandErrors.InvalidType(typeof(T)),
                reader);
        }

        return (T)result;
    }
}
