using Model;
using System;
using UnityEngine;
using View;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Controller
{
    public class EnemyController
    {
        private EnemyModel _enemyModel;
        private EnemyView _enemyView;

        public event Action OnEnemyDead;

        public void Spawn(Transform spawnPosition, EnemyView view)
        {
            _enemyModel = new EnemyModel(new Health(30, 30));
            _enemyModel.Health.OnDeath += Health_OnDeath;

            Vector3 position = new Vector3(Random.Range(-8, 8), spawnPosition.position.y, spawnPosition.position.z);

            _enemyView = Object.Instantiate(view, position, Quaternion.identity);
            _enemyView.OnHit += EnemyView_OnHit;
            _enemyView.OnCollision += EnemyView_OnCollision;
        }

        private void EnemyView_OnCollision(Collision2D collider)
        {
            if (collider.gameObject.TryGetComponent<ShipView>(out ShipView player))
            {
                player.DealDamage(_enemyModel.Damage);
                Object.Destroy(_enemyView.gameObject);
            }
        }

        private void Health_OnDeath()
        {
            int chanceGettingBonus = Random.Range(0, 3);

            if (chanceGettingBonus == 2)
            {
                var bonus = Resources.Load<BonusView>("Prefabs/Bonus");
                bonus = Object.Instantiate(bonus, _enemyView.transform.position, Quaternion.identity);
            }

            Object.Destroy(_enemyView.gameObject);
            _enemyModel.Health.OnDeath -= Health_OnDeath;
            _enemyView.OnHit -= EnemyView_OnHit;
            OnEnemyDead?.Invoke();
        }

        private void EnemyView_OnHit(Damage damage)
        {
            _enemyModel.Health.DealDamage(damage.ValueDamage);
        }

        public void Execute()
        {
            if (_enemyModel != null && _enemyView != null)
            {
                _enemyView.transform.Translate(Vector2.down * _enemyModel.Speed * Time.deltaTime);
            }
        }

        public void Destroy()
        {
            if (_enemyView != null)
                Object.Destroy(_enemyView.gameObject);
        }
    }
}
