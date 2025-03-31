using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereCollision : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject gameController;
    public GameObject demon2;
    public GameObject blood;
    public GameObject brokenCross;
    public GameObject deadSwag;
    public GameObject deadBuenorra;
    public GameObject deadMegan;
    public GameObject deadCalvo;
    public DialogueController dialogueController;
    
    [Header("Particle Systems")]
    public ParticleSystem effector;
    public Canvas ending;
    
    [Header("Audio Sources")]
    public AudioSource scream1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Swag"))
        {
            Destroy(collision.gameObject);
            //scream1.Play();
            Instantiate(blood, collision.transform.position, Quaternion.identity);
            Instantiate(deadSwag, collision.transform.position, Quaternion.identity);
            gameController.GetComponent<GameController>().deadNpcs++;
        }

        if (collision.gameObject.CompareTag("Buenorra"))
        {
            Destroy(collision.gameObject);
            //scream1.Play();
            Instantiate(blood, collision.transform.position, Quaternion.identity);
            Instantiate(deadBuenorra, collision.transform.position, Quaternion.identity);
            gameController.GetComponent<GameController>().deadNpcs++;
        }

        if (collision.gameObject.CompareTag("Calvo"))
        {
            Destroy(collision.gameObject);
            //scream1.Play();
            Instantiate(blood, collision.transform.position, Quaternion.identity);
            Instantiate(deadCalvo, collision.transform.position, Quaternion.identity);
            gameController.GetComponent<GameController>().deadNpcs++;
        }

        if (collision.gameObject.CompareTag("Megan"))
        {
            Destroy(collision.gameObject);
            //scream1.Play();
            Instantiate(blood, collision.transform.position, Quaternion.identity);
            Instantiate(deadMegan, collision.transform.position, Quaternion.identity);
            gameController.GetComponent<GameController>().deadNpcs++;
        }

        if (collision.gameObject.CompareTag("NPC"))
        {
            GameObject npc = collision.gameObject;
            npc.SetActive(false);
            if (effector != null)
            {
                effector.Play();
            }

            StartCoroutine(ChangeSceneAfterDelay("Menu 1", 1f));

            if (demon2 != null)
            {
                demon2.SetActive(true);
            }

            if (ending != null)
            {
                StartCoroutine(FadeInCanvas(ending));
            }
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

    private IEnumerator FadeInCanvas(Canvas canvas)
    {
        var graphics = canvas.GetComponentsInChildren<UnityEngine.UI.Graphic>();
        float duration = 1f;
        float elapsedTime = 0f;
        canvas.gameObject.SetActive(true);

        foreach (var graphic in graphics)
        {
            var color = graphic.color;
            color.a = 0;
            graphic.color = color;
        }

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / duration);

            foreach (var graphic in graphics)
            {
                var color = graphic.color;
                color.a = alpha;
                graphic.color = color;
            }

            yield return null;
        }
    }

    private IEnumerator ChangeSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}