namespace GamePlay.Projectiles.Entity.Components
{
    public struct ProjectileDamageComponent
    {
        public void Construct(int damage, float pushForce)
        {
            _damage = damage;
            _pushForce = pushForce;
        }

        private int _damage;
        private float _pushForce;

        public int Damage => _damage;
        public float PushForce => _pushForce;
    }
}