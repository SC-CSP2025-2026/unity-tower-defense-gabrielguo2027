using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Tower Defense/Building Data")]
public class BuildingData : ScriptableObject
{
    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField]
    public int Cost { get; private set; } = 50;

    [field: SerializeField]
    public GameObject Prefab { get; private set; }
}
