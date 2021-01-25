using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;

    private int currentHealth;

    public event Action EnemyOnDie;

    public event Action<int, int> ClientOnHealthUpdated;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void DealDamage(int damageAmount)
    {
        if (currentHealth == 0) { return; }

        currentHealth = Mathf.Max(currentHealth -= damageAmount, 0);

        ClientOnHealthUpdated?.Invoke(currentHealth, maxHealth);

        if (currentHealth != 0) { return; }

        EnemyOnDie?.Invoke();
    }
}
