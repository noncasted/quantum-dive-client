using GamePlay.Combat.Projectiles.Registry.Definition;

namespace GamePlay.Combat.Projectiles.Registry.Runtime
{
    public interface IProjectileDefinitionsRegistry
    {
        int GetId(IProjectileDefinition definition);
        IProjectileDefinition GetDefinition(int id);
    }
}