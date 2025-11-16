using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinWheelSlotUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI amount_value;

    public void SetData(SpinWheelSlotSO data)
    {
        if (data == null)
        {
            icon.sprite = null;
            amount_value.text = "";
            return;
        }

        icon.sprite = data.icon;
        amount_value.text = data.isBomb ? "" : data.rewardAmount.ToString();
    }
}