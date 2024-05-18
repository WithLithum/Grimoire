using Grimoire.Minecraft.Models;

namespace Grimoire.Minecraft.Tests;

public class ModelTests
{
    [Fact]
    public void Angle_TryParse_Absolute()
    {
        // Arrange
        const string stringToParse = "152.35";
        
        // Act
        var succeed = Angle.TryParse(stringToParse, out var result);
        
        // Assert
        Assert.Multiple(() => Assert.True(succeed),
            () => Assert.Equal(new Angle(152.35f, isRelative: false),
                result));
    }
    
    [Fact]
    public void Angle_TryParse_Relative()
    {
        // Arrange
        const string stringToParse = "~55.5";
        
        // Act
        var succeed = Angle.TryParse(stringToParse, out var result);
        
        // Assert
        Assert.Multiple(() => Assert.True(succeed),
            () => Assert.Equal(new Angle(55.5f, isRelative: true),
                result));
    }
    
    [Fact]
    public void Angle_TryParse_Invalid_Format()
    {
        // Arrange
        const string stringToParse = "~~~";
        
        // Act
        var succeed = Angle.TryParse(stringToParse, out _);
        
        // Assert
        Assert.False(succeed);
    }
    
    [Fact]
    public void Angle_TryParse_Invalid_OutOfRange()
    {
        // Arrange
        const string stringToParse = "1234.56";
        
        // Act
        var succeed = Angle.TryParse(stringToParse, out _);
        
        // Assert
        Assert.False(succeed);
    }
}