using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueController : MonoBehaviour
{
    public static DialogueController instance;
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField, TextArea(3, 6)] private string[] dialogueLines;
    
    public bool isDialogueActive;
    public int lineIndex;

    private float typingTime = 0.06f;
    private bool isTyping;

    private void Start()
    {
        instance = this;
    }

    public void StartDialogue0()
    {
        isDialogueActive = true;
        dialogueCanvas.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }
    
    public void StartDialogue1()
    {
        isDialogueActive = true;
        dialogueCanvas.SetActive(true);
        lineIndex = 1;
        StartCoroutine(ShowLine());
    }
    
    public void StartDialogue2()
    {
        isDialogueActive = true;
        dialogueCanvas.SetActive(true);
        lineIndex = 2;
        StartCoroutine(ShowLine());
    }

    public void StartDialogue3()
    {
        isDialogueActive = true;
        dialogueCanvas.SetActive(true);
        lineIndex = 3;
        StartCoroutine(ShowLine());
    }

    public void StartDialogue4()
    {
        isDialogueActive = true;
        dialogueCanvas.SetActive(true);
        lineIndex = 4;
        StartCoroutine(ShowLine());
    }

    private IEnumerator ShowLine()
{
    isTyping = true;
    typingTime = 0.03f;

    dialogueText.text = string.Empty;

    foreach (char ch in dialogueLines[lineIndex])
    {
        dialogueText.text += ch;
        yield return new WaitForSeconds(typingTime);
    }

    isTyping = false;
    yield return new WaitForSeconds(1f);

    while (dialogueText.text.Length > 0)
    {
        dialogueText.text = dialogueText.text.Substring(0, dialogueText.text.Length - 1);
        yield return new WaitForSeconds(typingTime);
    }

    yield return new WaitForSeconds(0.5f);

    dialogueCanvas.SetActive(false);
    isDialogueActive = false;
    lineIndex = 0;
}
}