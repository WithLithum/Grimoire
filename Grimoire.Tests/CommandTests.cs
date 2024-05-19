namespace Grimoire.Tests;

using Grimoire.Archetypes;
using Grimoire.Archetypes.Parameters;
using Grimoire.Exceptions;

public class CommandTests
{
    [Fact]
    public void StandardCommand_Simple()
    {
        // Arrange
        var command = new StandardCommandRoot("command",
            [
                new BooleanParameter()
            ]);

        var reader = new CommandReader("command true");
        
        // Act
        var success = Inquest.DoesParse(reader, command);

        // Assert
        Assert.True(success);
    }

    [Fact]
    public void StandardCommand_Multiple()
    {
        // Arrange
        var command = new StandardCommandRoot("multi",
            [
                new BooleanParameter(),
                new Int32Parameter()
            ]);
        var reader = new CommandReader("multi false 3317711");

        // Act
        var success = Inquest.DoesParse(reader, command);
        
        // Assert
        Assert.True(success);
    }

    [Fact]
    public void StandardCommand_Simple_CommandNameInvalid()
    {
        // Arrange
        var command = new StandardCommandRoot("command",
            [
                new BooleanParameter()
            ]);
        var reader = new CommandReader("this_some_command false");

        // Act
        var success = Inquest.DoesParse(reader, command);
        
        // Assert
        Assert.False(success);
    }

    [Fact]
    public void StandardCommand_Simple_SeparatorNotSpace()
    {
        // Arrange
        var command = new StandardCommandRoot("command",
            [
                new BooleanParameter()
            ]);
        var reader = new CommandReader("command_false");
        
        // Act
        var success = Inquest.DoesParse(reader, command);

        // Assert
        Assert.False(success);
    }

    [Fact]
    public void StandardCommand_Simple_TwoSpaces()
    {
        // Arrange
        var command = new StandardCommandRoot("command",
            [
                new BooleanParameter()
            ]);
        var reader = new CommandReader("command  false");

        // Act
        var success = Inquest.DoesParse(reader, command);

        // Assert
        Assert.False(success);
    }
}