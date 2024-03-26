using System;
using GamePlay.Projectiles.Entity.Views.Actions;
using GamePlay.Projectiles.Entity.Views.Transforms;
using UnityEngine;

namespace GamePlay.Projectiles.Entity.Views.Facade
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ProjectileTransform))]
    public class ProjectileView :
        MonoBehaviour,
        //IPoolObject,
        IProjectileView
    {
        private IProjectileTransform _transform;
        private IProjectileActions _actions;

       // private Action<IPoolObject> _returnToPool;

        public IProjectileTransform Transform => _transform;
        public IProjectileActions Actions => _actions;
        public GameObject GameObject => gameObject;

        private void Awake()
        {
            _transform = GetComponent<IProjectileTransform>();
            _actions = GetComponent<IProjectileActions>();
        }

        // public void Construct(Action<IPoolObject> returnToPool)
        // {
        //     _returnToPool = returnToPool;
        //
        //     _actions.Construct(ReturnToPool);
        // }
        
        public void OnTaken()
        {
        }

        public void OnReturned()
        {
        }

        // private void ReturnToPool()
        // {
        //     _returnToPool?.Invoke(this);
        // }
    }
}