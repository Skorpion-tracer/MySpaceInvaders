using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public sealed class Ship
    {
        private float _speed;
        private float _offsetMove;

        public float Speed => _speed;
        public float OffsetMove => _offsetMove;

        public DataShip DataShip { get; set; }

        public Ship(float speed, float offsetMove, DataShip dataShip)
        {
            _speed = speed;
            _offsetMove = offsetMove;
            DataShip = dataShip;
        }
    } 
}
