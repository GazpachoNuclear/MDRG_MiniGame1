using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MiniGameManager2 : MonoBehaviour
{

    private float timer;

    private float velocity = 4;

    public GameObject player;
    public bool left;
    public bool right;

    public Camera auxCam;

    public Slider progress;

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
        else
        {
            progress.value = 110 - timer;
        }

        if (left)
        {
            moveLeft();
            player.GetComponentInChildren<Animator>().SetBool("Left", true);
        }
        else if (right)
        {
            moveRight();
            player.GetComponentInChildren<Animator>().SetBool("Right", true);
        }
        else
        {
            player.GetComponentInChildren<Animator>().SetBool("Left", false);
            player.GetComponentInChildren<Animator>().SetBool("Right", false);
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

    public void InputL(InputAction.CallbackContext context)
    {
        if (context.control.IsPressed())
        {
            left = true;
        }
        else
        {
            left = false;
        }
    }

    public void InputR(InputAction.CallbackContext context)
    {
        if (context.control.IsPressed())
        {
            right = true;
        }
        else
        {
            right = false;
        }
    }
}
