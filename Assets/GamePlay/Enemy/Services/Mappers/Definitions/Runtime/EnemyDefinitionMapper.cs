using System.Collections.Generic;
using Common.DataTypes.Runtime.Collections;
using GamePlay.Enemy.Entity.Common.Definition.Asset.Abstract;
using GamePlay.Enemy.Services.Mappers.Definitions.Abstract;

namespace GamePlay.Enemy.Mappers.Definitions.Runtime
{
    public class EnemyDefinitionMapper : IEnemyDefinitionMapper
    {
        public EnemyDefinitionMapper(IReadOnlyList<IEnemyDefinition> definitions)
        {
            _definitions = new DoubleSideIntDictionary<IEnemyDefinition>(definitions);
            Definitions = definitions;
        }

        private readonly DoubleSideIntDictionary<IEnemyDefinition> _definitions;

        public IReadOnlyList<IEnemyDefinition> Definitions { get; }

        public int GetId(IEnemyDefinition definition)
        {
            return _definitions.Keys[definition];
        }

        public IEnemyDefinition GetDefinition(int id)
        {
            return _definitions.Values[id];
        }
    }
}