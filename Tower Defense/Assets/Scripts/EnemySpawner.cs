using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [field: SerializeField]
    public EnemyMovement Enemy {get; private set; }

    [field: SerializeField]
    public Waypoint StartingWaypoint { get; private set; }

    [field: SerializeField]
    public float Delay {get; private set;} = 5f;

    [field: SerializeField]
    public float MaxSpawn {get; private set;} = 10f;
    void Start()
    {
        InvokeRepeating(nameof(Spawn), Delay , Delay);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(MaxSpawn == 0)
        {
            CancelInvoke();
        }
        
    }

    public void Spawn()
    {
        EnemyMovement newEnemy = Object.Instantiate(Enemy);
        newEnemy.Target = StartingWaypoint;
        MaxSpawn--;
    }
}
