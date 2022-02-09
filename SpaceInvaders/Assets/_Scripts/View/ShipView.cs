using Model;
using System;
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

        public event Action OnDeath;
        public event Action<Damage> OnDamage;
        public event Action<BonusType> OnGetBonus;

        public void SetActive(bool param)
        {
            gameObject.SetActive(param);
        }

        public void DealDamage(Damage damage)
        {
            OnDamage?.Invoke(damage);
        }

        public void GetBonus(BonusType bonusType)
        {
            OnGetBonus?.Invoke(bonusType);
        }

        private void OnDisable()
        {
            OnDeath?.Invoke();
        }
    } 
}
