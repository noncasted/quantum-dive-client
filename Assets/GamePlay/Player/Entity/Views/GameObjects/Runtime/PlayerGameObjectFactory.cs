using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.GameObjects.Runtime
{
    [DisallowMultipleComponent]
    public class PlayerGameObjectFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private GameObject _gameObject;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<PlayerGameObject>()
                .As<IPlayerGameObject>()
                .WithParameter(_gameObject);
        }
    }
}