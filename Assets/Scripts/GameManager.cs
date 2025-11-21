using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ---------------- Singleton ----------------
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    _instance = go.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    // Inspector
    [Header("References")]
    public WheelController wheelCont;
    public UIController UICont;

    [Header("Wheel Configs")]
    public SpinWheelConfigSO WheelConfigBronze;
    public SpinWheelConfigSO WheelConfigSilver;
    public SpinWheelConfigSO WheelConfigGold;

    [HideInInspector] public int currentZone = 1;
    public List<SpinWheelSlotSO> collectedRewards = new List<SpinWheelSlotSO>();

    private bool isSafeZone;
    private bool isSuperZone;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        wheelCont.OnSpinResult += OnWheelResult;
        SetupZone();
    }
    public void SetupZone()
    {
        isSuperZone = currentZone % 30 == 0;
        isSafeZone = currentZone % 5 == 0 && !isSuperZone;

        if (isSuperZone)
            wheelCont.config = WheelConfigGold;
        else if (isSafeZone)
            wheelCont.config = WheelConfigSilver;
        else
            wheelCont.config = WheelConfigBronze;

        wheelCont.BuildWheel();

        Debug.Log($"Zone {currentZone}: {GetZoneTypeString()}");
    }

    private void OnWheelResult(SpinWheelSlotSO result)
    {
        if (result.isBomb)
        {
            collectedRewards.Clear();
            UICont.ShowRewardScreen(result, collectedRewards, true);

            Debug.Log("Bomb hit. Resetting game.");
            currentZone = 1;
            return;
        }

        AddOrUpdateReward(result);
        UICont.ShowRewardScreen(result, collectedRewards, false);

        Debug.Log($"Reward: {result.id} (x{result.rewardAmount})");

        currentZone++;
        SetupZone();
    }
    private void AddOrUpdateReward(SpinWheelSlotSO result)
    {
        // Check if reward already exists
        foreach (var r in collectedRewards)
        {
            if (r.id == result.id)
            {
                r.rewardAmount += result.rewardAmount;
                return;
            }
        }

        // Add a CLONED slot instead of the real SO
        collectedRewards.Add(CloneSlot(result));
    }
    private SpinWheelSlotSO CloneSlot(SpinWheelSlotSO original)
    {
        SpinWheelSlotSO clone = ScriptableObject.CreateInstance<SpinWheelSlotSO>();
        clone.id = original.id;
        clone.rewardAmount = original.rewardAmount;
        clone.isBomb = original.isBomb;
        clone.icon = original.icon;
        return clone;
    }

    public void PlayerLeaves()
    {
        Debug.Log($"Cashed out {collectedRewards.Count} rewards.");

        collectedRewards.Clear();
        currentZone = 1;
        SetupZone();
        UICont.ShowSpinScreen();
    }

    public void ContinueGame()
    {
        UICont.ShowSpinScreen();
    }

    private string GetZoneTypeString()
    {
        if (isSuperZone) return "Golden Spin";
        if (isSafeZone) return "Silver Spin";
        return "Bronze Spin";
    }
}