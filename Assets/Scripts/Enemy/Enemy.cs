using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Health health = null;

    [SerializeField] private int enemyResourceValue = 10;

    [SerializeField] private GameObject deathFX = default;

    public static event Action<Enemy> OnEnemySpawned;
    public static event Action<Enemy> OnEnemyDespawned;

    public int GetEnemyResourceValue { get { return enemyResourceValue; } }

    private void Start()
    {
        OnEnemySpawned?.Invoke(this);
        health.EnemyOnDie += HandleDie;
    }

    private void OnDestroy()
    {
        health.EnemyOnDie -= HandleDie;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Killzone"))
        {
            Destroy(this.gameObject);
        }
    }

    private void HandleDie()
    {
        OnEnemyDespawned?.Invoke(this);
        Instantiate(deathFX, new Vector3(this.transform.position.x, deathFX.transform.position.y, this.transform.position.z), deathFX.transform.rotation);
        Destroy(this.gameObject);
    }
}
