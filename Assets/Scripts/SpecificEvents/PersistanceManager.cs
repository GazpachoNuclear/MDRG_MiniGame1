using UnityEngine;

public class PersistanceManager : MonoBehaviour
{

    public GameObject[] objects;

    public void deactivatePersistents()
    {
        for (int i=0; i<objects.Length; i++)
        {
            objects[i].SetActive(false);
        }
    }

    public void activatePersistents()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(true);
        }
    }
}
