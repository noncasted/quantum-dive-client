using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.States.SubStates.Pushes.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Pushes.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SubPushRoutes.StateName, menuName = SubPushRoutes.StatePath)]
    public class SubPushFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<SubPush>()
                .As<ISubPush>();
        }
    }
}