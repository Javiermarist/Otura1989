using Unity.VisualScripting;
using UnityEngine;

public class SphereCollision : MonoBehaviour
{
    public GameObject gameController;
    public GameObject brokenCross;
    public GameObject deadSwag;
    public GameObject deadBuenorra;
    public GameObject deadMegan;
    public GameObject deadCalvo;
    
    public DialogueController dialogueController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Swag"))
        {
            Destroy(collision.gameObject);
            Instantiate(deadSwag, collision.transform.position, Quaternion.identity);
            gameController.GetComponent<GameController>().deadNpcs++;
        }
        
        if (collision.gameObject.CompareTag("Buenorra"))
        {
            Destroy(collision.gameObject);
            Instantiate(deadBuenorra, collision.transform.position, Quaternion.identity);
            gameController.GetComponent<GameController>().deadNpcs++;
        }
        
        if (collision.gameObject.CompareTag("Calvo"))
        {
            Destroy(collision.gameObject);
            Instantiate(deadCalvo, collision.transform.position, Quaternion.identity);
            gameController.GetComponent<GameController>().deadNpcs++;
        }
        
        if (collision.gameObject.CompareTag("Megan"))
        {
            Destroy(collision.gameObject);
            Instantiate(deadMegan, collision.transform.position, Quaternion.identity);
            gameController.GetComponent<GameController>().deadNpcs++;
        }

        if (collision.gameObject.CompareTag("cross"))
        {
            if (gameController.GetComponent<GameController>().destroyedCrosses < 3)
            {
                dialogueController.StartDialogue0();
            }
            if (gameController.GetComponent<GameController>().destroyedCrosses == 3)
            {
                dialogueController.StartDialogue1();
            }
            
            Destroy(collision.gameObject);
            Instantiate(brokenCross, collision.transform.position, Quaternion.identity);
            gameController.GetComponent<GameController>().destroyedCrosses++;
        }
    }
}