using Common.DataTypes.Reactive;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Runs.Local
{
    public interface IRunInput
    {
        IViewableDelegate Performed { get; }
        IViewableDelegate Canceled { get; }

        Vector2 Direction { get; }
        bool HasInput { get; }
    }
}