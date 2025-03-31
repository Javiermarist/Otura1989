using UnityEngine;
using System.Collections.Generic;

public class ActivateCross : MonoBehaviour
{
    public List<GameObject> objectsToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }
        }
    }
}