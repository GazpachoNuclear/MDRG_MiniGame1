using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Next scene, you fail
        ControlDialogue.currentDialogueID = "Sled_0";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
