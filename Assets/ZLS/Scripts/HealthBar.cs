using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image healthBar;
    //public 有hp的那个类名 es;
    public PlayerHp PlayerHp;
    public float healthRate;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1/120f;
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthRate = PlayerHp.GetHealthRate();
        if (healthBar.fillAmount > healthRate+0.009f)
        {
            healthBar.fillAmount -= speed;
        }
        else if(healthBar.fillAmount < healthRate-0.009f)
        {
            healthBar.fillAmount += speed;
        }
        //healthBar.fillAmount = healthRate;
    }
}
