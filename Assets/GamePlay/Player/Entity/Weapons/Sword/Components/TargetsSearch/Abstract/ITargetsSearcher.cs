using System.Collections.Generic;
using GamePlay.Common.Damages;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.TargetsSearch.Runtime
    {
        public interface ITargetsSearcher
        {
            IReadOnlyList<IDamageReceiver> Search(float angle);
        }
    }
