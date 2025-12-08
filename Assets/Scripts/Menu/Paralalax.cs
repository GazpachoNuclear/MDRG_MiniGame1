using UnityEngine;
using UnityEngine.InputSystem;

public class Paralalax : MonoBehaviour
{

    public float paralFactor;

    private float Xoffset;
    private float Yoffset;

    // Update is called once per frame
    void Update()
    {

        Xoffset = (Mouse.current.position.ReadValue().x - (Screen.width * 1.5f)) / (Screen.width/2);
        Yoffset = (Mouse.current.position.ReadValue().y - (Screen.height * 1.5f)) / (Screen.height/2);

        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(Xoffset, Yoffset, 0) * paralFactor, 1);

    }
}
