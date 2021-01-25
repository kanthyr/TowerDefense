using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health health = null;
//    [SerializeField] private GameObject healthBarParent = null;
    [SerializeField] private Image healthBarImage = null;

    //private bool displayingHealth;

    private void Awake()
    {
        health.ClientOnHealthUpdated += HandleHealthUpdated;
    }

    private void OnDestroy()
    {
        health.ClientOnHealthUpdated -= HandleHealthUpdated;
    }

    /*
    private void OnMouseEnter()
    {
        if (!displayingHealth)
        {
            healthBarParent.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (!displayingHealth)
        {
            healthBarParent.SetActive(false);
        }
    }

    public void ActivateHealthDisplay()
    {
        healthBarParent.SetActive(true);
        displayingHealth = true;
    }

    public void DeactivateHealthDisplay()
    {
        healthBarParent.SetActive(false);
        displayingHealth = false;
    }
    */

    private void HandleHealthUpdated(int currentHealth, int maxHealth)
    {
        healthBarImage.fillAmount = (float)currentHealth / maxHealth;
    }
}
