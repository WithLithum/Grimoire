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
        var reader = new CommandReader("~ 20 ~");

        new BlockPosParameter().Read(reader);
    }

    [Fact]
    public void ResourceLocation_Read()
    {
        var reader = new CommandReader("minecraft:stone");

        Assert.Equal(new ResourceLocation("minecraft", "stone"), 
            new ResourceLocationParameter().ReadArgument(reader));
    }
}