namespace Grimoire.Exceptions;
using System;

public class CommandFormatException : Exception
{
    public CommandFormatException()
    {
    }

    public CommandFormatException(CommandFormatError error, CommandExceptionContext context)
        : base(CreateMessage(error, context))
    {
        Error = error;
        Context = context;
    }

    public CommandFormatException(CommandFormatError error, CommandExceptionContext context, Exception? innerException)
        : base(CreateMessage(error, context), innerException)
    {
        Error = error;
        Context = context;
    }

    public CommandFormatError Error { get; }
    public CommandExceptionContext Context { get; }

    private static string CreateMessage(CommandFormatError error, CommandExceptionContext context)
    {
        return $"(pos. {context.Position}) {error.Identifier}: {error.Message}";
    }

    public static CommandFormatException Create(CommandFormatError error, CommandReader reader)
    {
        return new CommandFormatException(error, new CommandExceptionContext(reader.Position, reader.Command));
    }
}
