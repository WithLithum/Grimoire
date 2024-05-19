namespace Grimoire.Inspection;

public readonly record struct InspectionDiscovery
{
    private readonly object[] _msgArguments;
    
    public InspectionDiscovery(InspectionMessage message, InspectionContext context, object[] arguments)
    {
        Message = message;
        Context = context;

        _msgArguments = arguments;
    }
    
    public InspectionMessage Message { get; }
    public InspectionContext Context { get; }

    public string GetMessage() => Message.GetMessage(Context, _msgArguments);

    public static InspectionDiscovery Create(InspectionMessage message, CommandReader reader, params object[] arguments)
    {
        return new InspectionDiscovery(message,
            new InspectionContext(reader.Position),
            arguments);
    }
}