using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [field: SerializeField]
    public float Speed { get; private set;} = 1f;

    private int slowCount = 0;

    public float CurrentSpeed
    {
        get
        {
            if (slowCount > 0)
            {
                return Speed * 0.5f;
            }

            return Speed;
        }
    }

    [field: SerializeField]
    public Waypoint Target {get;  set;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Target == null)
        {
            return;
        }

        transform.position = Target.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, CurrentSpeed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, Target.transform.position);
        if (distance <= Mathf.Epsilon)
        {
            if(Target.Next == null)
            {
                return;
            }
            Target = Target.Next;
            transform.LookAt(Target.transform);
        }
    }

    public void AddSlow()
    {
        slowCount++;
    }

    public void RemoveSlow()
    {
        slowCount = Mathf.Max(0, slowCount - 1);
    }
}
