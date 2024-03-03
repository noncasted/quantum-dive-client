using System;
using Common.Tools.ObjectsPools.Runtime.Abstract;
using GamePlay.Combat.Projectiles.Entity.Views.Actions;
using GamePlay.Combat.Projectiles.Entity.Views.Sprite;
using GamePlay.Combat.Projectiles.Entity.Views.Transforms;
using UnityEngine;

namespace GamePlay.Combat.Projectiles.Entity.Views.Facade
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ProjectileTransform))]
    public class ProjectileView :
        MonoBehaviour,
        IPoolObject,
        IProjectileView
    {
        private IProjectileTransform _transform;
        private IProjectileActions _actions;
        private IProjectileSprite _sprite;

        private Action<IPoolObject> _returnToPool;

        public IProjectileTransform Transform => _transform;
        public IProjectileActions Actions => _actions;
        public IProjectileSprite Sprite => _sprite;
        public GameObject GameObject => gameObject;

        private void Awake()
        {
            _transform = GetComponent<IProjectileTransform>();
            _actions = GetComponent<IProjectileActions>();
            _sprite = GetComponent<IProjectileSprite>();
        }

        public void Construct(Action<IPoolObject> returnToPool)
        {
            _returnToPool = returnToPool;

            _actions.Construct(ReturnToPool);
        }

        public void OnTaken()
        {
        }

        public void OnReturned()
        {
        }

        private void ReturnToPool()
        {
            _returnToPool?.Invoke(this);
        }
    }
}