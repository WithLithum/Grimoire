using Grimoire.Exceptions;
using Grimoire.Inspection;

namespace Grimoire;

public static class Inquest
{
    public static bool DoesParse(CommandReader reader, CommandArchetype archetype)
    {
        var discoveries = new InspectionDiscoveryCollection();
        
        try
        {
            archetype.Read(reader, discoveries);
        }
        catch (CommandFormatException e)
        {
            return false;
        }

        return discoveries.All(x => x.Message.Type != InspectionType.Error);
    }
}