using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View;

namespace Controller
{
    public sealed class ShipController : IMove
    {
        private Ship _ship;
        private ShipView _shipView;

        public ShipController(Ship ship, ShipView shipView)
        {
            _ship = ship;
            _shipView = shipView;
        }

        public void Move(float direction)
        {
            _shipView.SetMove(direction, _ship.Speed);
        }
    } 
}
