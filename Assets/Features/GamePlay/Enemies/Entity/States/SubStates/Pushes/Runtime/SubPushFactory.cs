using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.States.SubStates.Pushes.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.States.SubStates.Pushes.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemySubPushRoutes.StateName, menuName = EnemySubPushRoutes.StatePath)]
    public class SubPushFactory : ScriptableObject, IEnemyComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegistry callbacks)
        {
            services.Register<SubPush>()
                .As<ISubPush>();
        }
    }
}