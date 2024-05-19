namespace Grimoire.Tests;

using Grimoire.Archetypes.Parameters;
using Grimoire.Exceptions;

public class ParameterTests
{
    [Fact]
    public void Int32Parameter_UpperLimit()
    {
        // Arrange
        var reader = new CommandReader("99999");
        var parameter = new Int32Parameter(null, 10000);

        // Act
        var success = Inquest.DoesParse(reader, parameter);

        // Assert
        Assert.False(success);
    }

    [Fact]
    public void Int32Parameter_LowerLimit()
    {
        // Arrange
        var reader = new CommandReader("10");
        var parameter = new Int32Parameter(100, null);

        // Act
        var success = Inquest.DoesParse(reader, parameter);

        // Assert
        Assert.False(success);
    }

    [Fact]
    public void Int64Parameter_UpperLimit()
    {
        // Arrange
        var reader = new CommandReader("100000000000");
        var parameter = new Int64Parameter(null, 10000000);

        // Act
        var success = Inquest.DoesParse(reader, parameter);

        // Assert
        Assert.False(success);
    }

    [Fact]
    public void Int64Parameter_LowerLimit()
    {
        // Arrange
        var reader = new CommandReader("10");
        var parameter = new Int64Parameter(100, null);

        // Act
        var success = Inquest.DoesParse(reader, parameter);

        // Assert
        Assert.False(success);
    }

    [Fact]
    public void StringParameter_Word()
    {
        // Arrange
        var reader = new CommandReader("word another");
        var parameter = new StringParameter();

        // Act
        var result = parameter.ReadArgument(reader, []);
        
        // Assert
        Assert.Equal("word", result);
    }

    [Fact]
    public void StringParameter_QuotablePhrase()
    {
        // Arrange
        var reader = new CommandReader("\"quoted\" another");
        var parameter = new StringParameter(StringParameter.StringType.QuotablePhrase);

        // Act
        var result = parameter.ReadArgument(reader, []);
        
        // Assert
        Assert.Equal("quoted", result);
    }

    [Fact]
    public void StringParameter_GreedyPhrase()
    {
        // Arrange
        var reader = new CommandReader("greedy string");
        var parameter = new StringParameter(StringParameter.StringType.GreedyPhrase);

        // Act
        var result = parameter.ReadArgument(reader, []);
        
        // Assert
        Assert.Equal("greedy string", result);
    }
}
