using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    public int Gold { get; set; } = 200;

    [field: SerializeField]
    public TextMeshProUGUI InfoLabel { get; private set; }

    public string InfoText { get; private set; } = "Click Build";

    void Start()
    {
        DisplayInfo(InfoText);
    }

    public void DisplayInfo(string info)
    {
        InfoText = info;

        if (InfoLabel != null)
        {
            InfoLabel.text = info;
        }
    }

}
