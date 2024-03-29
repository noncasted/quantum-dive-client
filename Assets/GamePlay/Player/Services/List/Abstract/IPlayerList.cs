﻿using GamePlay.Player.Entity.Common.Definition;
using Ragon.Client;

namespace GamePlay.Player.Services.List.Abstract
{
    public interface IPlayerList
    {
        void Add(RagonPlayer player, IPlayerEntity root);
        IPlayerEntity Get(RagonPlayer player);
    }
}