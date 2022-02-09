using UnityEngine;

namespace View
{
    [RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(SpriteRenderer))]
    public class BonusView : MonoBehaviour
    {
        private Color _cyan = Color.cyan;
        private Color _darkPink = Color.magenta;

        private BonusType _bonusType;
        private float _speed = 150f;
        private float _lifeTime = 7f;

        [SerializeField] private Rigidbody2D _body;
        [SerializeField] private SpriteRenderer _sprite;

        private void Start()
        {
            _body.AddForce(Vector2.down * _speed, ForceMode2D.Force);

            _bonusType = (BonusType)Random.Range(0, 2);

            if (_bonusType == BonusType.WeaponRifle)
            {
                _sprite.color = _darkPink;
            }
            else
            {
                _sprite.color = _cyan;
            }

            Destroy(gameObject, _lifeTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<ShipView>(out ShipView player))
            {
                player.GetBonus(_bonusType);
                Debug.Log(player);
                Destroy(gameObject);
            }
        }
    }

    public enum BonusType : byte
    {
        WeaponRifle = 0,
        SingleShoot = 1
    }
}
