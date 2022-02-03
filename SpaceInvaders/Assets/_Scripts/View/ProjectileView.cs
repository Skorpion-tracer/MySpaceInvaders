using UnityEngine;

namespace View
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ProjectileView : MonoBehaviour, IProjectileView
    {
        [SerializeField] private Rigidbody2D _body;
        [SerializeField] private float _lifeTime;

        public Rigidbody2D Body => _body;

        private void Start()
        {
            Destroy(gameObject, _lifeTime);
        }
    }
}
