using System;
using Global.Network.Objects.Factories.Abstract;
using Ragon.Client;

namespace Global.Network.Objects.EntityListeners.Abstract
{
    public interface IEntityListener : IRagonEntityListener
    {
        event Action<EntityPrefabId, RagonEntity> EntityReceived;
    }
}