using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed = 0;

    private float timer;
    public bool tremble;
    public float trembleIntensity;
    private Vector3 temporalTargetPosition;

    private void Start()
    {
        targetPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (tremble)
        {
            timer += Time.deltaTime;

            if (timer >= 0.25f)
            {
                temporalTargetPosition = targetPosition + new Vector3(Random.Range(-trembleIntensity, trembleIntensity), Random.Range(-trembleIntensity, trembleIntensity), 0);
                timer = 0;
            }

            this.transform.position = Vector3.MoveTowards(this.transform.position, temporalTargetPosition, speed * Time.deltaTime);
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
