using Common.DataTypes.Structs;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Transforms.Abstract
{
    public interface IPlayerTransform
    {
        Transform Transform { get; }
        Vector3 Position { get; }
        float Rotation { get; }
        Horizontal Look { get; }

        void SetPosition(Vector3 position);
        void SetRotation(float angle);
    }
}