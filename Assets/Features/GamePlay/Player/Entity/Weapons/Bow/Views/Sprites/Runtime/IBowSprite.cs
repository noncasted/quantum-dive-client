using Common.Architecture.Lifetimes.Viewables;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Sprites.Runtime
{
    public interface IBowSprite
    {
        IViewableDelegate<bool> YFlipped { get; }
        IViewableDelegate<int> SortingOrderChanged { get; }
        
        void SetSortingOrder(int order);
        void FlipY(bool isFlipped);
        void FlipX(bool isFlipped);
    }
}