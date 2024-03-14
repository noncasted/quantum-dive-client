using System.Collections.Generic;
using Common.DataTypes.Collections.Common;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Services.Mappers.States.Abstract;

namespace GamePlay.Player.Services.Mappers.States.Runtime
{
    public class PlayerStateMapper : IPlayerStateMapper
    {
        public PlayerStateMapper(IReadOnlyList<PlayerStateDefinition> definitions)
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