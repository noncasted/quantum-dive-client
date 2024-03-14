using GamePlay.Enemy.Entity.States.SubStates.Pushes.Abstract;
using GamePlay.Enemy.Entity.States.SubStates.Pushes.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.SubStates.Pushes.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemySubPushRoutes.StateName, menuName = EnemySubPushRoutes.StatePath)]
    public class SubPushFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<SubPush>()
                .As<ISubPush>();
        }
    }
}