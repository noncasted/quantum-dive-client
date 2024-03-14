using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Transforms.Abstract
{
    public interface IBowTransform
    {
        Transform Transform { get; }
        void SetPosition(Vector2 position);
        void SetRotation(float angle);
    }
}