using UnityEngine;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TileCursor { get; private set; }

    [field: SerializeField]
    public GameObject BuildingSpawner { get; private set; }

    [field: SerializeField]
    public BuildingData Data { get; private set; }

    void Awake()
    {
        Button button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(Build);
        }
    }

    public void Build()
    {
        if (TileCursor != null)
        {
            TileCursor.SetActive(true);
        }

        if (BuildingSpawner != null)
        {
            BuildingSpawner spawner = BuildingSpawner.GetComponent<BuildingSpawner>();
            if (spawner != null && Data != null)
            {
                spawner.Selected = Data;
            }

            BuildingSpawner.SetActive(true);
        }
    }
}
