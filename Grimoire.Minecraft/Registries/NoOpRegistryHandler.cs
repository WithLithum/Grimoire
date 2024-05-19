using MineJason;

namespace Grimoire.Minecraft.Registries;

/// <summary>
/// A registry handler that presumes all registry entries exists.
/// </summary>
public sealed class NoOpRegistryHandler : IRegistryHandler
{
    public bool Exists(ResourceLocation registry, ResourceLocation entry)
    {
        return true;
    }
}