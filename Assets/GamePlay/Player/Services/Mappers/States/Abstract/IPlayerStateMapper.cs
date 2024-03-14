using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Services.Mappers.States.Abstract
{
    public interface IPlayerStateMapper
    {
        int GetId(PlayerStateDefinition definition);
        PlayerStateDefinition GetDefinition(int id);
    }
}