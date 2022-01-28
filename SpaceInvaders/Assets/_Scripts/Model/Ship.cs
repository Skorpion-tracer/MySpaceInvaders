using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public sealed class Ship
    {
        private float _speed;

        public float Speed => _speed;

        public Ship(float speed)
        {
            _speed = speed;
        }
    } 
}
