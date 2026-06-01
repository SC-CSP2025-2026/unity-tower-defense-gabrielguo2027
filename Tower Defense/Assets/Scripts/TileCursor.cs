using UnityEngine;

public class TileCursor : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TargetGrid {get; private set;}

    [field: SerializeField]
    public GameObject Model { get; private set; }

    void OnEnable()
    {
        if (TargetGrid == null || Model == null)
        {
            return;
        }

        Model.SetActive(false);
        ListenToTilesIn(TargetGrid);
    }

    void OnDisable()
    {
        if (TargetGrid == null)
        {
            return;
        }

        StopListeningToTilesIn(TargetGrid);
    }

    public void ListenToTilesIn(GameObject grid)
    {
        if (grid == null)
        {
            return;
        }

        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorEnter.AddListener(HandleTileEntered);
            tile.OnCursorExit.AddListener(HandleTileExited);
        }
    }

    public void HandleTileEntered(TileController tile)
    {
        if (Model == null)
        {
            return;
        }

        transform.position = tile.transform.position;
        Model.SetActive(true);
    }

    public void HandleTileExited(TileController tile)
    {
        if (Model == null)
        {
            return;
        }

        Model.SetActive(false);
    }

    public void StopListeningToTilesIn(GameObject grid)
    {
        if (grid == null)
        {
            return;
        }

        foreach(TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorEnter.RemoveListener(HandleTileEntered);
            tile.OnCursorExit.RemoveListener(HandleTileExited);
        }
    }
}
