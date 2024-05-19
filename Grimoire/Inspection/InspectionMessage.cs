namespace Grimoire.Inspection;

public abstract class InspectionMessage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InspectionMessage"/> class.
    /// </summary>
    /// <param name="type">The message type.</param>
    protected InspectionMessage(InspectionType type)
    {
        Type = type;
    }
    
    public InspectionType Type { get; }

    public abstract string GetMessage(InspectionContext context, params object[] arguments);

    public static InspectionMessage Create(InspectionType type, InspectionDescriptionDelegate messageDelegate)
    {
        return new InspectionMessageImpl(type, messageDelegate);
    }

    public static InspectionMessage ExpectedObject => Create(InspectionType.Error,
        (_, arguments) => string.Format("Expected '{0}' but found nothing", arguments));
    
    public static InspectionMessage InvalidObject => Create(InspectionType.Error,
        (_, arguments) => string.Format("Invalid '{0}'", arguments));
    
    public static InspectionMessage ExpectedObjectButFound => Create(InspectionType.Error,
        (_, arguments) => string.Format("Expected '{0}' but found '{1}'", arguments));
    
    public static InspectionMessage ExpectedStartOfQuote => Create(InspectionType.Error,
        (_, _) => "Expected start of quote");
    
    public static InspectionMessage ExpectedEndOfQuote => Create(InspectionType.Error,
        (_, _) => "Expected end of quote");
    
    public static InspectionMessage InvalidEscape => Create(InspectionType.Error,
        (_, arguments) => string.Format("Character '{0}' cannot be escaped", arguments));
}