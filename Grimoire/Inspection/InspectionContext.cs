namespace Grimoire.Inspection;

public readonly record struct InspectionContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InspectionContext"/> structure.
    /// </summary>
    /// <param name="position">The position of the error.</param>
    public InspectionContext(int position)
    {
        Position = position;
    }
    
    public int Position { get; }
}