using UnityEngine;

public class StartingMission : MonoBehaviour
{
    public DialogueController dialogueController;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueController.StartDialogue2();
        }
    }
}
