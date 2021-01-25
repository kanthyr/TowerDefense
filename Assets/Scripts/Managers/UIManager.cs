using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject buildingDisplay;
    [SerializeField] GameObject defendingDisplay;

    void Start()
    {
        StageManager.OnBuildingState += HandleOnBuildingState;
        StageManager.OnDefendingState += HandleOnDefendingState;
    }

    private void OnDestroy()
    {
        StageManager.OnBuildingState -= HandleOnBuildingState;
        StageManager.OnDefendingState -= HandleOnDefendingState;
    }

    private void HandleOnBuildingState()
    {
        defendingDisplay.SetActive(false);
        buildingDisplay.SetActive(true);
    }

    private void HandleOnDefendingState()
    {
        defendingDisplay.SetActive(true);
        buildingDisplay.SetActive(false);
    }

}

