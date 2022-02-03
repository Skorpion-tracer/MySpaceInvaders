using Controller;
using Model;
using UnityEngine;
using View;

namespace SpaceInvaders
{
    public sealed class Root : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPlayer;
        [SerializeField] private DataShip _dataShip;

        private ShipController _shipController;
        private InputController _inputController;

        private void Awake()
        {
            var player = Resources.Load<ShipView>("Prefabs/Ship");
            player = Instantiate(player, _spawnPlayer.position, Quaternion.identity);

            _shipController = new ShipController(_dataShip, player);
            _inputController = new InputController(_shipController);
        }

        private void FixedUpdate()
        {
            _inputController.FixedExecute();
        }

        private void Update()
        {
            _shipController.BoundMove();
            _inputController.Execute();
        }
    } 
}
