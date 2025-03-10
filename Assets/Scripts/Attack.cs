using UnityEngine;

public class Attack : MonoBehaviour
{
    public float maxDistance = 3f;
    public LayerMask stoneLayer;

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, stoneLayer))
        {
            if (hit.collider.CompareTag("Stone"))
            {
                hit.collider.gameObject.SetActive(false);
            }
        }
    }
}