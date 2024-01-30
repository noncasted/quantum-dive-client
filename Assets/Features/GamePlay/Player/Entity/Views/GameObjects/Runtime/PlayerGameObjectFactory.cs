using System;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.GameObjects.Runtime
{
    [DisallowMultipleComponent]
    public class PlayerGameObjectFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private GameObject _gameObject;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<PlayerGameObject>()
                .As<IPlayerGameObject>()
                .WithParameter(_gameObject);
        }
    }
}