using UnityEngine;

[CreateAssetMenu(fileName = "WheelSlot", menuName = "SpinWheel/SpinWheelSlot")]
public class SpinWheelSlotSO : ScriptableObject
{
    public string id;
    public Sprite icon;
    public int rewardAmount = 0;
    public bool isBomb = false;
    [Tooltip("Relative chance to land on this slice. 0 = impossible")]
    public float weight = 1f;
}