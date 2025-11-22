using UnityEngine;

public class Reactivator : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<ControlDialogue>().StartDialogue();
    }

}
