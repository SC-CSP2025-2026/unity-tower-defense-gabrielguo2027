using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    [field: SerializeField]
    public AtkRange AoE { get; private set; }

    [field: SerializeField]
    public Projectile ProjectilePrefab { get; private set; }

    [field: SerializeField]
    public float CooldownTime { get; private set; } = 3f;

    [field: SerializeField]
    public bool IsCoolingDown { get; private set; } = false;

    void Update()
    {
        if (IsCoolingDown)
        {
            return;
        }

        if (AoE.Targets.Count == 0)
        {
            return;
        }

        Fire();
        IsCoolingDown = true;
        Invoke(nameof(ResetCooldown), CooldownTime);
    }

    void Fire()
    {
        Projectile projectile = Instantiate(ProjectilePrefab);
        projectile.transform.position = transform.position;
        projectile.Target = AoE.Targets[0];
    }

    void ResetCooldown()
    {
        IsCoolingDown = false;
    }
}
