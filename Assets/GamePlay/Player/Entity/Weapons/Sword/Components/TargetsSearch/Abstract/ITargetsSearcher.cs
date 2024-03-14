using System.Collections.Generic;
using GamePlay.Common.Damages;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.TargetsSearch.Abstract
    {
        public interface ITargetsSearcher
        {
            IReadOnlyList<IDamageReceiver> Search(float angle);
        }
    }
