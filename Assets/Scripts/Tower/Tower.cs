using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject buildingPreview = null;
    [SerializeField] private Sprite icon = null;
    [SerializeField] private int id = -1;
    [SerializeField] private int price = 20;

    public static event Action<Tower> OnBuildingSpawned;
    public static event Action<Tower> OnBuildingDespawned;

    public GameObject GetBuildingPreview()
    {
        return buildingPreview;
    }

    public Sprite GetIcon()
    {
        return icon;
    }

    public int GetId()
    {
        return id;
    }

    public int GetPrice()
    {
        return price;
    }

    private void Start()
    {
        OnBuildingSpawned?.Invoke(this);
    }

    private void OnDestroy()
    {
        OnBuildingDespawned?.Invoke(this);
    }


}
