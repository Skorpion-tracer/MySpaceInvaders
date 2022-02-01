using Model;
using UnityEngine;
using View;

namespace Controller
{
    public sealed class ShipController : IMove
    {
        private Ship _ship;
        private ShipView _shipView;

        private Vector2 _screenBounds;
        private float _objectWidth;
        private float _objectHeight;

        public ShipController(Ship ship, ShipView shipView)
        {
            _ship = ship;
            _shipView = shipView;

            _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            _objectWidth = shipView.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
            _objectHeight = shipView.transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
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
            _shipView.transform.position = new Vector3(Mathf.Clamp(_shipView.transform.position.x, -_ship.DataShip.OffsetLeftBound, _ship.DataShip.OffsetLeftBound),
                Mathf.Clamp(_shipView.transform.position.y, -_ship.DataShip.OffsetBottomBound, _ship.DataShip.OffsetTopBound), _shipView.transform.position.z);
        }
    }
}           
