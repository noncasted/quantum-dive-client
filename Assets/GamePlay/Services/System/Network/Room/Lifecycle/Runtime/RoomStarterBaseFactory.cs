using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.Network.Room.Lifecycle.Runtime
{
    [InlineEditor]
    public abstract class RoomStarterBaseFactory : ScriptableObject, IServiceFactory
    {
        public abstract UniTask Create(IServiceCollection services, IServiceScopeUtils utils);
    }
}