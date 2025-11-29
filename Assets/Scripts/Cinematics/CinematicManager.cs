using UnityEngine;

public class CinematicManager : MonoBehaviour
{

    private ControlDialogue manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<ControlDialogue>();
    }

    
    public void StartCinematic()
    {
        manager.dialogueObject.SetActive(false);
    }

    public void EndCinematic()
    {
        manager.dialogueObject.SetActive(true);
        manager.NextLine();

        Destroy(this.gameObject);
    }

}
