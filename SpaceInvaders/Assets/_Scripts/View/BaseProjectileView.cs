

using System;
using UnityEngine;

namespace View
{
    public abstract class BaseProjectileView : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D _body;
        [SerializeField] protected float _lifeTime;

        public event Func<EnemyView, BaseProjectileView> OnCollision;

        private Func<EnemyView, BaseProjectileView> _method;

        public Rigidbody2D Body => _body;

        protected virtual void Start()
        {
            Destroy(gameObject, _lifeTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<EnemyView>(out EnemyView enemy))
            {
                OnCollision?.Invoke(enemy);
            }
        }

        public void Subscribe(Func<EnemyView, BaseProjectileView> method)
        {
            _method = method;
            OnCollision += _method;
        }

        private void OnDestroy()
        {
            OnCollision -= _method;
        }
    }
}
