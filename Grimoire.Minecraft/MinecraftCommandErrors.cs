namespace Grimoire.Minecraft;

using Grimoire.Exceptions;

public static class MinecraftCommandErrors
{
    public static CommandFormatError InvalidGameMode => new("MC0001", "Unrecognized game mode");
    public static CommandFormatError InvalidBlockPosComponent => new("MC0002", "Invalid block position component");
    public static CommandFormatError MixLocalAndWorld => new("MC0003", "Mixed local & world coordinates");
    public static CommandFormatError ExpectedBlockPosComponent => new("MC0004", "Expected block position component");
    public static CommandFormatError ExpectedResourceLocation => new("MC0005", "Expected resource location");
    public static CommandFormatError InvalidResourceLocation => new("MC0006", "Invalid resource location");
    public static CommandFormatError InvalidEntityAnchor => new("MC0007", "Unrecognized entity anchor");

    public static CommandFormatError ExpectedType(Type type)
    {
        return new CommandFormatError("MC0008", $"Expected '{type.Name}'");
    }

    public static CommandFormatError InvalidType(Type type)
    {
        return new CommandFormatError("MC0009", $"Invalid '{type.Name}'");
    }
}
