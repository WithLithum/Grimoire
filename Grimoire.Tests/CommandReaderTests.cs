namespace Grimoire.Tests;

using Grimoire.Exceptions;

public class CommandReaderTests
{
    [Fact]
    public void ReadUnquotedString()
    {
        var reader = new CommandReader("unquoted_blah");

        Assert.Equal("unquoted_blah", reader.ReadUnquotedString());
    }

    [Fact]
    public void ReadUnquotedString_Multiple()
    {
        var reader = new CommandReader("blah not_me");

        Assert.Equal("blah", reader.ReadUnquotedString());
    }

    [Fact]
    public void ReadQuotedString()
    {
        var reader = new CommandReader("\"quoted blah\"");

        Assert.Equal("quoted blah", reader.ReadQuotedString());
    }

    [Fact]
    public void ReadQuotedString_ExpectedBeginOfQuote()
    {
        var reader = new CommandReader("blah_blah_blah");

        Assert.Throws<CommandFormatException>(reader.ReadQuotedString);
    }

    [Fact]
    public void ReadQuotedString_ExpectedEndOfQuote()
    {
        var reader = new CommandReader("\"quoted blah");

        Assert.Throws<CommandFormatException>(reader.ReadQuotedString);
    }

    [Fact]
    public void ReadInt32()
    {
        var reader = new CommandReader("1234567");

        Assert.Equal(1234567, reader.ReadInt32());
    }

    [Fact]
    public void ReadInt64()
    {
        var reader = new CommandReader("12345678910111213");

        Assert.Equal(12345678910111213L, reader.ReadInt64());
    }

    [Fact]
    public void ReadSingle()
    {
        var reader = new CommandReader("123.456");

        Assert.Equal(123.456f, reader.ReadSingle());
    }

    [Fact]
    public void ReadDouble()
    {
        var reader = new CommandReader("123.456789");

        Assert.Equal(123.456789, reader.ReadDouble());
    }
}
