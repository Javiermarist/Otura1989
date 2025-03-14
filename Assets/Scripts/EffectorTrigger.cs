using UnityEngine;
using System.Collections;

public class EffectorTrigger : MonoBehaviour
{
    public ParticleSystem effector;
    public GameObject[] objectsToDeactivate;
    public GameObject[] objectsToActivate; 
    public float activeDuration = 5f;
    public float delayBeforeDeactivating = 2f; // Tiempo de espera antes de desactivar los objetos

    public GameObject player; // Variable para almacenar la referencia al jugador
    private CharController_Motor playerMovement; // Referencia al script de movimiento del jugador (ajustar según tu código)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject; // Almacenar la referencia al jugador
            playerMovement = player.GetComponent<CharController_Motor>(); // Obtener el script de movimiento del jugador
            StartCoroutine(ActivateEffector());
        }
    }

    private IEnumerator ActivateEffector()
    {
        effector.Play();
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true); // Activar los objetos
        }

        // Desactivar el CharacterController y el movimiento del jugador
        CharacterController characterController = player.GetComponent<CharacterController>();
        if (characterController != null)
        {
            characterController.enabled = false;
        }

        if (playerMovement != null)
        {
            playerMovement.enabled = false; // Desactivar el script de movimiento del jugador (ajustar a tu código)
        }

        // Esperar el tiempo antes de desactivar los objetos
        yield return new WaitForSeconds(delayBeforeDeactivating);

        // Desactivar los objetos después del tiempo de espera
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }

        // Mantener la espera activa hasta que termine el efecto
        yield return new WaitForSeconds(activeDuration - delayBeforeDeactivating);

        // Detener el effector (ParticleSystem)
        effector.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear); // Asegúrate de parar las partículas y limpiarlas

        // No reactives los objetos desactivados, sólo desactiva los objetos activos
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(false); // Desactivar los objetos activados
        }

        // Reactivar el CharacterController y el movimiento del jugador
        if (characterController != null)
        {
            characterController.enabled = true;
        }

        if (playerMovement != null)
        {
            playerMovement.enabled = true; // Reactivar el movimiento del jugador
        }

        // Desactivar este objeto (el que tiene el script)
        gameObject.SetActive(false);
    }
}