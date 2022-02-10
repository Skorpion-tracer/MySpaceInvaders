using System;

namespace Model
{
    public sealed class Health
    {
        private int _currentHealth;
        private int _maxHealth;

        public event Action OnDeath;

        public Health(int currentHealth, int maxHealth)
        {
            _currentHealth = currentHealth;
            _maxHealth = maxHealth;
            CheckHealth();
        }

        private void CheckHealth()
        {
            if (_maxHealth <= 0)
            {
                _maxHealth = 10;
            }

            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }

            if (_currentHealth <= 0)
            {
                _currentHealth = 10;
            }
        }

        public void DealDamage(int hp)
        {
            _currentHealth -= hp;
            if (_currentHealth <= 0) OnDeath?.Invoke();
        }

        public int GetCurrentHealth()
        {
            return _currentHealth;
        }
    }
}
