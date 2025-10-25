using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject eyes;

    public Vector3 targetPosition;
    public float speed = 0;

    public Vector3 eyesTargetPosition;
    public float eyesSpeed = 0;

    private void Start()
    {
        targetPosition = this.transform.position;
        eyesTargetPosition = eyes.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, speed * Time.deltaTime);

        eyes.transform.localPosition = Vector3.MoveTowards(eyes.transform.localPosition, eyesTargetPosition, eyesSpeed * Time.deltaTime);
    }
}
