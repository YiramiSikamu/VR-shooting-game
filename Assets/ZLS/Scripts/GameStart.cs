using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public bool gamestart;
    public GameObject newg;
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        gamestart = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("door")) {
            newg.SetActive(false);
            boss.SetActive(true);
        }
    }
}
