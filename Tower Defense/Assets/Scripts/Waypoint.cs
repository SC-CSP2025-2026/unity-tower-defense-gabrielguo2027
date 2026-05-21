using UnityEngine;
using UnityEditor;

public class Waypoint : MonoBehaviour
{
    [field: SerializeField]
    public Waypoint Next {get; private set; }
    void OnDrawGizmos()
    {
        if(Next == null)
        {
            return;
        }
        Handles.color = Color.red;
        Handles.DrawLine(transform.position, Next.transform.position, 3f);
    }
}
