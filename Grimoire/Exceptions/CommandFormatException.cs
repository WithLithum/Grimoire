using Grimoire.Inspection;

namespace Grimoire.Exceptions;
using System;

/// <summary>
/// An exception thrown when a fatal inspection discovery occurred and the parsing cannot continue.
/// </summary>
public class CommandFormatException : Exception
{
    public CommandFormatException()
    {
    }

    public CommandFormatException(InspectionDiscovery discovery)
        : base(CreateMessage(discovery))
    {
        Discovery = discovery;
    }

    public CommandFormatException(InspectionDiscovery discovery, Exception? innerException)
        : base(CreateMessage(discovery), innerException)
    {
        Discovery = discovery;
    }

    public InspectionDiscovery Discovery { get; }

    private static string CreateMessage(InspectionDiscovery discovery)
    {
        return $"(pos. {discovery.Context.Position}) {discovery.GetMessage()}";
    }
}
