using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverDisplay;

    public static event Action OnReturnToMenu;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnGameOver += HandleOnGameOver;
        GameOverDisplay.OnGameOverButton += HandleOnGameOverButton;
    }

    private void OnDestroy()
    {
        GameManager.OnGameOver -= HandleOnGameOver;
        GameOverDisplay.OnGameOverButton -= HandleOnGameOverButton;
    }

    private void HandleOnGameOverButton()
    {
        OnReturnToMenu?.Invoke();
    }

    private void HandleOnGameOver()
    {
        gameOverDisplay.SetActive(true);
    }

}
