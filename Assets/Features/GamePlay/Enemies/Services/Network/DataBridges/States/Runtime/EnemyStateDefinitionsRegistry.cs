using System.Collections.Generic;
using GamePlay.Enemies.Entity.States.Abstract;

namespace GamePlay.Enemies.Services.Network.DataBridges.States.Runtime
{
    public class EnemyStateDefinitionsRegistry : IEnemyStateDefinitionsRegistry
    {
        public EnemyStateDefinitionsRegistry(EnemyStateDefinition[] definitions)
        {
            var length = definitions.Length;

            var definitionsDictionary = new Dictionary<int, EnemyStateDefinition>();
            var idsDictionary = new Dictionary<EnemyStateDefinition, int>();
            
            for (var i = 0; i < length; i++)
            {
                var definition = definitions[i];
                definitionsDictionary.Add(i, definition);
                idsDictionary.Add(definition, i);
            }

            _definitions = definitionsDictionary;
            _ids = idsDictionary;
        }

        private readonly IReadOnlyDictionary<int, EnemyStateDefinition> _definitions;
        private readonly IReadOnlyDictionary<EnemyStateDefinition, int> _ids;

        public int GetId(EnemyStateDefinition definition)
        {
            return _ids[definition];
        }

        public EnemyStateDefinition GetDefinition(int id)
        {
            return _definitions[id];
        }
    }
}