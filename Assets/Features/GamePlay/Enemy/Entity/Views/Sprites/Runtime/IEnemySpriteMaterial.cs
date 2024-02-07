using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.Sprites.Runtime
{
    public interface IEnemySpriteMaterial
    {
        Material Material { get; }

        void SetMaterial(Material material);
    }
}