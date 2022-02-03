using UnityEngine;
using View;

[CreateAssetMenu(menuName = "Datas/ShipModel", fileName = "DataShip")]
public class DataShip : ScriptableObject
{
    [Header("BoundsMove")]
    [SerializeField] private float _offsetLeftBound;
    [SerializeField] private float _offsetRightBound;
    [SerializeField] private float _offsetTopBound;
    [SerializeField] private float _offsetBottomBound;

    [Header("MovePlayer")]
    [SerializeField] private float _speedShipPlayer;
    [SerializeField] private float _offsetMoveShipPlayer;

    [Header("Weapons")]
    [SerializeField] private ProjectileView _weapon;

    public float OffsetLeftBound => _offsetLeftBound;
    public float OffsetRightBound => _offsetRightBound;
    public float OffsetTopBound => _offsetTopBound;
    public float OffsetBottomBound => _offsetBottomBound;
    public float Speed => _speedShipPlayer;
    public float OffsetMove => _offsetMoveShipPlayer;
    public ProjectileView Weapon => _weapon;
}
