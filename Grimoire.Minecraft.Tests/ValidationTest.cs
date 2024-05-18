namespace Grimoire.Minecraft.Tests;

using Grimoire.Minecraft.Models;
using MineJason.Data.Coordinates;

public class ValidationTest
{
    [Fact]
    public void ColumnPosition_IsValid_MixLocalAndWorld()
    {
        var pos = new ColumnPosition(new BlockPositionComponent(5, BlockPositionComponentType.Local),
            new BlockPositionComponent(25, BlockPositionComponentType.Absolute));

        Assert.False(pos.IsValid());
    }

    [Fact]
    public void ColumnPosition_IsValid_AllLocal()
    {
        var pos = new ColumnPosition(new BlockPositionComponent(15, BlockPositionComponentType.Local),
            new BlockPositionComponent(20, BlockPositionComponentType.Local));

        Assert.True(pos.IsValid());
    }

    [Fact]
    public void ColumnPosition_IsValid_AllAbsolute()
    {
        var pos = new ColumnPosition(new BlockPositionComponent(159, BlockPositionComponentType.Absolute),
            new BlockPositionComponent(279, BlockPositionComponentType.Absolute));

        Assert.True(pos.IsValid());
    }

    [Fact]
    public void ColumnPosition_IsValid_AllRelative()
    {
        var pos = new ColumnPosition(new BlockPositionComponent(10, BlockPositionComponentType.Relative),
            new BlockPositionComponent(3, BlockPositionComponentType.Relative));

        Assert.True(pos.IsValid());
    }
}
