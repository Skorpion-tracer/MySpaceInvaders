using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace View
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class ShipView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _bodyShip;
        [SerializeField] private Transform _spawnerProjectile;

        public Rigidbody2D ShipBody => _bodyShip;
        public Transform SpawnerProjectile => _spawnerProjectile;
    } 
}
