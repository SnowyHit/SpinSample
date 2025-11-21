using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardPanelUI : MonoBehaviour
{
    [Header("Reward Screen")]
    public Button spinAgainButtonRef;
    public Button cashOutButtonRef;

    public TextMeshProUGUI rewardText;
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI cashOutButtonText;

    public Image icon;

    public GameObject BombPanel;
    public GameObject RewardPanel;

    private void Start()
    {
        // Button bindings
        spinAgainButtonRef.onClick.RemoveAllListeners();
        spinAgainButtonRef.onClick.AddListener(OnSpinAgainClicked);

        cashOutButtonRef.onClick.RemoveAllListeners();
        cashOutButtonRef.onClick.AddListener(OnCashOutClicked);
    }
    public void ShowRewardScreen(SpinWheelSlotSO spinSlot, List<SpinWheelSlotSO> collectedRewards, bool isBomb)
    {
        if (isBomb)
        {
            ShowBombUI();
            return;
        }

        ShowRewardUI(spinSlot, collectedRewards);
    }

    private void ShowBombUI()
    {
        BombPanel.SetActive(true);
        RewardPanel.SetActive(false);

        infoText.text = "BOMB! All rewards lost!";
        rewardText.text = "";
        icon.sprite = null;

        spinAgainButtonRef.interactable = false;
        cashOutButtonText.text = "Try Again!";
    }


    private void ShowRewardUI(SpinWheelSlotSO spinSlot, List<SpinWheelSlotSO> collectedRewards)
    {
        BombPanel.SetActive(false);
        RewardPanel.SetActive(true);

        // Top info text
        infoText.text = $"You Won: {spinSlot.id} x{spinSlot.rewardAmount}";

        icon.sprite = spinSlot.icon;

        // Build reward list text
        string rewardString = $"Last Spin: {spinSlot.id} x{spinSlot.rewardAmount}\n\nCollected Rewards:\n";

        foreach (var slot in collectedRewards)
            rewardString += $"{slot.id} x{slot.rewardAmount}\n";

        rewardText.text = rewardString;

        spinAgainButtonRef.interactable = true;
        cashOutButtonText.text = "Cash Out";
    }

    private void OnSpinAgainClicked()
    {
        GameManager.Instance.ContinueGame();
    }

    private void OnCashOutClicked()
    {
        GameManager.Instance.PlayerLeaves();
    }
}
