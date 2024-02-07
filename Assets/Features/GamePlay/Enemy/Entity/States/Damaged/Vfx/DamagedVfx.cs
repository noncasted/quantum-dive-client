using UnityEngine;

namespace GamePlay.Enemies.Entity.States.Damaged.Vfx
{
    [DisallowMultipleComponent]
    public class DamagedVfx : MonoBehaviour, IDamagedVfx
    {
        private Transform _parent;
        private ParticleSystem _particles;

        private void Awake()
        {
            _parent = transform.parent;
            _particles = GetComponent<ParticleSystem>();
            
            transform.parent = null;
        }

        public void Play(float angle)
        {
            transform.position = _parent.position;
            transform.rotation = Quaternion.Euler(angle, -90f, 0f);
            _particles.Play();
        }
    }
}