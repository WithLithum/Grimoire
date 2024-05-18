using Grimoire.Exceptions;
using Grimoire.Minecraft.Registries;
using MineJason;

namespace Grimoire.Minecraft.Archetypes.Parameters;

public class RegistryParameter : ResourceLocationParameter
{
    private readonly IRegistryHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegistryParameter"/> class.
    /// </summary>
    /// <param name="handler">The registry handler to be used for resolving registries.</param>
    /// <param name="registry">The registry.</param>
    public RegistryParameter(IRegistryHandler handler, ResourceLocation registry)
    {
        _handler = handler;
        Registry = registry;
    }
    
    /// <summary>
    /// Gets the registry associated with this instance.
    /// </summary>
    public ResourceLocation Registry { get; }

    public override ResourceLocation ReadArgument(CommandReader reader)
    {
        var rl = base.ReadArgument(reader);

        if (!_handler.Exists(Registry, rl))
        {
            throw CommandFormatException.Create(MinecraftCommandErrors.InvalidRegistryEntry(Registry, rl),
                reader);
        }

        return rl;
    }
}