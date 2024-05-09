namespace Grimoire.Exceptions;

public readonly record struct CommandExceptionContext
{
    public CommandExceptionContext(int position, string command)
    {
        Position = position;
        Command = command;
    }

    public int Position { get; }

    public string Command { get; }
}
