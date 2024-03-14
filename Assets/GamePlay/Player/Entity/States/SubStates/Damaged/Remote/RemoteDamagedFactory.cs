using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Player.Entity.States.SubStates.Damaged.Common;
using GamePlay.Player.Entity.States.SubStates.Damaged.Local;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Damaged.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DamagedRoutes.RemoteName,
        menuName = DamagedRoutes.RemotePath)]
    public class RemoteDamagedFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private DamagedConfig _config;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<RemoteDamaged>()
                .WithParameter<IDamagedConfig>(_config)
                .AsCallbackListener();
        }
    }
}