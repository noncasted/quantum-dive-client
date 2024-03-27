using Ragon.Client;
using UnityEngine;

namespace GamePlay.Services.Network.Objects.Definition
{
    public interface INetworkObject
    {
        RagonEntity Entity { get; }
        GameObject Object { get; }
    }
}