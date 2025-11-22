using UnityEngine;

public class MiniGameActivator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject.FindGameObjectWithTag("PersistanceManager").GetComponent<PersistanceManager>().deactivatePersistents();
        GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<ControlDialogue>().EndDialogue();
    }
}
