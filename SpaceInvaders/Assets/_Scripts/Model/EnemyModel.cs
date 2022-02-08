using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EnemyModel
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
            _damage = new Damage(15);
        }
    }
}
