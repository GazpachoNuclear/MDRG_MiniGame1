using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EventParser : MonoBehaviour
{
    private string[] commands;
    private string[] commandSegments;

    public AudioSource music;
    public AudioSource sfx;

    private GameObject mainCamera;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void parseEvent(string input)
    {
        commands = input.Split("***");

        for (int i=0; i<commands.Length; i++)
        {
            commandSegments = commands[i].Split("_");

            switch (commandSegments[0])
            {
                case "Create":
                    CreateObject(commandSegments[1], commandSegments[2]);
                    break;
                case "Destroy":
                    DestroyObject(commandSegments[1]);
                    break;
                case "Move":
                    MoveObject(commandSegments[1], commandSegments[2]);
                    break;
                case "Scale":
                    ScaleObject(commandSegments[1], commandSegments[2]);
                    break;
                case "Eyesmove":
                    MoveEyes(commandSegments[1], commandSegments[2]);
                    break;
                case "Spritechange":
                    SpriteChangeObject(commandSegments[1], commandSegments[2]);
                    break;
                case "Animate":
                    AnimateObject(commandSegments[1], commandSegments[2]);
                    break;
                case "Changescene":
                    ChangeScene(commandSegments[1]);
                    break;
                case "Playmusic":
                    PlayMusic(commandSegments[1]);
                    break;
                case "PlaySFX":
                    PlaySFX(commandSegments[1]);
                    break;
                case "Wait": //Not working properly because the UI button skips the waiting
                    StartCoroutine(WaitTime(commandSegments[1]));
                    break;
                case "Camera":
                    switch (commandSegments[1])
                    {
                        case "move":
                            CameraMove(commandSegments[2]);
                            break;
                        case "rotate":
                            CameraRotate(commandSegments[2]);
                            break;
                        case "zoom":
                            CameraZoom(commandSegments[2]);
                            break;
                        case "tremble":
                            CameraTremble(commandSegments[2]);
                            break;
                        case "trembleOff":
                            CameraTrembleOff();
                            break;
                    }
                    break;
                case "Dialogue":
                    switch (commandSegments[1])
                    {
                        case "speed":
                            SetDialogueSpeed(commandSegments[2]);
                            break;
                        case "change":
                            string targetDialogue = "";
                            for (int j=2; j<commandSegments.Length; j++)
                            {
                                targetDialogue += commandSegments[j];
                                if (j != commandSegments.Length-1)
                                {
                                    targetDialogue += "_";
                                }
                            }
                            ChangeDialogue(targetDialogue);
                            break;
                    }
                    break;
            }
        }
    }

    private GameObject FindObject(string name)
    {
        GameObject target = GameObject.Find(name);
        return target;
    }

    private void CreateObject(string name, string parameters)
    {
        var target = Resources.Load<GameObject>("Prefabs/" + name);
        Vector3 targetPosition = new Vector3(float.Parse(parameters.Split(",")[0], new System.Globalization.CultureInfo("en-US")), float.Parse(parameters.Split(",")[1], new System.Globalization.CultureInfo("en-US")), float.Parse(parameters.Split(",")[2], new System.Globalization.CultureInfo("en-US")));

        if (target != null)
        {
            GameObject instance = Instantiate(target,targetPosition,Quaternion.identity);
            instance.name = name;
        }
    }

    private void DestroyObject(string name)
    {
        Destroy(FindObject(name));
    }

    private void MoveObject(string name, string parameters)
    {
        GameObject target = FindObject(name);
        Vector3 targetPosition = new Vector3(float.Parse(parameters.Split(",")[0], new System.Globalization.CultureInfo("en-US")), float.Parse(parameters.Split(",")[1], new System.Globalization.CultureInfo("en-US")), float.Parse(parameters.Split(",")[2], new System.Globalization.CultureInfo("en-US")));
        float speed = float.Parse(parameters.Split(",")[3]);

        target.GetComponent<Movement>().targetPosition = targetPosition;
        target.GetComponent<Movement>().speed = speed;
    }

    private void ScaleObject(string name, string parameters)
    {
        GameObject target = FindObject(name);
        Vector3 targetScale = new Vector3(float.Parse(parameters.Split(",")[0], new System.Globalization.CultureInfo("en-US")), float.Parse(parameters.Split(",")[1], new System.Globalization.CultureInfo("en-US")), float.Parse(parameters.Split(",")[2], new System.Globalization.CultureInfo("en-US")));

        target.transform.localScale = targetScale;
    }

    private void MoveEyes(string name, string parameters)
    {
        GameObject target = FindObject(name);
        Vector3 targetPosition = new Vector3(float.Parse(parameters.Split(",")[0], new System.Globalization.CultureInfo("en-US")), float.Parse(parameters.Split(",")[1], new System.Globalization.CultureInfo("en-US")), float.Parse(parameters.Split(",")[2], new System.Globalization.CultureInfo("en-US")));
        float speed = float.Parse(parameters.Split(",")[3]);

        target.GetComponent<Movement>().eyesTargetPosition += targetPosition;
        target.GetComponent<Movement>().eyesSpeed = speed;
    }

    private void SpriteChangeObject(string name, string parameters)
    {
        GameObject target = FindObject(name);
        target.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Visuals/CharactersCloseUp/" + parameters);
    }

    private void AnimateObject(string name, string parameters)
    {
        GameObject target = FindObject(name);
        target.GetComponent<Animator>().SetTrigger(parameters);
    }

    private void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    private void PlayMusic(string name)
    {
        music.Stop();
        music.PlayOneShot(Resources.Load<AudioClip>("Audio/Music/" + name));
    }

    private void PlaySFX(string name)
    {
        sfx.Stop();
        sfx.PlayOneShot(Resources.Load<AudioClip>("Audio/SFX/" + name));
    }

    private void CameraMove(string parameters)
    {
        Vector3 targetPosition = new Vector3(float.Parse(parameters.Split(",")[0], new System.Globalization.CultureInfo("en-US")), float.Parse(parameters.Split(",")[1], new System.Globalization.CultureInfo("en-US")), float.Parse(parameters.Split(",")[2], new System.Globalization.CultureInfo("en-US")));
        float speed = float.Parse(parameters.Split(",")[3]);

        mainCamera.GetComponent<CameraMovement>().targetPosition = targetPosition;
        mainCamera.GetComponent<CameraMovement>().speed = speed;
    }

    private void CameraRotate(string parameters)
    {
        mainCamera.transform.eulerAngles = new Vector3(0, 0, float.Parse(parameters.Split(",")[0], new System.Globalization.CultureInfo("en-US")));
        //pending progressive
    }

    private void CameraZoom(string parameters)
    {
        mainCamera.GetComponent<Camera>().orthographicSize = float.Parse(parameters, new System.Globalization.CultureInfo("en-US"));
    }

    private void CameraTremble(string parameters)
    {
        mainCamera.GetComponent<CameraMovement>().tremble = true;
        mainCamera.GetComponent<CameraMovement>().trembleIntensity = float.Parse(parameters.Split(",")[0], new System.Globalization.CultureInfo("en-US"));
        mainCamera.GetComponent<CameraMovement>().speed = float.Parse(parameters.Split(",")[1], new System.Globalization.CultureInfo("en-US"));
    }

    private void CameraTrembleOff()
    {
        mainCamera.GetComponent<CameraMovement>().tremble = false;
    }

    IEnumerator WaitTime(string parameters)
    {
        Debug.Log("Waiting");
        float time = float.Parse(parameters, new System.Globalization.CultureInfo("en-US"));
        yield return new WaitForSeconds(time);
        Debug.Log("Not waiting anymo");

    }


    private void SetDialogueSpeed(string parameters)
    {
        this.GetComponent<ControlDialogue>().typingSpeed = float.Parse(parameters, new System.Globalization.CultureInfo("en-US"));
    }

    private void ChangeDialogue(string parameters)
    {
        ControlDialogue.currentDialogueID = parameters;
        this.GetComponent<ControlDialogue>().StartDialogue();
    }

}
