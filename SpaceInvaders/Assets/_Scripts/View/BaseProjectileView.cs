using System;
using UnityEngine;

namespace View
{
    public abstract class BaseProjectileView : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D _body;
        [SerializeField] protected float _lifeTime;

        private event Func<EnemyView, BaseProjectileView> _onCollision;
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
                _onCollision?.Invoke(enemy);
                Destroy(gameObject);
            }
        }

        public void Subscribe(Func<EnemyView, BaseProjectileView> method)
        {
            _method = method;
            _onCollision += _method;
        }

        private void OnDestroy()
        {
            _onCollision -= _method;
        }
    }
}
