using Common.DataTypes.Structs;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Transforms.Local.Abstract
{
    public interface IEnemyTransform
    {
        Vector3 Position { get; }
        float Rotation { get; }
        Horizontal Look { get; }

        void SetPosition(Vector3 position);
        void SetRotation(float angle);
    }
}