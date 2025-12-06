using UnityEngine;
using UnityEngine.UI;

public class TargetBehaviour : MonoBehaviour
{

    public GameObject visual;

    public GameObject hitObject;

    public Image countdown;

    private float timer = 0;
    private float maxTime = 5;

    public MiniGameManager manager;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= maxTime)
        {
            manager.TakeDamage();
            timer = 0;
        }
        else
        {
            countdown.fillAmount = 1 - timer / maxTime;
        }
    }

    public void Eliminate()
    {
        if (manager.ammo > 0 && !manager.covered)
        {
            manager.ammo--;
            manager.UpdateUIammo();
            GameObject instance = Instantiate(hitObject, this.transform.position, this.transform.rotation);
            instance.transform.localScale = visual.transform.localScale;
            instance.GetComponentInChildren<SpriteRenderer>().sortingOrder = visual.GetComponent<SpriteRenderer>().sortingOrder;
            Destroy(instance, 1);
            Destroy(this.gameObject);
        }
    }
}
