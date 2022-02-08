using Behavior;
using UnityEngine;
using View;

namespace Model
{
    public abstract class BaseWeapon : IAttack
    {
        protected float _speed = 200.0f;
        protected BaseProjectileView _projectile;
        protected Transform _spawnProjectile;
        protected Damage _damage = new Damage();

        public abstract void Attack();
        public abstract void StopAttack();
        protected BaseProjectileView Projectile_OnCollision(EnemyView enemy)
        {
            enemy.OnHitInvoke(_damage);
            return null;
        }
    }
}
