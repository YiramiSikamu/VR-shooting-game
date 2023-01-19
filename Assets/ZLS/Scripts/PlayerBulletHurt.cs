using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBulletHurt : MonoBehaviour
{
    public float Hurt;
    public GameObject uiHurt;
    // Start is called before the first frame update
    void Start()
    {
        Hurt = 1;
    }
    // Update is called once per frame
    void Update()
    {
        string a = Hurt.ToString();
        uiHurt.GetComponent<TMP_Text>().text = a;
    }
}
