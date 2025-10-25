using UnityEngine;

public class Starter : MonoBehaviour
{

    public ControlDialogue manager;

    public string initialDialogue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ControlDialogue.currentDialogueID = initialDialogue;

        manager.StartDialogue();
    }

}
