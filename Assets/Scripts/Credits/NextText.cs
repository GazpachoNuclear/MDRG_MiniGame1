using UnityEngine;

public class NextText : MonoBehaviour
{
    public CreditsManager manager;

    public void NextElement()
    {
        manager.Next();
    }
}
