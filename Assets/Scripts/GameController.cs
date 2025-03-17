using UnityEngine;

public class GameController : MonoBehaviour
{
    public int destroyedCrosses = 0;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
