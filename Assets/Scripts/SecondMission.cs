using UnityEngine;
using System.Collections;

public class SecondMission : MonoBehaviour
{
    public DialogueController dialogueController;
    public float delayBeforeDeactivation = 0.1f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueController.GetComponent<DialogueController>().StartDialogue3();
            StartCoroutine(DeactivateAfterDelay());
        }
    }

    private IEnumerator DeactivateAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeDeactivation);
        gameObject.SetActive(false);
    }
}
