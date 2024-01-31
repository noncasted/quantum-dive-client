using UnityEngine;

namespace GamePlay.Player.Provider.Runtime
{
    public interface IPlayerPositionProvider
    {
        Vector2 Position { get; }
    }
}