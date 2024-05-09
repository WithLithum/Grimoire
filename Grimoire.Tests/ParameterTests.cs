namespace Grimoire.Tests;

using Grimoire.Archetypes.Parameters;
using Grimoire.Exceptions;

public class ParameterTests
{
    [Fact]
    public void Int32Parameter_UpperLimit()
    {
        var reader = new CommandReader("99999");

        var parameter = new Int32Parameter(null, 10000);

        Assert.Throws<CommandFormatException>(() => parameter.Read(reader));
    }

    [Fact]
    public void Int32Parameter_LowerLimit()
    {
        var reader = new CommandReader("10");

        var parameter = new Int32Parameter(100, null);

        Assert.Throws<CommandFormatException>(() => parameter.Read(reader));
    }

    [Fact]
    public void Int64Parameter_UpperLimit()
    {
        var reader = new CommandReader("100000000000");

        var parameter = new Int64Parameter(null, 10000000);

        Assert.Throws<CommandFormatException>(() => parameter.Read(reader));
    }

    [Fact]
    public void Int64Parameter_LowerLimit()
    {
        var reader = new CommandReader("10");

        var parameter = new Int64Parameter(100, null);

        Assert.Throws<CommandFormatException>(() => parameter.Read(reader));
    }

    [Fact]
    public void StringParameter_Word()
    {
        var reader = new CommandReader("word another");

        var parameter = new StringParameter(StringParameter.StringType.Word);

        Assert.Equal("word", parameter.ReadArgument(reader));
    }

    [Fact]
    public void StringParameter_QuotablePhrase()
    {
        var reader = new CommandReader("\"quoted\" another");

        var parameter = new StringParameter(StringParameter.StringType.QuotablePhrase);

        Assert.Equal("quoted", parameter.ReadArgument(reader));
    }

    [Fact]
    public void StringParameter_GreedyPhrase()
    {
        var reader = new CommandReader("greedy string");

        var parameter = new StringParameter(StringParameter.StringType.GreedyPhrase);

        Assert.Equal("greedy string", parameter.ReadArgument(reader));
    }
}
