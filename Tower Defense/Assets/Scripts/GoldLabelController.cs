using TMPro;
using UnityEngine;

public class GoldLabelController : MonoBehaviour
{
    [field: SerializeField]
    public PlayerController Controller { get; private set; }

    [field: SerializeField]
    public TextMeshProUGUI Label { get; private set; }

    void Update()
    {
        if (Controller == null || Label == null)
        {
            return;
        }

        Label.text = $"Gold: {Controller.Gold}";
    }

    void OnGUI()
    {
        if (Controller == null || Label != null)
        {
            return;
        }

        GUI.Label(new Rect(20, 20, 120, 30), $"Gold: {Controller.Gold}");
    }
}
