namespace Grimoire;
using Grimoire.Exceptions;
using System;
using System.Diagnostics;
using System.Text;

public class CommandReader
{
    public const char DoubleQuote = '"';
    public const char SingleQuote = '\'';
    public const char Escape = '\\';

    public CommandReader(string command)
    {
        Command = command;
    }

    public string Command { get; }

    public int Position { get; set; }

    public int Length => Command.Length;

    public bool CanRead(int length)
    {
        return Position + length <= Length;
    }

    public bool CanRead()
    {
        return CanRead(1);
    }

    public char Peek()
    {
        return Command[Position];
    }

    public char Peek(int offset)
    {
        return Command[Position + offset];
    }

    public char Read()
    {
        return Command[Position++];
    }

    public void Skip()
    {
        Position++;
    }

    public static bool IsAllowedNumber(char c)
    {
        return c >= '0' && c <= '9' || c == '.' || c == '-';
    }

    public static bool IsQuotedStringStart(char c)
    {
        return c == DoubleQuote || c == SingleQuote;
    }

    public void SkipWhitespace()
    {
        while (CanRead() && char.IsWhiteSpace(Peek()))
        {
            Skip();
        }
    }

    public void SkipSingleWhitespace()
    {
        if (CanRead() && char.IsWhiteSpace(Peek()))
        {
            Skip();
        }
    }

    public int ReadInt32()
    {
        var start = Position;

        while (CanRead() && IsAllowedNumber(Peek()))
        {
            Skip();
        }

        var number = Command.Substring(start, Position - start);
        if (string.IsNullOrEmpty(number))
        {
            throw CommandFormatException.Create(CommandFormatError.ExpectedInt32, this);
        }

        if (!int.TryParse(number, out var result))
        {
            throw CommandFormatException.Create(CommandFormatError.InvalidInt32, this);
        }

        return result;
    }

    public long ReadInt64()
    {
        var start = Position;

        while (CanRead() && IsAllowedNumber(Peek()))
        {
            Skip();
        }

        var number = Command.Substring(start, Position - start);
        if (string.IsNullOrEmpty(number))
        {
            throw CommandFormatException.Create(CommandFormatError.ExpectedInt64, this);
        }

        if (!long.TryParse(number, out var result))
        {
            throw CommandFormatException.Create(CommandFormatError.InvalidInt64, this);
        }

        return result;
    }

    public double ReadDouble()
    {
        var start = Position;

        while (CanRead() && IsAllowedNumber(Peek()))
        {
            Skip();
        }

        var number = Command.Substring(start, Position - start);
        if (string.IsNullOrEmpty(number))
        {
            throw CommandFormatException.Create(CommandFormatError.ExpectedDouble, this);
        }

        if (!double.TryParse(number, out var result))
        {
            throw CommandFormatException.Create(CommandFormatError.InvalidDouble, this);
        }

        return result;
    }

    public float ReadSingle()
    {
        var start = Position;

        while (CanRead() && IsAllowedNumber(Peek()))
        {
            Skip();
        }

        var number = Command.Substring(start, Position - start);
        if (string.IsNullOrEmpty(number))
        {
            throw CommandFormatException.Create(CommandFormatError.ExpectedSingle, this);
        }

        if (!float.TryParse(number, out var result))
        {
            throw CommandFormatException.Create(CommandFormatError.InvalidSingle, this);
        }

        return result;
    }

    #region Strings

    public static bool IsAllowedInUnquotedString(char c)
    {
        return c >= '0' && c <= '9'
            || c >= 'A' && c <= 'Z'
            || c >= 'a' && c <= 'z'
            || c == '_' || c == '-'
            || c == '.' || c == '+';
    }

    public string ReadUnquotedString()
    {
        int start = Position;

        while (CanRead() && IsAllowedInUnquotedString(Peek()))
        {
            Skip();
        }

        return Command.Substring(start, Position - start);
    }

    public string ReadQuotedString()
    {
        if (!CanRead())
        {
            return "";
        }

        char next = Peek();
        if (!IsQuotedStringStart(next))
        {
            throw CommandFormatException.Create(CommandFormatError.ExpectedStartOfQuote, this);
        }

        Skip();
        return ReadStringUntil(next);
    }

    public string ReadStringUntil(char terminator)
    {
        var result = new StringBuilder();

        var escaped = false;
        while (CanRead())
        {
            var c = Read();
            if (escaped)
            {
                if (c == terminator || c == Escape)
                {
                    result.Append(c);
                    escaped = false;
                }
                else
                {
                    Position -= 1;
                    throw CommandFormatException.Create(CommandFormatError.InvalidEscape, this);
                }
            }
            else if (c == Escape)
            {
                escaped = true;
            }
            else if (c == terminator)
            {
                return result.ToString();
            }
            else
            {
                result.Append(c);
            }
        }

        throw CommandFormatException.Create(CommandFormatError.ExpectedEndOfQuote, this);
    }

    public string ReadString()
    {
        if (!CanRead())
        {
            return "";
        }

        var next = Peek();
        if (IsQuotedStringStart(next))
        {
            Skip();
            return ReadStringUntil(next);
        }
        return ReadUnquotedString();
    }

    #endregion

    #region Primitives (other than numbers)

    public bool ReadBoolean()
    {
        var start = Position;
        var value = ReadString();
        if (string.IsNullOrEmpty(value))
        {
            throw CommandFormatException.Create(CommandFormatError.ExpectedBoolean, this);
        }

        if (value == "true")
        {
            return true;
        }
        else if (value == "false")
        {
            return false;
        }
        else
        {
            Position = start;
            throw CommandFormatException.Create(CommandFormatError.InvalidBoolean, this);
        }
    }

    public string GetRemaining()
    {
        return Command[Position..];
    }

    #endregion

    public void Expect(char c)
    {
        if (!CanRead() || Peek() != c)
        {
            throw CommandFormatException.Create(CommandFormatError.ExpectedCharacter(c),
                this);
        }

        Skip();
    }
}
