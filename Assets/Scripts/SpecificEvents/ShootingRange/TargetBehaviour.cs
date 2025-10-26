using UnityEngine;
using UnityEngine.UI;

public class TargetBehaviour : MonoBehaviour
{

    public GameObject visual;

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
        if (manager.ammo > 0)
        {
            Destroy(this.gameObject);
        }
    }
}
