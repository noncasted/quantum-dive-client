using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
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

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<RemoteDamaged>()
                .WithParameter<IDamagedConfig>(_config)
                .AsCallbackListener();
        }
    }
}