using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static event Action OnBuildingState;
    public static event Action OnDefendingState;

    void Start()
    {
        NextRoundDisplay.OnNextRound += HandleOnNextRound;
        EnemyManager.OnLastEnemyDefeated += HandleOnLastEnemyDefeated;
    }

    private void OnDestroy()
    {
        NextRoundDisplay.OnNextRound -= HandleOnNextRound;
        EnemyManager.OnLastEnemyDefeated -= HandleOnLastEnemyDefeated;
    }

    private void HandleOnNextRound()
    {
        OnDefendingState?.Invoke();
    }

    private void HandleOnLastEnemyDefeated()
    {
        OnBuildingState?.Invoke();
    }
}
