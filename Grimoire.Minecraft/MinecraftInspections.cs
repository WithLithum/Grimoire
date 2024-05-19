using Grimoire.Inspection;
using MineJason;

namespace Grimoire.Minecraft;

using Grimoire.Exceptions;

public static class MinecraftInspections
{
    public static InspectionMessage InvalidBlockPosComponent => 
        InspectionMessage.Create(InspectionType.Error,
            (_, _) => "Invalid block position component");
    
    public static InspectionMessage MixLocalAndWorld => InspectionMessage.Create(InspectionType.Error,
        (_, _) => "Mixed local & world coordinates");
    public static InspectionMessage ExpectedBlockPosComponent => InspectionMessage.Create(InspectionType.Error,
        (_, _) =>"Expected block position component");
    public static InspectionMessage ExpectedResourceLocation => InspectionMessage.Create(InspectionType.Error,
        (_, _) => "Expected resource location");
    public static InspectionMessage InvalidResourceLocation => InspectionMessage.Create(InspectionType.Error,
        (_, _) => "Invalid resource location");

    public static InspectionMessage ExpectedType => InspectionMessage.Create(InspectionType.Error,
        (_, arguments) => string.Format("Expected '{0}'", arguments));
    
    public static InspectionMessage InvalidType => InspectionMessage.Create(InspectionType.Error,
        (_, arguments) => string.Format("Invalid '{0}'", arguments));

    public static InspectionMessage InvalidRegistryEntry => InspectionMessage.Create(InspectionType.Error,
        (_, arguments) => string.Format("Registry '{0}' does not contain entry '{1}'", arguments));

    public static InspectionDiscovery DiscoverExpectedType(CommandReader reader, Type expected)
        => InspectionDiscovery.Create(ExpectedType, reader, expected);
    
    public static InspectionDiscovery DiscoverInvalidType(CommandReader reader, Type expected)
        => InspectionDiscovery.Create(InvalidType, reader, expected);
}
