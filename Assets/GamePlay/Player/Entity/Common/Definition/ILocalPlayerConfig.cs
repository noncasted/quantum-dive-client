﻿namespace GamePlay.Player.Entity.Common.Definition
{
    public interface ILocalPlayerConfig : IPlayerConfig
    {
        PlayerViewFactory Prefab { get; }
    }
}