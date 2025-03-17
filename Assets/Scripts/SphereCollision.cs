using UnityEngine;

public class SphereCollision : MonoBehaviour
{
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
            GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();
            gameController.destroyedCrosses++;
        }
    }
}