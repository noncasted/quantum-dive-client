using System.Collections.Generic;
using Common.DataTypes.Collections.Common;
using GamePlay.Enemy.Entity.States.Abstract;

namespace GamePlay.Enemy.Mappers.States.Runtime
{
    public class EnemyStateMapper : IEnemyStateMapper
    {
        public EnemyStateMapper(IReadOnlyList<EnemyStateDefinition> definitions)
        {
            _definitions = new DoubleSideIntDictionary<EnemyStateDefinition>(definitions);
        }

        private readonly IDoubleSideDictionary<int, EnemyStateDefinition> _definitions;

        public int GetId(EnemyStateDefinition definition)
        {
            return _definitions.Keys[definition];
        }

        public EnemyStateDefinition GetDefinition(int id)
        {
            return _definitions.Values[id];
        }
    }
}