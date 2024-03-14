using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Sprites.Abstract
{
    public interface IEnemySpriteMaterial
    {
        Material Material { get; }

        void SetMaterial(Material material);
    }
}