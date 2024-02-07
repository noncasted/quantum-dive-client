using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Registries.States.Runtime
{
    public interface IPlayerStateMapper
    {
        int GetId(PlayerStateDefinition definition);
        PlayerStateDefinition GetDefinition(int id);
    }
}