using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Wheel")]
    public SpinWheelUI wheelUIRef;
    [Header("Reward Panel")]
    public RewardPanelUI rewardUIRef;

    [Header("Panels")]
    public GameObject RewardPanel;
    public GameObject SpinPanel;


    // Show reward screen for each spin
    public void ShowRewardScreen(SpinWheelSlotSO spinSlot, List<SpinWheelSlotSO> collectedRewards, bool isBomb)
    {
        RewardPanel.SetActive(true);
        rewardUIRef.ShowRewardScreen(spinSlot, collectedRewards, isBomb);
    }

    public void ShowSpinScreen()
    {
        RewardPanel.SetActive(false);
    }

   
}