using GamePlay.Player.Entity.States.SubStates.Pushes.Abstract;
using GamePlay.Player.Entity.States.SubStates.Pushes.Runtime;

namespace GamePlay.Player.Entity.States.Roll.Local
{
    public interface IRollConfig
    {
        PushParams Params { get; }
    }
}