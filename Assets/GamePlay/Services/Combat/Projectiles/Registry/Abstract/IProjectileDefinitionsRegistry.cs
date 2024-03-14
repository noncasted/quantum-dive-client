using GamePlay.Projectiles.Registry.Definition;

namespace GamePlay.Projectiles.Registry.Runtime
{
    public interface IProjectileDefinitionsRegistry
    {
        int GetId(IProjectileDefinition definition);
        IProjectileDefinition GetDefinition(int id);
    }
}