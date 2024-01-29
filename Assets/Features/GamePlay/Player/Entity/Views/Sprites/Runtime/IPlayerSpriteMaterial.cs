using UnityEngine;

namespace GamePlay.Player.Entity.Views.Sprites.Runtime
{
    public interface IPlayerSpriteMaterial
    {
        Material Material { get; }

        void SetMaterial(Material material);
    }
}