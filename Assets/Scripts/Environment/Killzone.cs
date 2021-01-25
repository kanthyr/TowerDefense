using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    AudioSource audioSource;

    public static event Action<Enemy> OnEnemyEnterKillzone;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            OnEnemyEnterKillzone?.Invoke(other.gameObject.GetComponent<Enemy>());

            audioSource.Play();
        }
    }
}
