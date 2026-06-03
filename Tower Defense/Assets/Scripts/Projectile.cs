using UnityEngine;

public class Projectile : MonoBehaviour
{
    [field: SerializeField]
    public float Speed { get; private set; } = 18f;

    [field: SerializeField]
    public float Damage { get; private set; } = 1f;

    [field: SerializeField]
    public int GoldReward { get; private set; } = 0;

    [field: SerializeField]
    public PlayerController Controller { get; set; }

    [field: SerializeField]
    public Transform Target { get; set; }

    void Start()
    {
        if (Target == null || Target.gameObject.scene.IsValid() == false)
        {
            Health health = FindFirstObjectByType<Health>();

            if (health != null)
            {
                Target = health.transform;
            }
        }
    }

    void Update()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.LookAt(Target);
        transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, Target.position) <= Mathf.Epsilon)
        {
            Hit();
        }
    }

    void Hit()
    {
        Health health = Target.GetComponentInParent<Health>();
        if (health != null)
        {
            health.ApplyHit(this);
        }

        Destroy(gameObject);
    }

    public void ApplyKillReward()
    {
        if (Controller != null)
        {
            Controller.Gold += GoldReward;
        }
    }
}
