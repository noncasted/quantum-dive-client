using System;
using Ragon.Client;

namespace GamePlay.Services.System.Network.Room.Lifecycle.Abstract
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