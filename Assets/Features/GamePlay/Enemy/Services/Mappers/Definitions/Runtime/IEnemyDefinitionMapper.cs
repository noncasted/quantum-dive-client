using System.Collections.Generic;
using GamePlay.Enemies.Entity.Definition.Asset.Abstract;

namespace GamePlay.Enemies.Mappers.Definitions.Runtime
{
    public interface IEnemyDefinitionMapper
    {
        IReadOnlyList<IEnemyDefinition> Definitions { get; }

        int GetId(IEnemyDefinition definition);
        IEnemyDefinition GetDefinition(int id);
    }
}