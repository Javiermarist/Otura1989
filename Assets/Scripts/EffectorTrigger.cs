using UnityEngine;
using System.Collections;

public class EffectorTrigger : MonoBehaviour
{
    public ParticleSystem effector;
    public DialogueController dialogueController;
    public GameObject[] objectsToDeactivate;
    public GameObject[] objectsToActivate; 
    public float activeDuration = 5f;
    public float delayBeforeDeactivating = 1f;
    public float dialogueDelay = 2f;

    public GameObject player;
    private CharController_Motor playerMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            playerMovement = player.GetComponent<CharController_Motor>();
            StartCoroutine(ActivateEffector());
        }
    }

    private IEnumerator ActivateEffector()
    {
        effector.Play();
        
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
        }

        CharacterController characterController = player.GetComponent<CharacterController>();
        if (characterController != null)
        {
            characterController.enabled = false;
        }

        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        yield return new WaitForSeconds(dialogueDelay);
        dialogueController.GetComponent<DialogueController>().StartDialogue4();

        yield return new WaitForSeconds(delayBeforeDeactivating);

        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }

        yield return new WaitForSeconds(activeDuration - delayBeforeDeactivating);

        effector.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        if (characterController != null)
        {
            characterController.enabled = true;
        }

        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }

        gameObject.SetActive(false);
    }
}