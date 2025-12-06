using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    private float speed;

    public int sign;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range(1,5);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(speed * sign, 0, 0) * Time.deltaTime;
    }
}
