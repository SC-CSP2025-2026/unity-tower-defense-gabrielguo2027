using UnityEngine;

public class BuildButton : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TileCursor { get; private set; }

    [field: SerializeField]
    public GameObject TurretSpawner { get; private set; }

    void OnGUI()
    {
        Rect buttonArea = new Rect(20, Screen.height - 60, 120, 40);

        if (GUI.Button(buttonArea, "Build"))
        {
            TileCursor.SetActive(true);
            TurretSpawner.SetActive(true);
        }
    }
}
