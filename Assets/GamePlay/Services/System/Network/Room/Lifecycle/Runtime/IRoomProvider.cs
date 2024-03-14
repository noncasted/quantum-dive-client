using System;
using Ragon.Client;

namespace GamePlay.Network.Room.Lifecycle.Runtime
{
    public interface IRoomProvider
    {
        bool IsOwner { get; }
        RagonPlayer LocalPlayer { get; }
        RagonRoom Room { get; }
        string Id { get; }

        event Action BecameOwner;
    }
}