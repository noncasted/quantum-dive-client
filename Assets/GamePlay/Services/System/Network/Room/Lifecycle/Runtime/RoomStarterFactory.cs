using Cysharp.Threading.Tasks;
using GamePlay.Services.Network.Room.Lifecycle.Common;
using GamePlay.Services.System.Network.Room.Lifecycle.Abstract;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using UnityEngine;

namespace GamePlay.Services.Network.Room.Lifecycle.Runtime
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