namespace Model
{
    public sealed class EnemyModel
    {
        private float _speed = 3f;
        private Health _health;
        private Damage _damage;
        public Health Health => _health;
        public Damage Damage => _damage;
        public float Speed => _speed;

        public EnemyModel(Health health)
        {
            _health = health;
            _damage = new Damage(10);
        }
    }
}
