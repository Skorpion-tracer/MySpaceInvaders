using UnityEngine;
using View;

namespace Model
{
    public sealed class Rifle : BaseWeapon
    {
        private float _fireRate = 15f;
        private float _nextTimeToFire = 0f;
        private int _valueDamage = 5;

        public Rifle(Transform spawnProjectile)
        {
            _projectile = Resources.Load<ProjectileViewRifle>("Prefabs/ProjectileRifle");
            _spawnProjectile = spawnProjectile;
            _damage = new Damage(_valueDamage);
        }        

        public Rifle()
        {
            _projectile = Resources.Load<ProjectileViewRifle>("Prefabs/ProjectileRifle");
            _spawnProjectile = GameObject.FindObjectOfType<ShipView>().SpawnerProjectile;
            _damage = new Damage(_valueDamage);
        }

        ~Rifle()
        {
            _projectile.OnCollision -= _projectile_OnCollision;
        }

        public override void Attack()
        {
            if (Time.time >= _nextTimeToFire)
            {
                _nextTimeToFire = Time.time + 1f / _fireRate;

                var projectile = Object.Instantiate(_projectile, _spawnProjectile.position, Quaternion.identity);
                projectile.Body.AddForce(projectile.transform.up * _speed, ForceMode2D.Force);
                projectile.Subscribe(_projectile_OnCollision);
            }
        }

        public override void StopAttack()
        {
            return;
        }

        private BaseProjectileView _projectile_OnCollision(EnemyView arg)
        {
            Object.Destroy(arg.gameObject);
            return null;
        }
    }
}
