using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.Rotations.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Rotations.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RotationRoutes.LocalName,
        menuName = RotationRoutes.LocalPath)]
    public class RotationFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private RotationConfigAsset _config;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<BowRotation>()
                .As<IBowRotation>()
                .WithParameter(_config)
                .AsCallbackListener();
        }
    }
}