namespace Grimoire.Tests;

using Grimoire.Archetypes;
using Grimoire.Archetypes.Parameters;
using Grimoire.Exceptions;

public class CommandTests
{
    [Fact]
    public void StandardCommand_Simple()
    {
        var command = new StandardCommandRoot("command",
            [
                new BooleanParameter()
            ]);

        // Test succeeds if the below code does NOT throw anything:
        command.Read(new CommandReader("command true"));
    }

    [Fact]
    public void StandardCommand_Multiple()
    {
        var command = new StandardCommandRoot("multi",
            [
                new BooleanParameter(),
                new Int32Parameter()
            ]);

        // Test succeeds if the below code does NOT throw anything:
        command.Read(new CommandReader("multi false 3317711"));
    }

    [Fact]
    public void StandardCommand_Simple_CommandNameInvalid()
    {
        var command = new StandardCommandRoot("command",
            [
                new BooleanParameter()
            ]);

        Assert.Throws<CommandFormatException>(() => command.Read(new CommandReader("this_some_command false")));
    }

    [Fact]
    public void StandardCommand_Simple_SeparatorNotSpace()
    {
        var command = new StandardCommandRoot("command",
            [
                new BooleanParameter()
            ]);

        Assert.Throws<CommandFormatException>(() => command.Read(new CommandReader("command_false")));
    }

    [Fact]
    public void StandardCommand_Simple_TwoSpaces()
    {
        var command = new StandardCommandRoot("command",
            [
                new BooleanParameter()
            ]);

        Assert.Throws<CommandFormatException>(() => command.Read(new CommandReader("command  false")));
    }
}