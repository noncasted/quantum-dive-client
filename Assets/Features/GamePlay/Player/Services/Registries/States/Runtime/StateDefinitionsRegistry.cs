using Common.DataTypes.Collections.Common;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Registries.States.Runtime
{
    public class StateDefinitionsRegistry : IStateDefinitionsRegistry
    {
        public StateDefinitionsRegistry(PlayerStateDefinition[] definitions)
        {
            _definitions = new DoubleSideIntDictionary<PlayerStateDefinition>(definitions);
        }

        private readonly IDoubleSideDictionary<int, PlayerStateDefinition> _definitions;

        public int GetId(PlayerStateDefinition definition)
        {
            return _definitions.Keys[definition];
        }

        public PlayerStateDefinition GetDefinition(int id)
        {
            return _definitions.Values[id];
        }
    }
}