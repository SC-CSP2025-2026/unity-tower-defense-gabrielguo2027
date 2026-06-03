using UnityEngine;
using UnityEngine.Events;

public class TowerController : MonoBehaviour
{
    [field: SerializeField]
    public float BaseHealth { get; private set; } = 5f;

    [field: SerializeField]
    public float Damage { get; private set; } = 0f;

    [field: SerializeField]
    public UnityEvent<TowerController> OnDestroyed { get; private set; } = new();

    public void ApplyHit(EnemyAttack attack)
    {
        Damage += attack.Damage;
        Destroy(attack.gameObject);

        if (Damage >= BaseHealth)
        {
            OnDestroyed.Invoke(this);
            ShowGameOverLabel();
            Destroy(gameObject);
        }
    }

    private void ShowGameOverLabel()
    {
        foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>())
        {
            if (obj.name == "Game Over Label" && obj.scene.IsValid())
            {
                obj.SetActive(true);
            }
        }
    }
}
