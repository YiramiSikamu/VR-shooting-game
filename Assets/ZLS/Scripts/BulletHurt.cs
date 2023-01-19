using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletHurt : MonoBehaviour
{
    public int hurt;
    public GameObject uiHurt;
    // Start is called before the first frame update
    void Start()
    {
        hurt = 1;
    }

    // Update is called once per frame
    void Update()
    {
        string a = hurt.ToString();
        uiHurt.GetComponent<TMP_Text>().text = a;
    }

}
