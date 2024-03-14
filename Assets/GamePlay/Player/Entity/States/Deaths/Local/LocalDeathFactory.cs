using GamePlay.Player.Entity.States.Deaths.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
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

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<LocalDeath>()
                .WithParameter(_definition)
                .As<IDeath>();
        }
    }
}