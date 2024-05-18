using Grimoire.Minecraft.Models;
using Grimoire.Minecraft.Registries;
using NSubstitute;

namespace Grimoire.Minecraft.Tests;

using Grimoire.Exceptions;
using Grimoire.Minecraft.Archetypes.Parameters;
using MineJason;

public class ParameterTests
{
    [Fact]
    public void BlockPosParameter_Read_MixLocalAndRelative()
    {
        var reader = new CommandReader("~ ~ ^2");

        Assert.Throws<CommandFormatException>(() => new BlockPosParameter().Read(reader));
    }

    [Fact]
    public void BlockPosParameter_Read()
    {
        // Arrange
        var reader = new CommandReader("~ 20 ~");
        var parameter = new BlockPosParameter();

        // Act
        var ex = Record.Exception(() => parameter.Read(reader));
        
        // Assert
        Assert.Null(ex);
    }

    [Fact]
    public void ColumnPosParameter_Read_MixLocalAndRelative()
    {
        var reader = new CommandReader("~ ^10");

        Assert.Throws<CommandFormatException>(() => new ColumnPosParameter().Read(reader));
    }

    [Fact]
    public void ColumnPosParameter_Read_Success()
    {
        // Arrange
        var reader = new CommandReader("~ 20");
        var parameter = new ColumnPosParameter();
        
        // Act
        var ex = Record.Exception(() => parameter.Read(reader));
        
        // Assert
        Assert.Null(ex);
    }

    [Fact]
    public void ResourceLocation_Read()
    {
        // Arrange
        var reader = new CommandReader("minecraft:stone");
        var parameter = new ResourceLocationParameter();
        
        // Act
        var result = parameter.ReadArgument(reader);

        // Assert
        Assert.Equal(new ResourceLocation("minecraft", "stone"), 
            result);
    }
    
    [Fact]
    public void RegistryParameter_Read_DoesNotExistInRegistry()
    {
        // Arrange
        var registry = new ResourceLocation("test", "items");
        var entry = new ResourceLocation("test", "entry");
            
        var reader = new CommandReader(entry.ToString());

        var substitute = Substitute.For<IRegistryHandler>();
        substitute.Exists(registry, entry).Returns(false);
        
        var parameter = new RegistryParameter(substitute, registry);

        // Act
        var ex = Record.Exception(() => parameter.ReadArgument(reader));
        
        // Assert
        Assert.IsType<CommandFormatException>(ex);
    }
    
    [Fact]
    public void Angle_Read_Absolute()
    {
        // Arrange
        var reader = new CommandReader("123.45");
        var parameter = new AngleParameter();
        
        // Act
        var result = parameter.ReadArgument(reader);

        // Assert
        Assert.Equal(new Angle(123.45f, isRelative: false), 
            result);
    }
    
    [Fact]
    public void Angle_Read_Relative()
    {
        // Arrange
        var reader = new CommandReader("~67.89");
        var parameter = new AngleParameter();
        
        // Act
        var result = parameter.ReadArgument(reader);

        // Assert
        Assert.Equal(new Angle(67.89f, isRelative: true), 
            result);
    }
    
    [Fact]
    public void Angle_Read_Invalid_OutOfRange()
    {
        // Arrange
        var reader = new CommandReader("678.9");
        var parameter = new AngleParameter();
        
        // Act
        var ex = Record.Exception(() => parameter.ReadArgument(reader));

        // Assert
        Assert.IsType<CommandFormatException>(ex);
    }
    
    [Fact]
    public void Angle_Read_Invalid_FormatError()
    {
        // Arrange
        var reader = new CommandReader(".....");
        var parameter = new AngleParameter();
        
        // Act
        var ex = Record.Exception(() => parameter.ReadArgument(reader));

        // Assert
        Assert.IsType<CommandFormatException>(ex);
    }
}