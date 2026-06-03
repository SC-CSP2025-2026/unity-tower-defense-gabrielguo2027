using UnityEngine;

public class SlowRange : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponentInParent<EnemyMovement>();
        if (enemy != null)
        {
            enemy.AddSlow();
        }
    }

    void OnTriggerExit(Collider other)
    {
        EnemyMovement enemy = other.GetComponentInParent<EnemyMovement>();
        if (enemy != null)
        {
            enemy.RemoveSlow();
        }
    }
}
