using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.Rotations.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Rotations.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RotationRoutes.RemoteName,
        menuName = RotationRoutes.RemotePath)]
    public class RemoteBowRotationFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private RotationConfigAsset _config;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<RemoteBowRotation>()
                .WithParameter(_config)
                .AsCallbackListener();
        }
    }
}