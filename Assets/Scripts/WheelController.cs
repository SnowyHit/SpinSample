using DG.Tweening;
using System;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [Header("Data")]
    public SpinWheelConfigSO config;
    public SpinWheelUI SpinWheelUIControllerRef;

    [Header("Settings")]
    public float spinDuration = 3f;
    public int minFullRotations = 3;
    public int maxFullRotations = 5;

    [Header("References")]
    public Transform wheelTransform; // Rotate this

    public event Action<SpinWheelSlotSO> OnSpinResult;

    private bool isSpinning = false;

    public void BuildWheel()
    {
        SpinWheelUIControllerRef.SetSpinWheel(config);
    }

    public void StartSpin()
    {
        if (isSpinning) return;

        SpinWheelSlotSO result = GetWeightedRandomSlot();
        SpinToSlot(result);
    }

    private SpinWheelSlotSO GetWeightedRandomSlot()
    {
        float totalWeight = config.slots.Sum(s => s.weight);
        float rand = UnityEngine.Random.value * totalWeight;

        float cumulative = 0;
        foreach (var s in config.slots)
        {
            cumulative += s.weight;
            if (rand <= cumulative)
                return s;
        }
        return config.slots.Last();
    }

    private void SpinToSlot(SpinWheelSlotSO result)
    {
        int resultIndex = config.slots.IndexOf(result);
        UnityEngine.Debug.Log($"[Spin] Result index: {resultIndex}");

        float anglePerSlot = 360f / config.slots.Count;
        UnityEngine.Debug.Log($"[Spin] Angle per slot: {anglePerSlot}");

        // Map resultIndex so ref 0 is at top (0 degrees)
        float targetAngle = resultIndex * anglePerSlot;
        UnityEngine.Debug.Log($"[Spin] Target angle before random turns: {targetAngle}");

        float randomTurns = UnityEngine.Random.Range(minFullRotations, maxFullRotations);
        UnityEngine.Debug.Log($"[Spin] Random full rotations: {randomTurns}");

        // Subtract full rotations for proper rotation direction (clockwise)
        float finalAngle = randomTurns * 360f + targetAngle;
        UnityEngine.Debug.Log($"[Spin] Final angle: {finalAngle}");

        isSpinning = true;
        UnityEngine.Debug.Log("[Spin] Starting spin...");

        wheelTransform
            .DORotate(new Vector3(0, 0, finalAngle), spinDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.OutQuart)
            .OnComplete(() =>
            {
                isSpinning = false;
                UnityEngine.Debug.Log("[Spin] Spin complete.");
                OnSpinResult?.Invoke(result);
            });
    }

    public bool IsSpinning()
    {
        return isSpinning;
    }
}