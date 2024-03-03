namespace GamePlay.Combat.Projectiles.Entity.Components
{
    public struct ProjectileColliderComponent
    {
        public void Construct(float radius)
        {
            _radius = radius;
        }

        private float _radius;

        public float Radius => _radius;
    }
}