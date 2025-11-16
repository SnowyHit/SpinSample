using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinWheelUI : MonoBehaviour
{
    public Image WheelVisual;
    public Image WheelStickVisual;
    public TextMeshProUGUI BottomText_value;
    public TextMeshProUGUI TopText_value;

    public SpinWheelConfigSO wheelData;
    public SpinWheelSlotSO[] slotDatas;

    public void Start()
    {
        SetSpinWheel();
    }

    public void SetSpinWheel()
    {
        WheelVisual.sprite = wheelData.wheelVisual;
        WheelStickVisual.sprite = wheelData.wheelStickVisual;
        BottomText_value.text = wheelData.BottomString;
        TopText_value.text = wheelData.TopString;
        foreach (var slot in wheelData.slots)
        {
            SetData(slot);
        }

    }

    public void SetData(SpinWheelSlotSO data)
    {
    }
}