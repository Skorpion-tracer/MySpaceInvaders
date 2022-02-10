using Model;
using UnityEngine;

namespace Controller
{
    public sealed class InputController
    {
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        private const KeyCode FIRE = KeyCode.Space;

        private ShipController _shipController;

        public InputController(ShipController shipController)
        {
            _shipController = shipController;
        }

        public void FixedExecute()
        {
            bool isInput = Input.GetAxis(HORIZONTAL) != 0 || Input.GetAxis(VERTICAL) != 0;
            var horizontal = Input.GetAxis(HORIZONTAL);
            var vertical = Input.GetAxis(VERTICAL);
            _shipController.Move(isInput, horizontal, vertical);
        }

        public void Execute()
        {
            if (Input.GetKey(FIRE))
            {
                _shipController.Fire();
            }
            if (Input.GetKeyUp(FIRE))
            {
                _shipController.StopFire();
            }
        }
    }
}
