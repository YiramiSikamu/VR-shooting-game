using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showtime : MonoBehaviour
{
    public float timenow;
    public Text text_showtime;

    int hour;
    int minute;
    int second;
    // Start is called before the first frame update
    void Start()
    {
        text_showtime = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        hour = (int)timenow / 3600;
        minute = ((int)timenow - hour * 3600) / 60;
        second = (int)timenow - hour * 3600 - minute * 60;
        //millisecond = (int)((timenow - (int)timenow) * 1000);

        text_showtime.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
    }
}
