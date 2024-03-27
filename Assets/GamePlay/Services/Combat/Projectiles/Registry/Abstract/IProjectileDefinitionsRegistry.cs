using GamePlay.Services.Projectiles.Registry.Definition;

namespace GamePlay.Services.Combat.Projectiles.Registry.Abstract
{
    public interface IProjectileDefinitionsRegistry
    {
        int GetId(IProjectileDefinition definition);
        IProjectileDefinition GetDefinition(int id);
    }
}