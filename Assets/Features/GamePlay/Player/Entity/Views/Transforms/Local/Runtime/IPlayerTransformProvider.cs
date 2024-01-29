using UnityEngine;

namespace GamePlay.Player.Entity.Views.Transforms.Local.Runtime
{
    public interface IPlayerTransformProvider
    {
        Transform Transform { get; }
    }
}