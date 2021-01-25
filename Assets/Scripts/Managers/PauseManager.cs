using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseDisplay = null;

    Controls _controls;

    bool isPaused;

    private void Start()
    {
        _controls = new Controls();
        _controls.Player.Pause.performed += HandleOnPauseButtonPerformed;
        _controls.Enable();
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseDisplay.SetActive(false);
    }

    private void HandleOnPauseButtonPerformed(InputAction.CallbackContext obj)
    {
        if (isPaused) { HandleOnUnpauseButtonPerformed(obj); }
        isPaused = true;
        pauseDisplay.SetActive(true);
        Time.timeScale = 0;
    }

    private void HandleOnUnpauseButtonPerformed(InputAction.CallbackContext obj)
    {
        Unpause();
    }
}
