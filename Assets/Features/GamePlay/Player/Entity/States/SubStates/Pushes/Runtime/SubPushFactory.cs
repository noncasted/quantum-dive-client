using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.States.SubStates.Pushes.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Pushes.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SubPushRoutes.StateName, menuName = SubPushRoutes.StatePath)]
    public class SubPushFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<SubPush>()
                .As<ISubPush>();
        }
    }
}