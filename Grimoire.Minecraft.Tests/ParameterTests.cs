using Grimoire.Minecraft.Models;
using Grimoire.Minecraft.Registries;
using NSubstitute;

namespace Grimoire.Minecraft.Tests;

using Grimoire.Minecraft.Archetypes.Parameters;
using MineJason;

public class ParameterTests
{
    [Fact]
    public void BlockPosParameter_Read_MixLocalAndRelative()
    {
        // Arrange
        var reader = new CommandReader("~ ~ ^2");
        var parameter = new BlockPosParameter();
        
        // Act
        var success = Inquest.DoesParse(reader, parameter);

        // Assert
        Assert.False(success);
    }

    [Fact]
    public void BlockPosParameter_Read()
    {
        // Arrange
        var reader = new CommandReader("~ 20 ~");
        var parameter = new BlockPosParameter();

        // Act
        var success = Inquest.DoesParse(reader, parameter);

        // Assert
        Assert.True(success);
    }

    [Fact]
    public void ColumnPosParameter_Read_MixLocalAndRelative()
    {
        // Arrange
        var reader = new CommandReader("~ ^10");
        var parameter = new ColumnPosParameter();

        // Act
        var success = Inquest.DoesParse(reader, parameter);

        // Assert
        Assert.False(success);
    }

    [Fact]
    public void ColumnPosParameter_Read_Success()
    {
        // Arrange
        var reader = new CommandReader("~ 20");
        var parameter = new ColumnPosParameter();
        
        // Act
        var success = Inquest.DoesParse(reader, parameter);

        // Assert
        Assert.True(success);
    }

    [Fact]
    public void ResourceLocation_Read()
    {
        // Arrange
        var reader = new CommandReader("minecraft:stone");
        var parameter = new ResourceLocationParameter();
        
        // Act
        // Disregard the discoveries. If any error, this will sure to fail.
        var result = parameter.ReadArgument(reader, []);

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
        var success = Inquest.DoesParse(reader, parameter);

        // Assert
        Assert.False(success);
    }
    
    [Fact]
    public void Angle_Read_Absolute()
    {
        // Arrange
        var reader = new CommandReader("123.45");
        var parameter = new AngleParameter();
        
        // Act
        // Disregard the discoveries. If any error, this will sure to fail.
        var result = parameter.ReadArgument(reader, []);

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
        // Disregard the discoveries. If any error, this will sure to fail.
        var result = parameter.ReadArgument(reader, []);

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
        var success = Inquest.DoesParse(reader, parameter);

        // Assert
        Assert.False(success);
    }
    
    [Fact]
    public void Angle_Read_Invalid_FormatError()
    {
        // Arrange
        var reader = new CommandReader(".....");
        var parameter = new AngleParameter();
        
        // Act
        var success = Inquest.DoesParse(reader, parameter);

        // Assert
        Assert.False(success);
    }
}