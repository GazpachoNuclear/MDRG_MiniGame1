using UnityEngine;

public class MiniGameManager2 : MonoBehaviour
{

    private float timer;

    private float velocity = 4;

    public GameObject player;
    public bool left;
    public bool right;
    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 110)
        {
            //Change scene to successful
        }

        if (left)
        {
            moveLeft();
        }
        else if (right)
        {
            moveRight();
        }
    }


    public void moveLeft()
    {
        if(player.transform.position.x > -7)
        {
            player.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * velocity;
        }
    }

    public void moveRight()
    {
        if (player.transform.position.x < 7)
        {
            player.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * velocity;
        }
    }
}
