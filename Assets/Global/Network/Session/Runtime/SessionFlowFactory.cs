using Cysharp.Threading.Tasks;
using Global.Network.Session.Abstract;
using Global.Network.Session.Common;
using Global.Network.Session.Runtime.Create;
using Global.Network.Session.Runtime.Join;
using Global.Network.Session.Runtime.Leave;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Network.Session.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SessionRoutes.ServiceName,
        menuName = SessionRoutes.ServicePath)]
    public class SessionFlowFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<SessionCreate>()
                .As<ISessionCreate>();

            services.Register<SessionJoin>()
                .As<ISessionJoin>();

            services.Register<SessionLeave>()
                .As<ISessionLeave>();
        }
    }
}