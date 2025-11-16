using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public Slider health;
    public TMP_Text UIammo;

    public GameObject UIcover;
    public GameObject UIuncover;
    public GameObject Hit;

    public Camera auxCam;

    public int ammo = 5;

    public bool covered = false;

    private float timer = 0;
    private float timer2 = 0;

    private float playtime = 134;

    private void Start()
    {
        auxCam.GetComponent<CameraMovement>().speed = 12;
        auxCam.GetComponent<CameraMovement>().tremble = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        if (covered && timer > 0.5f)
        {
            if (ammo < 5)
            {
                ammo++;
                UpdateUIammo();
                timer = 0;
            }
        }

        if (timer2 > playtime)
        {
            //Next scene, you won
            ControlDialogue.currentDialogueID = "Snowday_4";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void TakeCover()
    {
        covered = true;
        
        UIcover.SetActive(false);
        UIuncover.SetActive(true);

        timer = 0;

        auxCam.GetComponent<CameraMovement>().targetPosition = new Vector3(0, -8, -10);
    }

    public void LeaveCover()
    {
        covered = false;

        UIcover.SetActive(true);
        UIuncover.SetActive(false);

        auxCam.GetComponent<CameraMovement>().targetPosition = new Vector3(0, 0, -10);
    }

    public void TakeDamage()
    {
        if (!covered)
        {
            Hit.GetComponent<Animator>().SetTrigger("Hit");
            health.value--;
        }

        if (health.value < 0)
        {
            //Next scene, you failed
            ControlDialogue.currentDialogueID = "Snowday_3";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void UpdateUIammo()
    {
        UIammo.text = "x" + ammo.ToString();
    }
}
