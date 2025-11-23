using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{

    public GameObject contents;

    private int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        index = -1;
    }

    public void Next()
    {
        index++;

        if (index >= contents.transform.childCount)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            CleanPrevious();
            contents.transform.GetChild(index).gameObject.SetActive(true);
        }
    }

    private void CleanPrevious()
    {
        for (int i=0; i<contents.transform.childCount; i++)
        {
            contents.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
