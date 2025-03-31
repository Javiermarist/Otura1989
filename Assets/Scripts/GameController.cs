using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public int destroyedCrosses = 0;
    public int deadNpcs = 0;
    public List<GameObject> objectsToDeactivate;
    public List<GameObject> objectsToDeactivate2;
    public GameObject possesion;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (destroyedCrosses >= 4)
        {
            foreach (GameObject obj in objectsToDeactivate)
            {
                obj.SetActive(false);
            }
        }
        if (deadNpcs >= 4)
        {
            foreach (GameObject obj in objectsToDeactivate2)
            {
                obj.SetActive(false);
            }
            possesion.SetActive(true);
        }
    }
}