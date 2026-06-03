using UnityEngine;

public class GoldGenerator : MonoBehaviour
{
    [field: SerializeField]
    public float Delay { get; private set; } = 2f;

    [field: SerializeField]
    public int Gold { get; private set; } = 1;

    [field: SerializeField]
    public PlayerController Controller { get; private set; }

    void Awake()
    {
        Controller = GetComponentInParent<PlayerController>();
    }

    void OnEnable()
    {
        InvokeRepeating(nameof(GenerateGold), Delay, Delay);
    }

    void OnDisable()
    {
        CancelInvoke(nameof(GenerateGold));
    }

    public void GenerateGold()
    {
        if (Controller != null)
        {
            Controller.Gold += Gold;
        }
    }
}
