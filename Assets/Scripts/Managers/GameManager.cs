using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Towers")]
    [SerializeField] Tower[] towers = new Tower[0];
    [SerializeField] private LayerMask buildingBlockLayer = new LayerMask();
    [SerializeField] List<Tower> myTowers = new List<Tower>();
    [Header("Stats")]
    [SerializeField] int _lives = 3;
    [SerializeField] int _score = 0;
    [SerializeField] int _resources = 50;

    public event Action<int> OnResourcesUpdated;
    public event Action<int> OnLivesUpdated;

    public static event Action OnGameOver;

    public int GetLives()
    {
        return _lives;
    }

    public int GetScore()
    {
        return _score;
    }

    public int GetResources()
    {
        return _resources;
    }

    void Start()
    {
        Enemy.OnEnemyDespawned += HandleEnemyOnDespawn;
        Tower.OnBuildingSpawned += HandleTowerOnSpawn;
        Tower.OnBuildingDespawned += HandleTowerOnDespawn;
        Killzone.OnEnemyEnterKillzone += HandleEnemyEnterKillzone;
        GameOverManager.OnReturnToMenu += HandleOnReturnToMenu;
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyDespawned -= HandleEnemyOnDespawn;
        Tower.OnBuildingSpawned += HandleTowerOnSpawn;
        Tower.OnBuildingDespawned += HandleTowerOnDespawn;
        Killzone.OnEnemyEnterKillzone -= HandleEnemyEnterKillzone;
    }

    void SetResources(int newResources)
    {
        _resources = newResources;
    }

    public bool CanPlaceBuilding(BoxCollider buildingCollider, Vector3 point)
    {
        if (Physics.CheckBox(
            point + buildingCollider.center,
            buildingCollider.size / 2,
            Quaternion.identity,
            buildingBlockLayer))
        {
            return false;
        }

        return true;
    }

    public void TryPlaceBuilding(int towerId, Vector3 point)
    {
        Tower towerToPlace = null;

        foreach (Tower tower in towers)
        {
            if (tower.GetId() == towerId)
            {
                towerToPlace = tower;
                break;
            }
        }

        if (towerToPlace == null) { return; }

        if (_resources < towerToPlace.GetPrice()) { return; }

        BoxCollider buildingCollider = towerToPlace.GetComponent<BoxCollider>();

        if (!CanPlaceBuilding(buildingCollider, point)) { return; }

        GameObject buildingInstance =
            Instantiate(towerToPlace.gameObject, point, towerToPlace.transform.rotation);

        SetResources(_resources - towerToPlace.GetPrice());
    }

    private void HandleEnemyOnDespawn(Enemy enemy)
    {
        _score += 1;
        _resources += enemy.GetEnemyResourceValue;
        OnResourcesUpdated?.Invoke(_resources);
    }

    private void HandleTowerOnSpawn(Tower tower)
    {
        myTowers.Add(tower);
        OnResourcesUpdated?.Invoke(_resources);
    }

    private void HandleTowerOnDespawn(Tower tower)
    {
        myTowers.Remove(tower);
    }

    private void HandleEnemyEnterKillzone(Enemy enemy)
    {
        _lives -= 1;
        OnLivesUpdated?.Invoke(_lives);
        if (_lives == 0) { OnGameOver?.Invoke(); }
    }

    private void HandleOnReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
