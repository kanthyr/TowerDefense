using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathFX : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(nameof(KillTime));
    }

    IEnumerator KillTime()
    {
        yield return new WaitForSecondsRealtime(2f);
        Destroy(this.gameObject);
    }
}
