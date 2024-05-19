namespace Grimoire.Inspection;

public delegate string InspectionDescriptionDelegate(InspectionContext context, params object[] arguments);

internal class InspectionMessageImpl : InspectionMessage
{
    private readonly InspectionDescriptionDelegate _delegate;

    internal InspectionMessageImpl(InspectionType type, InspectionDescriptionDelegate dlg) : base(type)
    {
        _delegate = dlg;
    }

    public override string GetMessage(InspectionContext context, params object[] arguments)
    {
        return _delegate(context, arguments);
    }
}