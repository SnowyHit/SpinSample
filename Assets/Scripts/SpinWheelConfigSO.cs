using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "SpinWheelConfig", menuName = "SpinWheel/SpinWheelConfig")]
public class SpinWheelConfigSO : ScriptableObject
{
    public string configName;
    [Tooltip("Must contain exactly 8 slots.")]
    public List<SpinWheelSlotSO> slots = new List<SpinWheelSlotSO>();

    public bool isSafeWheel = false; // safe zone (no bomb)
    public Sprite wheelVisual;
    public Sprite wheelStickVisual;
    public string TopString = "";
    public string BottomString = "";

    private const int RequiredSlots = 8;

    private void OnValidate()
    {
        if (slots == null) slots = new List<SpinWheelSlotSO>();
        if (slots.Count > RequiredSlots)
        {
            // keep first 8 to avoid accidental overflow
            while (slots.Count > RequiredSlots) slots.RemoveAt(slots.Count - 1);
#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(this);
#endif
        }

        // fill with null placeholders up to size to make inspector grid clearer
        while (slots.Count < RequiredSlots) slots.Add(null);

        // If wheel is safe, ensure no bomb slot is present (soft warning)
        if (isSafeWheel)
        {
            bool foundBomb = false;
            foreach (var s in slots) if (s != null && s.isBomb) { foundBomb = true; break; }
#if UNITY_EDITOR
            if (foundBomb)
            {
                Debug.LogWarning($"WheelConfig '{name}' marked safe but contains a bomb slot. Remove bomb or uncheck isSafeWheel.");
            }
#endif
        }
    }
}
