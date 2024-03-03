using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.States.Deaths.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Deaths.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DeathRoutes.StateName,
        menuName = DeathRoutes.StatePath)]
    public class LocalDeathFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private DeathDefinition _definition;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<LocalDeath>()
                .WithParameter(_definition)
                .As<IDeath>();
        }
    }
}