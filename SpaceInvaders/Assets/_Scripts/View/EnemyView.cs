using Model;
using System;
using UnityEngine;

namespace View
{
    public sealed class EnemyView : MonoBehaviour, IEnemyView
    {
        [SerializeField] private float _lifeTime;

        public event Action<Damage> OnHit;

        private void Start()
        {
            Destroy(gameObject, _lifeTime);
        }

        public void OnHitInvoke(Damage damage)
        {
            OnHit?.Invoke(damage);
        }
    }
}
