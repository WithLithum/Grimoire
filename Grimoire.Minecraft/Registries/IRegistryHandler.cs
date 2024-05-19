using MineJason;

namespace Grimoire.Minecraft.Registries;

public interface IRegistryHandler
{
    bool Exists(ResourceLocation registry, ResourceLocation entry);
}