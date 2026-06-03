using UnityEngine;
using System.Collections.Generic;

public class AtkRange : MonoBehaviour
{
    [field: SerializeField]
    public List<Health> Targets { get; private set; } = new();

    void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponentInParent<Health>();
        if (health == null)
        {
            return;
        }

        Targets.Add(health);
        health.OnDeath.AddListener(RemoveOnDeath);
    }

    void OnTriggerExit(Collider other)
    {
        Health health = other.GetComponentInParent<Health>();
        if (health == null)
        {
            return;
        }

        Targets.Remove(health);
        health.OnDeath.RemoveListener(RemoveOnDeath);
    }

    void RemoveOnDeath(Health targetHealth)
    {
        Targets.Remove(targetHealth);
    }
}
