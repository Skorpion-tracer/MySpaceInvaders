using Controller;
using Model;
using UnityEngine;
using View;

namespace SpaceInvaders
{
    public sealed class Root : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPlayer;
        [SerializeField] private Transform _spawnEnemies;
        [SerializeField] private DataShip _dataShip;
        [SerializeField] private RulesSpawnEnemy _rulesSpawnEnemy;

        private ShipController _shipController;
        private InputController _inputController;
        private SpawnEnemyController _spawnEnemyController;

        private void Awake()
        {
            var player = Resources.Load<ShipView>("Prefabs/Ship");
            player = Instantiate(player, _spawnPlayer.position, Quaternion.identity);

            _shipController = new ShipController(_dataShip, player);
            _inputController = new InputController(_shipController);
            _spawnEnemyController = new SpawnEnemyController(_spawnEnemies, _rulesSpawnEnemy);
        }

        private void FixedUpdate()
        {
            _inputController.FixedExecute();
        }

        private void Update()
        {
            _shipController.BoundMove();
            _inputController.Execute();
            _spawnEnemyController.Execute();
        }
    } 
}
