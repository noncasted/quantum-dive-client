using Cysharp.Threading.Tasks;
using Global.Network.Connection.Abstract;
using Global.Network.Connection.Common;
using Global.Network.Connection.Configuration;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Network.Connection.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ConnectionRoutes.ServiceName, menuName = ConnectionRoutes.ServicePath)]
    public class ConnectionFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var options = utils.Options.GetOptions<RagonConnectionOptions>();

            services.RegisterInstance(options)
                .As<IRagonConnectionOptions>();

            services.Register<Connection>()
                .As<IConnection>();
        }
    }
}