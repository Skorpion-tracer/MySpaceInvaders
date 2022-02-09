using UnityEngine;
using View;

namespace Model
{
    public sealed class SingleShoot : BaseWeapon
    {
        private bool _canShoot = true;
        private int _valueDamage = 20;

        public SingleShoot(Transform spawnProjectile)
        {
            _speed = 300f;
            _projectile = Resources.Load<ProjectileViewSingleShoot>("Prefabs/ProjectileSingleShoot");
            _spawnProjectile = spawnProjectile;
            _damage = new Damage(_valueDamage);
        }

        public SingleShoot()
        {
            _speed = 300f;
            _projectile = Resources.Load<ProjectileViewSingleShoot>("Prefabs/ProjectileSingleShoot");
            _spawnProjectile = GameObject.FindObjectOfType<ShipView>().SpawnerProjectile;
            _damage = new Damage(_valueDamage);
        }

        public override void Attack()
        {
            if (_canShoot == true)
            {
                var projectile = Object.Instantiate(_projectile, _spawnProjectile.position, Quaternion.identity);
                projectile.Body.AddForce(projectile.transform.up * _speed, ForceMode2D.Force);
                projectile.Subscribe(Projectile_OnCollision);
                _canShoot = false;
            }
        }

        public override void StopAttack()
        {
            _canShoot = true;
        }
    }
}
