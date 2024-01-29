using UnityEngine;

namespace GamePlay.Player.Services.Provider.Runtime
{
    public interface IPlayerPositionProvider
    {
        Vector2 Position { get; }
    }
}