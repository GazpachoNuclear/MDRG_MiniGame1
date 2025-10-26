using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGameManager : MonoBehaviour
{
    public Slider health;
    public TMP_Text UIammo;

    public GameObject UIcover;
    public GameObject UIuncover;

    public int ammo = 5;

    public bool covered = false;

    private float timer = 0;
    private float timer2 = 0;

    private float playtime = 134;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        if (covered && timer > 0.5f)
        {
            if (ammo < 5)
            {
                ammo++;
                timer = 0;
            }
        }

        if (timer2 > playtime)
        {
            //next scene!
        }
    }

    public void TakeCover()
    {
        covered = true;
        
        UIcover.SetActive(false);
        UIuncover.SetActive(true);

        timer = 0;
    }

    public void LeaveCover()
    {
        covered = false;

        UIcover.SetActive(true);
        UIuncover.SetActive(false);
    }

    public void TakeDamage()
    {
        if (!covered)
        {
            health.value--;
        }

        if (health.value < 0)
        {
            //next scene!
        }
    }
}
