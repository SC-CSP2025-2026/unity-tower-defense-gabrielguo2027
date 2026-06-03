using UnityEngine;

public class CameraMaskEventController : MonoBehaviour
{
    [field: SerializeField]
    public LayerMask EventMask {get; private set;}
     void Awake()
    {
        Camera camera = GetComponent<Camera>();
        if (camera == null)
        {
            return;
        }

        camera.eventMask = EventMask;
    }
}
