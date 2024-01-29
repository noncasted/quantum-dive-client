using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.Transforms.Local.Runtime
{
    public interface IEnemyTransformProvider
    {
        Transform Transform { get; }
    }
}