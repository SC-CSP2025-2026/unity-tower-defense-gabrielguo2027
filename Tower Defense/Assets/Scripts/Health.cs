using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [field: SerializeField]
    public float BaseHealth { get; private set;} = 2f;
    [field: SerializeField]
    public float Damage{get; private set;}

}
