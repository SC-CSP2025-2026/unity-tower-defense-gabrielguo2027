using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TurretPrefab {get;private set;}

    public void SpawnTurret(TileController tileController)
    {
        if (tileController.IsOccupied)
        {
            return;
        }
        GameObject newTurret = Instantiate(TurretPrefab);
        newTurret.transform.position = tileController.transform.position;
    }
}
