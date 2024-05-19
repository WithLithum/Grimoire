namespace Grimoire.Archetypes.Patterns;

public class PatternArchetype : CommandArchetype
{
    public PatternArchetype(CommandArchetypeCollection? archetypes = null)
    {
        if (archetypes != null)
        {
            Archetypes = archetypes;
        }
    }
    
    public CommandArchetypeCollection Archetypes { get; } = new();
    
    public override void Read(CommandReader reader)
    {
        foreach (var archetype in Archetypes)
        {
            archetype.Read(reader);
        }
    }
}