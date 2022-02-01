using Controller;
using Model;
using UnityEngine;
using View;

namespace SpaceInvaders
{
    public sealed class Root : MonoBehaviour
    {
        [SerializeField] private float _speedShipPlayer;
        [SerializeField] private float _offsetMoveShipPlayer;

        [SerializeField] private Transform _spawnPlayer;
        [SerializeField] private DataShip _dataShip;

        private ShipController _shipController;
        private InputController _inputController;

        private void Awake()
        {
            var player = Resources.Load<ShipView>("Prefabs/Ship");
            player = Instantiate(player, _spawnPlayer.position, Quaternion.identity);

            var ship = new Ship(_speedShipPlayer, _offsetMoveShipPlayer, _dataShip);
            _shipController = new ShipController(ship, player);
            _inputController = new InputController(_shipController);
        }

        private void FixedUpdate()
        {
            _inputController.Execute();
        }

        private void Update()
        {
            _shipController.BoundMove();
        }
    } 
}
