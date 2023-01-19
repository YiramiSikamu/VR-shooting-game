using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBoss : MonoBehaviour
{
    public float speed;

    private Vector3 dir;
    private bool modeC;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        i = 0;
        modeC = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {  //检测P按键按下的次数，实现状态的切换
            i++;
        }
        if (i % 2 == 1)
        {
            modeC = true;
        }
        else {
            modeC = false;
        }

        if (modeC)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                dir = new Vector3(1, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                dir = new Vector3(-1, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                dir = new Vector3(0, 1, 0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                dir = new Vector3(0, -1, 0);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                dir = new Vector3(0, 0, 1);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                dir = new Vector3(0, 0, -1);
            }
        }
        else {
            dir = new Vector3(0, 0, 0);
        }


        transform.position += dir * speed * Time.deltaTime;
    }
}
