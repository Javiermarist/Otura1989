using UnityEngine;

public class SphereCollision : MonoBehaviour
{
    public GameObject gameController;
    public GameObject brokenCross;
    public DialogueController dialogueController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            Destroy(collision.gameObject);
            gameController.GetComponent<GameController>().deadNpcs++;
        }

        if (collision.gameObject.CompareTag("cross"))
        {
            Destroy(collision.gameObject);
            Instantiate(brokenCross, collision.transform.position, Quaternion.identity);
            
            gameController.GetComponent<GameController>().destroyedCrosses++;
            
            if (gameController.GetComponent<GameController>().destroyedCrosses < 3)
            {
                dialogueController.StartDialogue();
            }
            else
            {
                dialogueController.lineIndex ++;
                dialogueController.StartDialogue();
            }
        }
    }
}