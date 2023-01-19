using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floating : MonoBehaviour
{
    public Vector3 offset;  //最大的偏移量

    public float frequency;  //振动频率

    private Vector3 originPosition; //记录物体的原始坐标

    private float tick;      // 用于计算当前时间量（可以理解成函数坐标轴x轴）

    private float amplitude;  //物体的振幅

    public bool animate;

    public GameObject Player;

    public Vector3 posmin;//地图左下角

    public Vector3 posmax;//地图右上角

    private bool MIN(float a,float b){
        if(a<b){
            return true;
        }
        else{
            return false;
        }
    }

    private bool MAX(float a,float b){
        if(a<b){
            return false;
        }
        else{
            return true;
        }
    }



    public Vector3 confinedPos(Vector3 pos){
        if (MIN(pos.x,posmin.x)){
            pos.x=posmin.x;
        }else if(MAX(pos.x,posmax.x)){
            pos.x=posmax.x;
        }
        if (MIN(pos.y,posmin.y)){
            pos.y=posmin.y;
        }else if(MAX(pos.y,posmax.y)){
            pos.y=posmax.y;
        }
        if (MIN(pos.z,posmin.z)){
            pos.z=posmin.z;
        }else if(MAX(pos.z,posmax.z)){
            pos.z=posmax.z;
        }
        return pos;
    }
    private void Awake()

    {

        //如果没有设置频率或者设置频率为0则自动记录成1

        if (Mathf.Approximately(frequency, 0))

            frequency = 1f;

        originPosition = transform.localPosition;

        tick = Random.Range(0f, 2f * Mathf.PI);

        //计算振幅

        amplitude = 2 * Mathf.PI / frequency;

        animate = true ;

    }


public void changeit(){
    offset.x=Random.Range(-100,100);
    offset.y=Random.Range(-100,100);
    offset.z=Random.Range(-100,100);

    originPosition = Player.transform.localPosition + offset;

    originPosition=confinedPos(originPosition);



}
    public void Play()

    {   

        originPosition= Player.transform.localPosition;
        originPosition=confinedPos(originPosition);

        animate = true;

    }

    public void Stop()

    {


        animate = false;

    }

    private void FixedUpdate()

    {

        float speed=Random.Range(2f,8f);

        if(Random.Range(1,1000)>950){
            changeit();
        }
        if (animate)

        {


            //计算下一个时间量

            tick = tick + Time.fixedDeltaTime * amplitude;

            //计算下一个偏移量

            var amp = new Vector3(Mathf.Cos(tick) * offset.x, Mathf.Sin(tick) * offset.y, Mathf.Sin(tick) * offset.z);

            // 更新坐标
            transform.position = Vector3.MoveTowards(transform.position, originPosition + amp, Time.deltaTime * speed);

        }

    }
}
