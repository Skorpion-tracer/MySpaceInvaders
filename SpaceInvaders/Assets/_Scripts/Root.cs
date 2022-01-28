using Controller;
using Model;
using UnityEngine;
using View;

namespace SpaceInvaders
{
    public sealed class Root : MonoBehaviour
    {
        [SerializeField] private float _speedShipPlayer;

        [SerializeField] private Transform _spawnShip;

        [SerializeField] private ShipView _player;

        private ShipController _shipController;
        private InputController _inputController;

        private void Start()
        {
            var ship = new Ship(_speedShipPlayer);
            _shipController = new ShipController(ship, _player);
            _inputController = new InputController(_shipController);

            GameObject.Instantiate(_player, _spawnShip.position, Quaternion.identity);
        }

        private void Update()
        {
            //_inputController.Execute();
            _player.SetMove(14, 14);
        }
    } 
}
