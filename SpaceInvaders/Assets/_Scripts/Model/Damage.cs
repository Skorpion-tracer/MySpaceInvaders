namespace Model
{
    public sealed class Damage
    {
        private int _valueDamage;

        public int ValueDamage => _valueDamage;

        public Damage(int damage)
        {
            _valueDamage = damage;
        }

        public Damage()
        {
            _valueDamage = 1;
        }
    }
}
