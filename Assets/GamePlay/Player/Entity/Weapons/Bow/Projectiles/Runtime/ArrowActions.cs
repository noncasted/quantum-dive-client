using System;
using GamePlay.Services.Projectiles.Entity.Views.Actions;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Projectiles.Runtime
{
    [DisallowMultipleComponent]
    public class ArrowActions : MonoBehaviour, IProjectileActions
    {
        [SerializeField] private ParticleSystem[] _sprays;
        [SerializeField] private ParticleSystem _start;
        [SerializeField] private ParticleSystem _collision;
        [SerializeField] private ParticleSystem _hit;
        [SerializeField] private Transform _root;
        [SerializeField] private Transform _vfx;

        private Action _returnToPool;

        public bool RequiresCollisionNormal => true;

        public void Construct(Action returnToPool)
        {
            _returnToPool = returnToPool;
        }

        public void OnTaken()
        {
            AttachVfx();
            EnableSpray();
            _start.Play();
        }

        public void OnCollision()
        {
            DropVfx();
            DisableSpray();
            _collision.Play();

            _returnToPool?.Invoke();
        }

        public void OnCollision(Vector3 targetNormal)
        {
        }

        public void OnCollision(Vector2 targetNormal)
        {
            DropVfx();
            DisableSpray();

            var collisionTransform = _collision.transform;
            var fromRotation = Quaternion.FromToRotation(collisionTransform.forward, targetNormal);
            collisionTransform.rotation = fromRotation * collisionTransform.rotation;

            _collision.Play();

            _returnToPool?.Invoke();
        }

        public void OnHit()
        {
            DropVfx();
            DisableSpray();

            if (_hit != null)
                _hit.Play();

            _returnToPool?.Invoke();
        }

        public void OnDestroyed()
        {
            DropVfx();
            DisableSpray();
            _collision.Play();

            _returnToPool?.Invoke();
        }

        private void DropVfx()
        {
            _vfx.parent = null;
        }

        private void AttachVfx()
        {
            _vfx.parent = _root;
            _vfx.localPosition = Vector3.zero;
            _vfx.localRotation = Quaternion.Euler(0f, 0f, 0f);

            foreach (var spray in _sprays)
                spray.Stop();

            _collision.Stop();
            _start.Stop();
        }

        private void EnableSpray()
        {
            foreach (var spray in _sprays)
            {
                var mainModule = spray.main;
                mainModule.loop = true;

                spray.Play();
            }
        }

        private void DisableSpray()
        {
            foreach (var spray in _sprays)
            {
                var mainModule = spray.main;
                mainModule.loop = false;
            }
        }
    }
}