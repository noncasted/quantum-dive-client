using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemy.Entity.States.SubStates.Pushes.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.SubStates.Pushes.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemySubPushRoutes.StateName, menuName = EnemySubPushRoutes.StatePath)]
    public class SubPushFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<SubPush>()
                .As<ISubPush>();
        }
    }
}