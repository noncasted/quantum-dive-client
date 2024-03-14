using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Cysharp.Threading.Tasks;
using Global.Debugs.Drawing.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Debugs.Drawing.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DrawingRoutes.ServiceName,
        menuName = DrawingRoutes.ServicePath)]
    public class DrawingFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<ShapeDrawer>()
                .As<IShapeDrawer>();
        }
    }
}