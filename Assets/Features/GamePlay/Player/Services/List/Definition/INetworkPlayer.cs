﻿using GamePlay.Player.Entity.Setup.Root.Common;
using Ragon.Client;

namespace GamePlay.Player.List.Definition
{
    public interface INetworkPlayer
    {
        RagonEntity Entity { get; }
        IPlayerRoot Root { get; }
    }
}