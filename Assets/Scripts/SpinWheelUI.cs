using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpinWheelUI : MonoBehaviour
{
    [Header("UI References")]
    public Image WheelVisual;
    public Image WheelStickVisual;
    public TextMeshProUGUI BottomText_value;
    public TextMeshProUGUI TopText_value;
    public Button buttonRef; // The spin button
    public GameObject[] slotPrefabRefs;

    [Header("Wheel Data")]
    public WheelController wheelController;

    void Start()
    {
        // Assign button listener
        if (buttonRef != null)
        {
            buttonRef.onClick.RemoveAllListeners();
            buttonRef.onClick.AddListener(OnSpinButtonClicked);
        }
    }

    public void SetSpinWheel(SpinWheelConfigSO wheelData)
    {
        if (wheelController == null || wheelData == null) return;

        wheelController.config = wheelData;

        WheelVisual.sprite = wheelData.wheelVisual;
        WheelStickVisual.sprite = wheelData.wheelStickVisual;

        BottomText_value.text = wheelData.BottomString;
        TopText_value.text = wheelData.TopString;

        BottomText_value.color = wheelData.TextColor;
        TopText_value.color = wheelData.TextColor;

        for (int i = 0; i < wheelData.slots.Count; i++)
        {
            if (i < slotPrefabRefs.Length)
                slotPrefabRefs[i].GetComponent<SpinWheelSlotUI>().SetData(wheelData.slots[i]);
        }
    }

    private void OnSpinButtonClicked()
    {
        // Prevent spinning if wheel is already spinning
        if (wheelController.IsSpinning())
        {
            Debug.Log("Wheel is already spinning!");
            return;
        }

        // Start the spin
        wheelController.StartSpin();
    }
}