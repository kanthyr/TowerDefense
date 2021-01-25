using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text resourcesText = null;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        HandleResourcesUpdated(gameManager.GetResources());

        gameManager.OnResourcesUpdated += HandleResourcesUpdated;
    }

    private void OnDestoy()
    {
        gameManager.OnResourcesUpdated -= HandleResourcesUpdated;
    }

    private void HandleResourcesUpdated(int resources)
    {
        resourcesText.text = $"Recursos: {resources}";
    }
}
