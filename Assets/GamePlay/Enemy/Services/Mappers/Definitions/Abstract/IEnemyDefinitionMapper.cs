using System.Collections.Generic;
using GamePlay.Enemy.Entity.Common.Definition.Asset.Abstract;

namespace GamePlay.Enemy.Mappers.Definitions.Runtime
{
    public interface IEnemyDefinitionMapper
    {
        IReadOnlyList<IEnemyDefinition> Definitions { get; }

        int GetId(IEnemyDefinition definition);
        IEnemyDefinition GetDefinition(int id);
    }
}