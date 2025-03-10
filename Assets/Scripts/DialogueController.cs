using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueController : MonoBehaviour
{
    public static DialogueController instance;
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField, TextArea(3, 6)] private string[] dialogueLines;

    public bool isPlayerInRange;
    public bool isDialogueActive;
    public int lineIndex;

    private float typingTime = 0.06f;
    private bool isTyping;

    private void Start()
    {
        instance = this;
        StartDialogue();
    }

    public void StartDialogue()
    {
        isDialogueActive = true;
        dialogueCanvas.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private IEnumerator ShowLine()
    {
        isTyping = true;
        typingTime = 0.06f;

        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
        isTyping = false;
        yield return new WaitForSeconds(3);
        dialogueCanvas.SetActive(false);
        isDialogueActive = false;
        lineIndex = 0;
        typingTime = 0.06f;
    }

    /*public void NextText()
    {
        if (isTyping)
        {
            typingTime = 0;
        }
        else
        {
            lineIndex++;
            if (lineIndex < dialogueLines.Length)
            {
                StartCoroutine(ShowLine());
            }
            else
            {
                dialogueCanvas.SetActive(false);
                isDialogueActive = false;
                lineIndex = 0;
                typingTime = 0.06f;
                isDialogueActive = false;
            }
        }
    }*/
}
