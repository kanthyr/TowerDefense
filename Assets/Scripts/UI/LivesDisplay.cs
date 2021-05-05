using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text livesText = null;


    private void Start()
    {
        HandleLivesUpdated(GameManager.singleton.GetLives());

        GameManager.OnLivesUpdated += HandleLivesUpdated;
    }

    private void OnDestoy()
    {
        GameManager.OnLivesUpdated -= HandleLivesUpdated;
    }

    private void HandleLivesUpdated(int lives)
    {
        livesText.text = $"Vidas: {lives}";
    }
}
