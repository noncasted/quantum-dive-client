using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.States.Abstract
{
    public interface IPlayerLocalState
    {
        PlayerStateDefinition Definition { get; }

        void Break();
    }
}