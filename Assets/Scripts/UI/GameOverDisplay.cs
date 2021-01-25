using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText = null;

    GameManager gameManager;

    public static event Action OnGameOverButton;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        GameManager.OnGameOver += HandleOnGameOver;
    }

    private void OnDestroy()
    {
        GameManager.OnGameOver -= HandleOnGameOver;
    }

    public void GameOverButton()
    {
        OnGameOverButton?.Invoke();
    }

    private void HandleOnGameOver()
    {
        scoreText.text = $"Puntuación = {gameManager.GetScore()}";
    }
}
