using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    [field: SerializeField]
    public float rotatingSpeed {get; private set;} = 90f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
{
    transform.Rotate(0f, rotatingSpeed * Time.deltaTime, 0f);
}
}
//why is it 1f
//what is Vector3
//Why don't we do the transform.rotate += new ()??

