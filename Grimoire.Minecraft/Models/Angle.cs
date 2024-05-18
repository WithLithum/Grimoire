namespace Grimoire.Minecraft.Models;

public readonly record struct Angle : IValidatable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Angle"/> structure.
    /// </summary>
    /// <param name="value">The value, in degrees. Must be between <c>-180.0</c> and <c>179.9</c>.</param>
    /// <param name="isRelative">If <see langword="true"/>, this instance is relative.</param>
    public Angle(float value, bool isRelative = false)
    {
        Value = value;
        IsRelative = isRelative;
    }
    
    /// <summary>
    /// Gets the value, in degrees, of this instance.
    /// </summary>
    public float Value { get; }
    
    /// <summary>
    /// Gets a value indicating whether the specified value is a relative angle.
    /// </summary>
    public bool IsRelative { get; }
    
    public bool IsValid()
    {
        return Value is >= -180f and < 180f;
    }

    public static bool TryParse(string str, out Angle result)
    {
        result = default;
        var relative = str.StartsWith('~');

        var strToParse = relative ? str[1..] : str;
        if (!float.TryParse(strToParse, out var degrees))
        {
            return false;
        }

        result = new Angle(degrees, relative);
        return result.IsValid();
    }
}