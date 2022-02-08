using UnityEngine;
using View;

namespace Model
{
    [CreateAssetMenu(menuName = "Rules/RulesSpawnEnemy", fileName = nameof(RulesSpawnEnemy))]
    public class RulesSpawnEnemy : ScriptableObject
    {
        [SerializeField] private float _countEnemies;
        [SerializeField] private float _frequencySpawn;
        [SerializeField] private EnemyView _enemy;

        public float CountEnemies => _countEnemies;
        public float FrequencySpawn => _frequencySpawn;
        public EnemyView Enemy => _enemy;
    }
}
