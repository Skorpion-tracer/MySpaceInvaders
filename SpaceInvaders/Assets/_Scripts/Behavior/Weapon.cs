using Behavior;
using UnityEngine;
using View;

namespace Model
{
    public class Weapon : IAttack
    {
        private float _speed = 100.0f;
        private ProjectileView _projectile;
        private Transform _spawnProjectile;

        public Weapon(ProjectileView projectile, Transform spawnProjectile)
        {
            _projectile = projectile;
            _spawnProjectile = spawnProjectile;
        }

        public void Attack()
        {
            var projectile = Object.Instantiate(_projectile, _spawnProjectile.position, Quaternion.identity);
            projectile.Body.AddForce(projectile.transform.up * _speed, ForceMode2D.Force);
        }
    }
}
