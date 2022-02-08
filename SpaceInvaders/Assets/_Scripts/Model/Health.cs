using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Health
    {
        private int _currentHealth;
        private int _maxHealth;

        public int CurrentHealth => _currentHealth;
        public int MaxHealth { get => _maxHealth; }

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
    }
}
