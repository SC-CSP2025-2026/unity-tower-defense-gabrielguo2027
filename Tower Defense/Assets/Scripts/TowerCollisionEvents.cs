using UnityEngine;
using UnityEngine.Events;

public class TowerCollisionEvents : MonoBehaviour
{
    [field: SerializeField]
    public TowerController Tower { get; private set; }

    [field: SerializeField]
    public UnityEvent<EnemyAttack> OnEnemyHit { get; private set; } = new();

    void OnTriggerEnter(Collider other)
    {
        EnemyAttack attack = other.GetComponentInParent<EnemyAttack>();
        if (attack == null)
        {
            return;
        }

        TowerController tower = Tower;
        if (tower == null)
        {
            tower = GetComponentInParent<TowerController>();
        }

        if (tower != null)
        {
            tower.ApplyHit(attack);
        }

        OnEnemyHit.Invoke(attack);
    }
}
