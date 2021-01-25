using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectile : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb = null;
    [SerializeField] private float launchForce = 10f;
    [SerializeField] private float destroyAfterSeconds = 5f;
    [SerializeField] private int damageToDeal = 20;

    private void Start()
    {
        _rb.velocity = transform.forward * launchForce;
        Invoke(nameof(DestroySelf), destroyAfterSeconds);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Health>(out Health health))
        {
            health.DealDamage(damageToDeal);

            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
