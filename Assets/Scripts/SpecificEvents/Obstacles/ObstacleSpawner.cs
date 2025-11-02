using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject tree;

    private float timer;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2.5f)
        {
            for (int i=0; i < Random.Range(1, 4); i++)
            {
                GameObject instance = Instantiate(tree, new Vector3(Random.Range(-7, 7), 0, 0), Quaternion.identity);
                Destroy(instance, 3f);
            }

            timer = 0;
        }
    }
}
