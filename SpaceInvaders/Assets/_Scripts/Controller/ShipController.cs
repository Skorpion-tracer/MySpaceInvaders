using Behavior;
using Model;
using UnityEngine;
using View;

namespace Controller
{
    public sealed class ShipController : IMove
    {
        private DataShip _ship;
        private ShipView _shipView;
        private IAttack _attack;

        public ShipController(DataShip ship, ShipView shipView)
        {
            _ship = ship;
            _shipView = shipView;
            _attack = new Weapon(ship.Weapon, shipView.SpawnerProjectile);
        }

        public void Move(bool isInput, float horizontal, float vertical)
        {
            if (isInput == true)
            {
                Vector2 direction;

                direction.x = horizontal * _ship.Speed;
                direction.y = vertical * _ship.Speed;

                _shipView.ShipBody.velocity += direction;
                _shipView.ShipBody.velocity = Vector2.Lerp(_shipView.ShipBody.velocity, Vector2.zero, _ship.OffsetMove);
            }
            else
            {
                _shipView.ShipBody.velocity = Vector2.Lerp(_shipView.ShipBody.velocity, Vector2.zero, _ship.OffsetMove);
            }            
        }

        public void BoundMove()
        {
            _shipView.transform.position = new Vector3(Mathf.Clamp(_shipView.transform.position.x, -_ship.OffsetLeftBound, _ship.OffsetLeftBound),
                Mathf.Clamp(_shipView.transform.position.y, -_ship.OffsetBottomBound, _ship.OffsetTopBound), _shipView.transform.position.z);
        }

        public void Fire()
        {
            _attack.Attack();
        }
    }
}           
