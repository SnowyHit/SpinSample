using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Wheel/Config")]
public class SpinWheelConfigSO : ScriptableObject
{
    public string configName;
    public List<SpinWheelSlotSO> slots = new List<SpinWheelSlotSO>();
    public Color TextColor;
    public Sprite wheelVisual;
    public Sprite wheelStickVisual;

    public string TopString = "";
    public string BottomString = "";

    private const int RequiredSlots = 8;

    private void OnValidate()
    {
        if (slots.Count != RequiredSlots)
        {
            Debug.LogWarning($"{configName} must have exactly {RequiredSlots} slots.");
        }
    }
}