namespace Grimoire;

/// <summary>
/// Represents a parameter, word, or otherwise, any part of a command.
/// </summary>
public abstract class CommandArchetype
{
    public abstract void Read(CommandReader reader);
}