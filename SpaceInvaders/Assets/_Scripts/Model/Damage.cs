using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Damage
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
