using UnityEngine;
using View;

[CreateAssetMenu(menuName = "Datas", fileName = "DataShip")]
public class DataShip : ScriptableObject
{
    public float OffsetLeftBound;
    public float OffsetRightBound;
    public float OffsetTopBound;
    public float OffsetBottomBound;
}
