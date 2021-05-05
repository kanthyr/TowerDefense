using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text resourcesText = null;

    private void Start()
    {
        HandleResourcesUpdated(GameManager.singleton.GetResources());

        GameManager.OnResourcesUpdated += HandleResourcesUpdated;
    }

    private void OnDestoy()
    {
        GameManager.OnResourcesUpdated -= HandleResourcesUpdated;
    }

    private void HandleResourcesUpdated(int resources)
    {
        resourcesText.text = $"Recursos: {resources}";
    }
}
