using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager2 : MonoBehaviour
{

    private float timer;

    private float velocity = 4;

    public GameObject player;
    public bool left;
    public bool right;

    public Camera auxCam;

    private void Start()
    {
        auxCam.GetComponent<CameraMovement>().speed = 0.2f;
        auxCam.GetComponent<CameraMovement>().trembleIntensity = 0.2f;
        auxCam.GetComponent<CameraMovement>().tremble = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 110)
        {
            //Next scene, you won
            ControlDialogue.currentDialogueID = "Sled_1";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (left)
        {
            moveLeft();
        }
        else if (right)
        {
            moveRight();
        }
    }


    public void moveLeft()
    {
        if(player.transform.position.x > -7)
        {
            player.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * velocity;
        }
    }

    public void moveRight()
    {
        if (player.transform.position.x < 7)
        {
            player.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * velocity;
        }
    }
}
