using System.Collections.Generic;
using Common.DataTypes.Collections.Common;
using GamePlay.Enemies.Entity.Definition.Asset.Abstract;

namespace GamePlay.Enemies.Services.Spawn.Registry.Runtime
{
    public class EnemyDefinitionsRegistry : IEnemyDefinitionsRegistry
    {
        public EnemyDefinitionsRegistry(IReadOnlyList<IEnemyDefinition> definitions)
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