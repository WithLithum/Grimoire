namespace Grimoire;

/// <summary>
/// Defines a type with a value that can be validated.
/// </summary>
public interface IValidatable
{
    /// <summary>
    /// Determines whether the value contained in this instance is valid.
    /// </summary>
    /// <returns><see langword="true"/> if this instance is valid; otherwise, <see langword="false"/>.</returns>
    bool IsValid();
}
