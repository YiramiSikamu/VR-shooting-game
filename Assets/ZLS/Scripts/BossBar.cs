using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    Image healthBar;
    //public 有hp的那个类名 es;
    public BossHp PlayerHp;
    public float healthRate;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthRate = PlayerHp.GetHealthRate();
        healthBar.fillAmount = healthRate;
    }
}
