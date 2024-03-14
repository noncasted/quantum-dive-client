using System.Collections.Generic;
using GamePlay.Enemy.Entity.Common.Definition.Asset.Abstract;

namespace GamePlay.Enemy.Services.Mappers.Definitions.Abstract
{
    public interface IEnemyDefinitionMapper
    {
        IReadOnlyList<IEnemyDefinition> Definitions { get; }

        int GetId(IEnemyDefinition definition);
        IEnemyDefinition GetDefinition(int id);
    }
}