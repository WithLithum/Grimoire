namespace Grimoire.Exceptions;

[Obsolete("Use InspectionMessage instead.")]
public readonly record struct CommandFormatError
{
    public CommandFormatError(string identifier, string message)
    {
        Identifier = identifier;
        Message = message;
    }

    public string Identifier { get; }

    public string Message { get; }
    
    public static CommandFormatError ExpectedInt32 => new("CMD0001", "Expected Int32 but found nothing");
    public static CommandFormatError InvalidInt32 => new("CMD0002", "Invalid Int32");
    public static CommandFormatError ExpectedInt64 => new("CMD0003", "Expected Int64 but found nothing");
    public static CommandFormatError InvalidInt64 => new("CMD0004", "Invalid Int64");
    public static CommandFormatError ExpectedDouble => new("CMD0005", "Expected Double but found nothing");
    public static CommandFormatError InvalidDouble => new("CMD0006", "Invalid Double");
    public static CommandFormatError ExpectedSingle => new("CMD0007", "Expected Single but found nothing");
    public static CommandFormatError InvalidSingle => new("CMD0008", "Invalid Single");
    public static CommandFormatError ExpectedStartOfQuote => new("CMD0009", "Expected start of quote");
    public static CommandFormatError InvalidEscape => new("CMD0010", "The character cannot be escaped");
    public static CommandFormatError ExpectedEndOfQuote => new("CMD0011", "Expected end of quote");
    public static CommandFormatError ExpectedBoolean => new("CMD0012", "Expected Boolean but found nothing");
    public static CommandFormatError InvalidBoolean => new("CMD0013", "Invalid Boolean");

    public static CommandFormatError ExpectedCharacter(char expected)
    {
        return new CommandFormatError("CMD0014", $"Expected character '{expected}'");
    }

    public static CommandFormatError DoubleExceedsMaximum(double maximum)
    {
        return new CommandFormatError("CMD0015", $"Expected Double below {maximum}");
    }

    public static CommandFormatError DoubleLessThanMinimum(double minimum)
    {
        return new CommandFormatError("CMD0015", $"Expected Double bigger than {minimum}");
    }

    public static CommandFormatError ExpectedWord(string expected)
    {
        return new CommandFormatError("CMD0016", $"Expected \"{expected}\"");
    }
}
