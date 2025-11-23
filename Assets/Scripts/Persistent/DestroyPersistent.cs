using UnityEngine;

public class DestroyPersistent : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(GameObject.FindGameObjectWithTag("Persistent"));
    }
}
