using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Runtime
{
    public class BowArrow : IBowArrow, IEntitySwitchLifetimeListener
    {
        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
        }

        public void Show(Sprite sprite)
        {
        }

        public void Hide()
        {
        }

        private void OnSortingOrderChanged(int order)
        {
        }

        private void OnYFlipped(bool isFlipped)
        {
        }
    }
}