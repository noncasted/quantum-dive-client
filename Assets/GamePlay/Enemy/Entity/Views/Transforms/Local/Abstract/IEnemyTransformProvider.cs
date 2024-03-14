using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Transforms.Local.Abstract
{
    public interface IEnemyTransformProvider
    {
        Transform Transform { get; }
    }
}