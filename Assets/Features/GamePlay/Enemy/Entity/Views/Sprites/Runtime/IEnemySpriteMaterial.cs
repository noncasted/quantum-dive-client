using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Sprites.Runtime
{
    public interface IEnemySpriteMaterial
    {
        Material Material { get; }

        void SetMaterial(Material material);
    }
}