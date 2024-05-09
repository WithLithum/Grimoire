namespace Grimoire.Archetypes.Parameters;

public abstract class CommandParameter<T> : CommandArchetype
{
    public abstract T ReadArgument(CommandReader reader);

    public override void Read(CommandReader reader)
    {
        // Disregard the final value.
        ReadArgument(reader);
    }
}
