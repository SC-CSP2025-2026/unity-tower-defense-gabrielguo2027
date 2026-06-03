using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [field: SerializeField]
    public BuildingData Selected { get; set; }

    [field: SerializeField]
    public GameObject TargetGrid { get; private set; }

    [field: SerializeField]
    public PlayerController Controller { get; private set; }

    void OnEnable()
    {
        ShowBuildModeInfo();
        ListenToTilesIn(TargetGrid);
    }

    void OnDisable()
    {
        StopListeningToTilesIn(TargetGrid);
        DisplayInfo("Click Build");
    }

    public void ListenToTilesIn(GameObject grid)
    {
        if (grid == null)
        {
            return;
        }

        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorEnter.AddListener(ShowInfo);
            tile.OnCursorExit.AddListener(ShowSelectTileInfo);
            tile.OnCursorClicked.AddListener(SpawnBuilding);
        }
    }

    public void SpawnBuilding(TileController tileController)
    {
        if (!CanSpawn(tileController))
        {
            return;
        }

        GameObject newBuilding = Instantiate(Selected.Prefab, Controller.transform);
        newBuilding.transform.position = tileController.transform.position;
        tileController.MarkOccupied();
        Controller.Gold -= Selected.Cost;
        gameObject.SetActive(false);
    }

    public bool CanSpawn(TileController tileController)
    {
        if (tileController == null || Selected == null || Selected.Prefab == null)
        {
            return false;
        }

        if (IsTileBlocked(tileController))
        {
            return false;
        }

        if (!HasEnoughGold())
        {
            return false;
        }

        return true;
    }

    public void ShowInfo(TileController tileController)
    {
        if (tileController == null)
        {
            return;
        }

        if (IsTileBlocked(tileController))
        {
            DisplayInfo("Cannot Build Here");
        }
        else if (!HasEnoughGold())
        {
            DisplayInfo("Not Enough Gold");
        }
        else if (Selected != null)
        {
            DisplayInfo($"Build {Selected.Name}: {Selected.Cost}");
        }
    }

    public void ShowSelectTileInfo(TileController tileController)
    {
        ShowBuildModeInfo();
    }

    private void ShowBuildModeInfo()
    {
        if (Selected == null)
        {
            DisplayInfo("Click Build");
        }
        else
        {
            DisplayInfo(HasEnoughGold() ? "Select a Tile" : "Not Enough Gold");
        }
    }

    private bool HasEnoughGold()
    {
        return Controller != null && Selected != null && Controller.Gold >= Selected.Cost;
    }

    private bool IsTileBlocked(TileController tileController)
    {
        return tileController.IsOccupied || tileController.transform.childCount > 1;
    }

    private void DisplayInfo(string info)
    {
        if (Controller != null)
        {
            Controller.DisplayInfo(info);
        }
    }

    public void StopListeningToTilesIn(GameObject grid)
    {
        if (grid == null)
        {
            return;
        }

        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorEnter.RemoveListener(ShowInfo);
            tile.OnCursorExit.RemoveListener(ShowSelectTileInfo);
            tile.OnCursorClicked.RemoveListener(SpawnBuilding);
        }
    }
}
