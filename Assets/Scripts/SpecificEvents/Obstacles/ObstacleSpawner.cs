using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject tree;

    private float timer;
    private float baseRandomPosition;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2.5f)
        {
            baseRandomPosition = Random.Range(-7, 7);
            for (int i=0; i < Random.Range(1, 3); i++)
            {
                GameObject instance = Instantiate(tree, new Vector3(baseRandomPosition + (5.5f*i), 0, 0), Quaternion.identity);
                Destroy(instance, 3f);
            }

            timer = 0;
        }
    }
}
