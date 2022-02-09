using Model;
using System;
using UnityEngine;

namespace View
{
    public sealed class EnemyView : MonoBehaviour, IEnemyView
    {
        [SerializeField] private float _lifeTime;

        public event Action<Damage> OnHit;
        public event Action<Collision2D> OnCollision;
        private void Start()
        {
            Destroy(gameObject, _lifeTime);
        }

        public void OnHitInvoke(Damage damage)
        {
            OnHit?.Invoke(damage);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollision?.Invoke(collision);
        }
    }
}
