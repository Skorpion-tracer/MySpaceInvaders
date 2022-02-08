using UnityEngine;

namespace View
{
    public sealed class EnemyView : MonoBehaviour, IEnemyView
    {
        [SerializeField] private float _lifeTime;

        private void Start()
        {
            Destroy(gameObject, _lifeTime);
        }
    }
}
