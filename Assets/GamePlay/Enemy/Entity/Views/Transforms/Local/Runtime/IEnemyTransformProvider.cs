using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Transforms.Local.Runtime
{
    public interface IEnemyTransformProvider
    {
        Transform Transform { get; }
    }
}