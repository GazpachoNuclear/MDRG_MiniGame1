using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public MiniGameManager manager;

    public GameObject prefab;

    private float timer = 0;

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer > 3 && GameObject.FindGameObjectsWithTag("Enemy").Length < 10)
        {
            timer = 0;
            int index = Random.Range(0, 12);
            GameObject instance = Instantiate(prefab, this.transform.position + new Vector3(Random.Range(-8f,8f),Random.Range(-1.3f,2f),0), Quaternion.identity);
            float scaleFactor = instance.transform.position.y * (-1/3.3f) * 0.5f;
            instance.GetComponent<TargetBehaviour>().visual.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);
            instance.GetComponent<TargetBehaviour>().manager = manager;
        }

    }
}
