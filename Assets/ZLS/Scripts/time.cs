using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class time : MonoBehaviour
{
    int hour;
    int minute;
    int second;
    int millisecond;

    // 已经花费的时间
    float timeSpend = 0.0f;
    /*
    public GameObject Showtime_p;
    public GameObject Showtime_d;
    public GameObject Showtime_w;*/

    // 显示时间区域的文本
    public GameObject uiTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeSpend += Time.deltaTime;
        /*Showtime_p.GetComponent<showtime>().timenow = timeSpend;
        Showtime_d.GetComponent<showtime>().timenow = timeSpend;
        Showtime_w.GetComponent<showtime>().timenow = timeSpend;*/

        hour = (int)timeSpend / 3600;
        minute = ((int)timeSpend - hour * 3600) / 60;
        second = (int)timeSpend - hour * 3600 - minute * 60;
        //millisecond = (int)((timeSpend - (int)timeSpend) * 1000);

        uiTime.GetComponent<TMP_Text>().text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
        
    }
}
