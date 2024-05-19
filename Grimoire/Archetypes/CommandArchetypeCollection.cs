using System.Collections.ObjectModel;

namespace Grimoire.Archetypes;

public class CommandArchetypeCollection : Collection<CommandArchetype>
{
    public CommandArchetypeCollection()
    {
    }

    public CommandArchetypeCollection(IList<CommandArchetype> list) : base(list)
    {
    }
}