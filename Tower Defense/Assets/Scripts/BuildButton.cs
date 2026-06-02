using UnityEngine;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TileCursor { get; private set; }

    [field: SerializeField]
    public GameObject TurretSpawner { get; private set; }

    [field: SerializeField]
    public GameObject BuildingPrefab { get; private set; }

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

        if (TurretSpawner != null)
        {
            TurretSpawner spawner = TurretSpawner.GetComponent<TurretSpawner>();
            if (spawner != null && BuildingPrefab != null)
            {
                spawner.TurretPrefab = BuildingPrefab;
            }

            TurretSpawner.SetActive(true);
        }
    }
}
