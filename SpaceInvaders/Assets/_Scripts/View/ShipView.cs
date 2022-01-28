using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace View
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class ShipView : MonoBehaviour
    {
        [SerializeField] public Rigidbody2D _bodyShip;

        public void SetMove(float direction, float speed)
        {
            Vector2 dirX = new Vector2(direction * speed, 0);
            _bodyShip.AddForce(dirX, ForceMode2D.Force);

            Debug.Log($"SetMove {_bodyShip.mass}");
        }

        private void Update()
        {
            Debug.Log($"Update {_bodyShip.mass}");
        }
    } 
}
