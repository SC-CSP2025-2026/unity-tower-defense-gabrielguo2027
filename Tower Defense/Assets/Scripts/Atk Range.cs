using UnityEngine;
using System.Collections.Generic;

public class AtkRange : MonoBehaviour
{
    [field: SerializeField]
    public List<Transform> Targets {get; private set;} = new();

    void OnTriggerEnter(Collider other)
    {
        Targets.Add(other.transform);
    }

    void OnTriggerExit(Collider other)
    {
        Targets.Remove(other.transform);
    }
}
