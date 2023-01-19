using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIjiantou : MonoBehaviour
{
    public GameObject Boss;
    public GameObject jiantou;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jiantou.transform.LookAt(Boss.transform);
    }
}
