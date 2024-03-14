using GamePlay.Player.Entity.Weapons.Bow.Views.ShootPoint.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.ShootPoint.Runtime
{
    public class BowShootPoint : IBowShootPoint
    {
        public BowShootPoint(ShootPointProvider provider)
        {
            _provider = provider;
        }

        private readonly ShootPointProvider _provider;

        public Transform Point => _provider.Point;
    }
}