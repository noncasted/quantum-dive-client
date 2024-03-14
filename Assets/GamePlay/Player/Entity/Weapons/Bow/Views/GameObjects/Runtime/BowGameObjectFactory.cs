using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime
{
    [DisallowMultipleComponent]
    public class BowGameObjectFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private GameObject _gameObject;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<BowGameObject>()
                .As<IBowGameObject>()
                .WithParameter(_gameObject);
        }
    }
}