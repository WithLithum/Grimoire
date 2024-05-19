using System.Collections.ObjectModel;

namespace Grimoire.Inspection;

public sealed class InspectionDiscoveryCollection : Collection<InspectionDiscovery>
{
    public InspectionDiscoveryCollection()
    {
    }

    public InspectionDiscoveryCollection(IList<InspectionDiscovery> list) : base(list)
    {
    }
}