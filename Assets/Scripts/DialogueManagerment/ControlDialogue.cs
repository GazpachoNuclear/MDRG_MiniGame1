using System.Collections;
using UnityEngine;
using TMPro;

public class ControlDialogue : MonoBehaviour
{
    public GameObject dialogueObject;

    public TMP_Text charName;
    public GameObject nameObject;

    public TMP_Text charLine;
    public GameObject lineObject;

    public GameObject decisionPanel;
    public GameObject decisionButton;

    public GameObject nextButton;
    public GameObject allTextButton;

    public static string currentDialogueID;
    public int lineSequence;
    private int index;

    public float typingSpeed;

    private ReadCSV data;
    private EventParser parser;


    public bool fastPass = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = this.gameObject.GetComponent<ReadCSV>();
        parser = this.gameObject.GetComponent<EventParser>();

        typingSpeed = 0.05f;
    }


    public void StartDialogue()
    {
        lineSequence = -1;
        nextButton.SetActive(true);
        dialogueObject.SetActive(true);
        NextLine();
    }


    public void NextLine()
    {
        decisionPanel.SetActive(false);

        index = -1;
        lineSequence++;
        string IDref = currentDialogueID + "_" + lineSequence.ToString();
        for (int i=0; i<data.myStructuredData.rows.Length; i++)
        {
            if (data.myStructuredData.rows[i].parameter[0] == IDref)
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            charName.text = data.myStructuredData.rows[index].parameter[3];
            nameObject.SetActive(data.myStructuredData.rows[index].parameter[3] != "" && data.myStructuredData.rows[index].parameter[3] != null);

            StopAllCoroutines();
            StartCoroutine(TypeSentence(data.myStructuredData.rows[index].parameter[5].Split("***")[0]));
            lineObject.SetActive(data.myStructuredData.rows[index].parameter[5] != "" && data.myStructuredData.rows[index].parameter[5] != null);

            //Check if there are decisions set:
            if (!string.IsNullOrWhiteSpace(data.myStructuredData.rows[index].parameter[4]))
            {
                nextButton.SetActive(false);
                decisionPanel.SetActive(true);

                for (int i = 0; i < data.myStructuredData.rows[index].parameter[4].Split("***").Length; i++)
                {
                    GameObject instance = Instantiate(decisionButton, decisionPanel.transform);
                    instance.GetComponentInChildren<TMP_Text>().text = data.myStructuredData.rows[index].parameter[5].Split("***")[i+1];
                    instance.GetComponent<DecisionButton>().targetDialogue = data.myStructuredData.rows[index].parameter[4].Split("***")[i];
                }
            }

            //Check if there are action events:
            if (!string.IsNullOrWhiteSpace(data.myStructuredData.rows[index].parameter[2]))
            {
                parser.parseEvent(data.myStructuredData.rows[index].parameter[2]);
            }
        }
        else
        {
            EndDialogue();
        }

        if (fastPass)
        {
            typingSpeed = 0;
        }
    }

    IEnumerator TypeSentence (string line)
    {
        charLine.text = "";
        allTextButton.SetActive(true);

        foreach (char letter in line.ToCharArray())
        {
            
            charLine.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        allTextButton.SetActive(false);

        if (fastPass && nextButton.activeSelf)
        {
            NextLine();
        }
    }


    public void EndDialogue()
    {
        nextButton.SetActive(false);
        dialogueObject.SetActive(false);

        if (fastPass)
        {
            fastPass = false;
            typingSpeed = 0.05f;
        }
    }


    public void DecisionsCleanUp()
    {
        for (int i=0; i < decisionPanel.transform.childCount; i++)
        {
            Destroy(decisionPanel.transform.GetChild(i).gameObject);
        }
    }


    public void setAllText()
    {
        StopAllCoroutines();
        charLine.text = data.myStructuredData.rows[index].parameter[5].Split("***")[0];
        allTextButton.SetActive(false);
    }

    public void FastPass()
    {
        fastPass = true;
        typingSpeed = 0;
    }
}
