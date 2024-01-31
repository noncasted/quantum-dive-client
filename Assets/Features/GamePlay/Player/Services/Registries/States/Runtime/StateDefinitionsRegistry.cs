using System.Collections.Generic;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Registries.States.Runtime
{
    public class StateDefinitionsRegistry : IStateDefinitionsRegistry
    {
        public StateDefinitionsRegistry(PlayerStateDefinition[] definitions)
        {
            var length = definitions.Length;

            var definitionsDictionary = new Dictionary<int, PlayerStateDefinition>();
            var idsDictionary = new Dictionary<PlayerStateDefinition, int>();
            
            for (var i = 0; i < length; i++)
            {
                var definition = definitions[i];
                definitionsDictionary.Add(i, definition);
                idsDictionary.Add(definition, i);
            }

            _definitions = definitionsDictionary;
            _ids = idsDictionary;
        }

        private readonly IReadOnlyDictionary<int, PlayerStateDefinition> _definitions;
        private readonly IReadOnlyDictionary<PlayerStateDefinition, int> _ids;

        public int GetId(PlayerStateDefinition definition)
        {
            return _ids[definition];
        }

        public PlayerStateDefinition GetDefinition(int id)
        {
            return _definitions[id];
        }
    }
}