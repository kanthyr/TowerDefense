using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject buildingCamera;
    [SerializeField] GameObject defendingCamera;

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
        defendingCamera.SetActive(false);
        buildingCamera.SetActive(true);
    }

    private void HandleOnDefendingState()
    {
        defendingCamera.SetActive(true);
        buildingCamera.SetActive(false);
    }

}
