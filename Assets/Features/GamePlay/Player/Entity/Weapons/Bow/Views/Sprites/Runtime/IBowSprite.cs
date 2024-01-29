using System;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Sprites.Runtime
{
    public interface IBowSprite
    {
        event Action<bool> YFlipped;
        event Action<int> SortingOrderChanged;
        
        
        void SetSortingOrder(int order);
        void FlipY(bool isFlipped);
        void FlipX(bool isFlipped);
    }
}