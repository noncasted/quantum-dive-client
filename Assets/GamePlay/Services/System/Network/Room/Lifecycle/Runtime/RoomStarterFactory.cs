using Internal.Scopes.Abstract.Containers;

using Cysharp.Threading.Tasks;
using GamePlay.System.Network.Room.Lifecycle.Common;
using Internal.Scopes.Abstract.Instances.Services;
using UnityEngine;

namespace GamePlay.System.Network.Room.Lifecycle.Runtime
{
    [CreateAssetMenu(fileName = RoomStarterRoutes.ServiceName,
        menuName = RoomStarterRoutes.ServicePath)]
    public class RoomStarterFactory : RoomStarterBaseFactory
    {
        public override async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<RoomLifecycle>()
                .AsCallbackListener()
                .As<IRoomLifecycle>()
                .As<IRoomProvider>();
        }
    }
}