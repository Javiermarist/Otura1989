using UnityEngine;

public class SphereCollision : MonoBehaviour
{
    public GameObject gameController;
    public GameObject brokenCross;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("cross"))
        {
            Destroy(collision.gameObject);
            Instantiate(brokenCross, collision.transform.position, Quaternion.identity);
            gameController.GetComponent<GameController>().destroyedCrosses++;
        }
    }
}