﻿using GamePlay.Player.Entity.Components.Healths.Runtime;
using GamePlay.Player.Entity.Views.Transforms.Local.Runtime;

namespace GamePlay.Player.Services.Provider.Runtime
{
    public interface IPlayerProvider
    {
        void AssignPlayer(IPlayerPosition position, IHealth health);
    }
}