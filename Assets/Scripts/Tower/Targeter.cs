using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    private Targetable target;

    public Targetable GetTarget()
    {
        return target;
    }

    private void Start()
    {
        GameManager.OnGameOver += HandleGameOver;
    }

    private void OnDestroy()
    {
        GameManager.OnGameOver -= HandleGameOver;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.TryGetComponent<Targetable>(out Targetable newTarget)) { return; }

        if (target != null) { return; }

        target = newTarget;
    }

    public void ClearTarget()
    {
        target = null;
    }

    private void HandleGameOver()
    {
        ClearTarget();
    }
}
