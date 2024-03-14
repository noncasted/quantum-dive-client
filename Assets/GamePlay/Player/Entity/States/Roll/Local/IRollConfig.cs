using GamePlay.Player.Entity.States.SubStates.Pushes.Abstract;

namespace GamePlay.Player.Entity.States.Roll.Local
{
    public interface IRollConfig
    {
        PushParams Params { get; }
    }
}