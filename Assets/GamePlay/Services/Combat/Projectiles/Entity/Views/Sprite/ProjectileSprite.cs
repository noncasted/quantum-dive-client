    using UnityEngine;

    namespace GamePlay.Combat.Projectiles.Entity.Views.Sprite
    {
        public class ProjectileSprite : MonoBehaviour, IProjectileSprite
        {
            [SerializeField] private SpriteRenderer _sprite;
            [SerializeField] private ParticleSystem[] _particles;

            private Renderer[] _renderers;

            private void Awake()
            {
                _renderers = new Renderer[_particles.Length];

                for (var i = 0; i < _renderers.Length; i++)
                    _renderers[i] = _particles[i].GetComponent<Renderer>();
            }

            public void SetLayer(string layer)
            {
                _sprite.sortingLayerName = layer;

                foreach (var particleRenderer in _renderers)
                    particleRenderer.sortingLayerName = layer;
            }
        }
    }
