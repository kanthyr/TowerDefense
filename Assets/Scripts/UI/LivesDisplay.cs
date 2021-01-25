using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text livesText = null;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        HandleLivesUpdated(gameManager.GetLives());

        gameManager.OnLivesUpdated += HandleLivesUpdated;
    }

    private void OnDestoy()
    {
        gameManager.OnLivesUpdated -= HandleLivesUpdated;
    }

    private void HandleLivesUpdated(int lives)
    {
        livesText.text = $"Vidas: {lives}";
    }
}
