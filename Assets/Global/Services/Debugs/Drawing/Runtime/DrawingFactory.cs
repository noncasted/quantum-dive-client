using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
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
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<ShapeDrawer>()
                .As<IShapeDrawer>();
        }
    }
}