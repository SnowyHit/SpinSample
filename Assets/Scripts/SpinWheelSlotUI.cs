using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinWheelSlotUI : MonoBehaviour
{
    public Image icon;
    public Image bombIcon;
    public TextMeshProUGUI amount_value;
    public GameObject bombPanel;
    public GameObject rewardPanel;

    public void SetData(SpinWheelSlotSO data)
    {

        bombPanel.SetActive(data.isBomb);
        rewardPanel.SetActive(!data.isBomb);

        if (data == null)
        {
            icon.sprite = null;
            amount_value.text = "";
            return;
        }

        icon.sprite = data.icon;
        amount_value.text = "x" + data.rewardAmount.ToString();
    }
}