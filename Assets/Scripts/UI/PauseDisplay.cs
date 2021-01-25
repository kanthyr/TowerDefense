using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseDisplay : MonoBehaviour
{
    public void GoToMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
