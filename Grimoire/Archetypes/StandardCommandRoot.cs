using Grimoire.Inspection;

namespace Grimoire.Archetypes;

using Grimoire.Exceptions;

/// <summary>
/// Represents a standard command, where there is a simple, flat, fixed list of arguments.
/// </summary>
public class StandardCommandRoot : CommandArchetype
{
    public StandardCommandRoot(string name)
    {
        Name = name;
    }

    public StandardCommandRoot(string name, IList<CommandArchetype> members)
    {
        Name = name;
        Members = members;
    }

    public string Name { get; }

    public IList<CommandArchetype> Members { get; } = [];

    public override void Read(CommandReader reader, InspectionDiscoveryCollection discoveries)
    {
        var cmdName = reader.ReadUnquotedString();
        if (cmdName != Name)
        {
            discoveries.Add(InspectionDiscovery.Create(InspectionMessage.ExpectedObjectButFound,
                reader,
                Name,
                cmdName));
            return;
        }

        foreach (var member in Members)
        {
            if (reader.Peek() == ' ')
            {
                reader.Skip();
            }

            member.Read(reader, discoveries);
        }
    }
}
