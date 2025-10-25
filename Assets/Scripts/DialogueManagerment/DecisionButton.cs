using UnityEngine;

public class DecisionButton : MonoBehaviour
{

    private ControlDialogue dialogueManager;

    public string targetDialogue;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<ControlDialogue>();
    }

    public void LaunchNewDialogue()
    {
        ControlDialogue.currentDialogueID = targetDialogue;
        dialogueManager.DecisionsCleanUp();
        dialogueManager.StartDialogue();
        dialogueManager.nextButton.SetActive(true);
    }
}
