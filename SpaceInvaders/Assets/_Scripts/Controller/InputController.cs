using Model;
using UnityEngine;

namespace Controller
{
    public class InputController
    {
        private ShipController _shipController;
        public InputController(ShipController shipController)
        {
            _shipController = shipController;
        }

        public void Execute()
        {
            if (Input.anyKey)
            {
                var direction = Input.GetAxis("Horizontal");
                _shipController.Move(direction);
            }            
        }
    }
}
