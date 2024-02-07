using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Mappers.States.Runtime
{
    public interface IPlayerStateMapper
    {
        int GetId(PlayerStateDefinition definition);
        PlayerStateDefinition GetDefinition(int id);
    }
}