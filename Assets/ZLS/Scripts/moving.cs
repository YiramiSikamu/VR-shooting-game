using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    // Use this for initialization

    private Transform player;

    public float attackDistance = 10;//停下来攻击的距离

    public float chaseDistance = 20;//追击距离

    private Animator animator;

    public float speed;

    private CharacterController cc;

    public float attackTime = 3;   //设置定时器时间 3秒攻击一次

    private float attackCounter = 0; //计时器变量

    public bool ifmove = true;

    public bool rush = false;//准备冲刺

    public int rushoffsetRange = 10;//擦过玩家时与玩家的偏差范围

    public int rushspeed = 30;//冲刺速度

    private bool rushing = false;//正在冲刺

    private Vector3 direction;

    public float height;

    public bool ifrise;

    public float risingspeed;

    private float TIMER = 0;
    private float Timer = 0;




    void Start()
    {
        ifmove = false;
        rush = false;
        ifrise = true;

        this.GetComponent<floating>().Stop();

        player = GameObject.FindGameObjectWithTag("Player").transform;


        attackCounter = attackTime;//一开始只要抵达目标立即攻击

    }



    // Update is called once per frame

    void Update()
    {
        if (ifrise)
        {
            Vector3 targetPos = transform.position;
            targetPos.y = height;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * risingspeed);
            if (transform.position.y == height)
            {
                if (Timer >= 2)
                {
                    ifrise = false;
                    rush = true;
                    Timer = 0;
                }
               
                   

                    
                
                Timer += Time.deltaTime;

               
            }
        }
        else
        {
            Vector3 targetPos = player.position;

            targetPos = this.GetComponent<floating>().confinedPos(targetPos);

            //targetPos.y = transform.position.y;//此处的作用将自身的Y轴值赋值给目标Y值

            transform.LookAt(targetPos);//旋转的时候就保证已自己Y轴为轴心旋转

            float distance = Vector3.Distance(targetPos, transform.position);

            if (ifmove)
            {
                if (distance >= attackDistance)

                {

                    this.GetComponent<floating>().Stop();

                    transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);

                }
                else
                {

                    ifmove = false;

                    this.GetComponent<floating>().Play();

                }
            }
            else if (!rushing)
            {

                //每秒执行一次操作

                if (TIMER >= 3)

                {
                    if(Random.Range(1,4)>=1){
                        rush=true;
                        ifmove=false;
                        this.GetComponent<floating>().Stop();

                    }

                    TIMER = 0;
                }
                TIMER += Time.deltaTime;

                /*if (distance >= chaseDistance)
                {
                    
                    this.GetComponent<floating>().Stop();

                    ifmove = true;
                    
                }*/


            }

            if (rush)
            {

                float offsetx = Random.Range(3, rushoffsetRange);
                float offsety = Random.Range(3, rushoffsetRange);
                float offsetz = Random.Range(3, rushoffsetRange);

                Vector3 goal = player.position + new Vector3(offsetx, offsety, offsetz);

                direction = goal + (goal - transform.position) / 2;

                direction = this.GetComponent<floating>().confinedPos(direction);

                transform.position = Vector3.MoveTowards(transform.position, direction, Time.deltaTime * rushspeed);

                this.GetComponent<floating>().Stop();

                ifmove = false;

                rush = false;

                rushing = true;

            }

            if (rushing)
            {
                transform.position = Vector3.MoveTowards(transform.position, direction, Time.deltaTime * rushspeed);

                if (Vector3.Distance(direction, transform.position) <= 5)
                {
                    rushing = false;
                    
                        this.GetComponent<floating>().Play();
                    
                }
            }
        }
    }
}
