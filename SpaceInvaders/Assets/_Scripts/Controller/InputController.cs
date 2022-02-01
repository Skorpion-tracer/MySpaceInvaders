using Model;
using UnityEngine;

namespace Controller
{
    public class InputController
    {
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        private ShipController _shipController;
        public InputController(ShipController shipController)
        {
            _shipController = shipController;
        }

        public void Execute()
        {
            bool isInput = Input.GetAxis(HORIZONTAL) != 0 || Input.GetAxis(VERTICAL) != 0;
            var horizontal = Input.GetAxis(HORIZONTAL);
            var vertical = Input.GetAxis(VERTICAL);
            _shipController.Move(isInput, horizontal, vertical);
        }
    }
}
