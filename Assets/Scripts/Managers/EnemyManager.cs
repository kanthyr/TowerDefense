using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    enum SpawnStages { SPAWNING, WAITING, DEFEATED }

    [Header("Enemies")]
    [SerializeField] GameObject[] enemyPrefabs = new GameObject[0];
    [SerializeField] Transform spawnPoint = null;
    [SerializeField] List<Enemy> enemyCount = new List<Enemy>();

    int numberOfSpawns = 1;
    int enemySelection;

    SpawnStages currentStage;

    public static event Action OnLastEnemyDefeated;

    void Start()
    {
        Enemy.OnEnemySpawned += HandleEnemyOnSpawn;
        Enemy.OnEnemyDespawned += HandleEnemyOnDespawn;
        Killzone.OnEnemyEnterKillzone += HandleEnemyEnterKillzone;
        StageManager.OnDefendingState += HandleOnDefendingState;
    }

    private void OnDestroy()
    {
        Enemy.OnEnemySpawned -= HandleEnemyOnSpawn;
        Enemy.OnEnemyDespawned -= HandleEnemyOnDespawn;
        Killzone.OnEnemyEnterKillzone -= HandleEnemyEnterKillzone;
        StageManager.OnDefendingState -= HandleOnDefendingState;
    }

    void EnemySpawn()
    {
        Instantiate(enemyPrefabs[enemySelection], spawnPoint.position, enemyPrefabs[enemySelection].transform.rotation);
    }

    void LastEnemyCheck()
    {
        if (enemyCount.Count == 0) 
        {
            currentStage = SpawnStages.DEFEATED;
            OnLastEnemyDefeated?.Invoke();
        }
    }

    private void HandleEnemyOnSpawn(Enemy enemy)
    {
        enemyCount.Add(enemy);
    }

    private void HandleEnemyOnDespawn(Enemy enemy)
    {
        enemyCount.Remove(enemy);
        LastEnemyCheck();
    }

    private void HandleEnemyEnterKillzone(Enemy enemy)
    {
        enemyCount.Remove(enemy);
        LastEnemyCheck();
    }

    private void HandleOnDefendingState()
    {
        currentStage = SpawnStages.SPAWNING;
        StartCoroutine(nameof(SpawnStage));
        
    }

    IEnumerator SpawnStage()
    {
        if (currentStage == SpawnStages.SPAWNING)
        {
            for (int i = 0; i < numberOfSpawns; i++)
            {
                yield return new WaitForSeconds(0.8f);
                EnemySpawn();
            }
        }
        currentStage = SpawnStages.WAITING;
        numberOfSpawns++;

        if (numberOfSpawns > 5)
        {
            numberOfSpawns = 1;
            enemySelection++;
            if (enemySelection > 9)
            {
                enemySelection = 0;
            }
        }
    }
}
