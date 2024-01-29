using System.Collections.Generic;
using GamePlay.Enemies.Services.Spawn.Definition.Runtime;

namespace GamePlay.Enemies.Services.Spawn.Registry.Runtime
{
    public class EnemyDefinitionsRegistry : IEnemyDefinitionsRegistry
    {
        public EnemyDefinitionsRegistry(IEnemyDefinition[] definitions)
        {
            Definitions = definitions;
            _ids = new Dictionary<IEnemyDefinition, int>();
            _definitions = new Dictionary<int, IEnemyDefinition>();

            for (var i = 0; i < definitions.Length; i++)
            {
                var definition = definitions[i];
                _ids.Add(definition, i);
                _definitions.Add(i, definition);
            }
        }

        private readonly Dictionary<IEnemyDefinition, int> _ids;
        private readonly Dictionary<int, IEnemyDefinition> _definitions;

        public IReadOnlyList<IEnemyDefinition> Definitions { get; }

        public int GetId(IEnemyDefinition definition)
        {
            return _ids[definition];
        }

        public IEnemyDefinition GetDefinition(int id)
        {
            return _definitions[id];
        }
    }
}