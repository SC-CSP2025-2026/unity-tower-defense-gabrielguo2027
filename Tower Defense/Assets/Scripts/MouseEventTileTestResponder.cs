using UnityEngine;

public class MouseEventTileTestResponder : MonoBehaviour
{
    public void RenameMouseEntered()
    {
        gameObject.name = "MouseEntered";
    }

    public void RenameExited()
    {
        gameObject.name = "Exited";
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
