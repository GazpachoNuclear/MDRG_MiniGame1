using UnityEngine;

public class MiniGameDeactivator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject.FindGameObjectWithTag("PersistanceManager").GetComponent<PersistanceManager>().activatePersistents();
    }
}
