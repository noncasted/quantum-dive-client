using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Components.DamageProcessors.Common;
using GamePlay.Enemies.Entity.Setup.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Components.DamageProcessors.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyDamageProcessorRoutes.ComponentName,
        menuName = EnemyDamageProcessorRoutes.ComponentPath)]
    public class DamageProcessorFactory : ScriptableObject, IEnemyComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<DamageProcessor>()
                .AsCallbackListener();
        }
    }
}