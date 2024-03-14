using Cysharp.Threading.Tasks;
using Global.Inputs.Constranits.Abstract;
using Global.Inputs.Constranits.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Inputs.Constranits.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = InputConstraintsRoutes.ServiceName, menuName = InputConstraintsRoutes.ServicePath)]
    public class InputConstraintsFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<InputConstraintsStorage>()
                .As<IInputConstraintsStorage>()
                .AsCallbackListener();
        }
    }
}