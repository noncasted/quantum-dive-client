using System.Collections.Generic;
using GamePlay.Enemies.Services.Spawn.Definition.Runtime;

namespace GamePlay.Enemies.Services.Spawn.Registry.Runtime
{
    public interface IEnemyDefinitionsRegistry
    {
        IReadOnlyList<IEnemyDefinition> Definitions { get; }

        int GetId(IEnemyDefinition definition);
        IEnemyDefinition GetDefinition(int id);
    }
}