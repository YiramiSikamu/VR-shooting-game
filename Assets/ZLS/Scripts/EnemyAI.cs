using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Playables;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public Vector3 zheng;
    public GameObject Player;
    //public GameObject PlayerOut;
    public enemySignUI enemySignUI;
    private bool Enemyissuo;    //敌人是否被锁定
    //public int nandunum;
    private Vector3 PE;
    public BossHp BossHp;
    public PlayerHp PlayerHp;
    public PlayerBulletHurt PlayerBulletHurt;
    private float Dis;
    public GameObject Y;
    public GameObject fY;
    public GameObject Z;
    public GameObject fZ;
    public GameObject X;
    public GameObject fX;
    public GameObject Center;
    private bool by;
    private bool bfy;
    private bool bz;
    private bool bfz;
    private bool bx;
    private bool bfx;
    public Vector3 dir;
    private float num;
    public bool once = false;
    public float angularSpeed;
    public float aroundRadius;
    private float angled;
    private float chushiangle;
    //public nandu nandu;
    public bool BossOut;
    public bool Out;
    private Vector3 BC;
    private float runtime;
    private int changenum;
    private float backtime;
    private float backtime2;
    public bool ai;
    private float waittime;
    private bool bigfire;
    public float lotime;
    private float gongzhuantime;
    private float up;
    private bool fardis;
    private bool xuanzhaun;
    private float lofadetime;
    private bool changemode;
    public int i;
    private float floatspeed = 0.1f;
    private float fanhuizhi = 0f;
    private float m = 0;
    private bool lo = false;
    public GameObject Point1;
    public GameObject Point2;
    public GameObject Point3;
    public GameObject Point4;
    private float chongwaiteTime1;
    private float chongwaiteTime2;
    private float chongwaiteTime3;
    private float chongwaiteTime4;
    private float chongwaiteTime5;
    private float chongwaiteTime6;
    public float objdis;
    public float GameAngle;
    public Vector3 zhongzhuan1;
    public Vector3 zhongzhuan2;
    public bool ischong;
    public PlayableDirector playableDirector;
    public float timelineDuration;

    // Start is called before the first frame update
    void Start()
    {
        //nandunum = nandu.num;
        //print(nandunum);
        speed = 5f;
        /*Vector3 p = Player.transform.rotation * Vector3.forward * aroundRadius;
        transform.position = new Vector3(p.x, Player.transform.position.y, p.z);*/
        by = false;
        bfy = false;
        bz = false;
        bfz = false;
        bx = false;
        bfx = false;
        waittime = 7f;
        bigfire = false;
        lofadetime = 5f;
        xuanzhaun = false;
        lotime = 0f;
        chongwaiteTime1 = 12f;
        chongwaiteTime2 = 12f;
        chongwaiteTime3 = 12f;
        chongwaiteTime4 = 12f;
        chongwaiteTime5 = 12f;
        chongwaiteTime6 = 12f;
        ischong = false;
        /*if (nandunum == 2) {
            Vector3 p = Player.transform.rotation * Vector3.forward * aroundRadius;
            transform.position = new Vector3(p.x, Player.transform.position.y, p.z);
        }*/
    }

    //Update is called once per frame
    void Update()
    {
        Enemyissuo = true;
        if (ai) {
            //chushiangle = Vector3.Angle(PlayerOut.transform.forward, (transform.position - Player.transform.position).normalized);
            //print(angled);
            PE = (Player.transform.position - transform.position).normalized;
            Dis = Vector3.Distance(Player.transform.position, transform.position);

            if (waittime >= 0)
            {
                print("1");
                waittime -= Time.deltaTime;
                dir = new Vector3(0, 1, 0);
                speed = 2f;
                transform.position += dir * speed * Time.deltaTime;
            }
            else
            {
                BC = (Center.transform.position - transform.position).normalized;
                print("2");
                if (isOut())
                {
                    print("out");
                    backtime = 3f;
                }

                if (backtime >= 0)
                {
                    print("3");

                    backtime -= Time.deltaTime;
                    dir = BC;
                    speed = 15f;
                    print(dir);
                    transform.position += dir * speed * Time.deltaTime;
                }
                else
                {
                    print("5");
                    if (bigfire == false)
                    {
                        print("6");
                        StartCoroutine(WaitForTimelineToFinish());
                        playableDirector.Play();
                        bigfire = true;
                    }

                    print("7");
                    //fardis = false;
                    if (enemySignUI.issuo)
                    {
                        lotime += Time.deltaTime;
                        lofadetime = 5f;
                    }
                    if (enemySignUI.issuo == false)
                    {
                        lofadetime -= Time.deltaTime;
                    }
                    if (lofadetime <= 0)
                    {
                        lotime = 0;
                        folow();
                    }
                    if (lotime > 3f)
                    {
                        if (runtime >= 0)
                        {
                            runtime -= Time.deltaTime;
                        }
                        else
                        {
                            System.Random rd = new System.Random();
                            changenum = rd.Next(0, 9);
                            zhongzhuan1 = Player.transform.position;
                            zhongzhuan2 = transform.position;
                            runtime = 3f;
                            if (changenum <= 5)
                            {
                                ischong = true;
                            }
                        }

                        switch (changenum)
                        {
                            case 0:
                                chong2(zhongzhuan1, zhongzhuan2);
                                break;
                            case 1:
                                chong2(zhongzhuan1, zhongzhuan2);
                                break;
                            case 2:
                                chong2(zhongzhuan1, zhongzhuan2);
                                break;
                            case 3:
                                chong2(zhongzhuan1, zhongzhuan2);
                                break;
                            case 4:
                                chong2(zhongzhuan1, zhongzhuan2);
                                break;
                            case 5:
                                chong2(zhongzhuan1, zhongzhuan2);
                                break;
                            case 6:
                                folow();
                                break;
                            case 7:
                                folow();
                                break;
                            case 8:
                                folow();
                                break;
                            default:
                                print("没有该行动模式");
                                break;
                        }
                    }
                    /*if (backtime2 >= 0) {
                        print("8");
                        backtime2 -= Time.deltaTime;
                        dir = PE;
                        speed = 5f;
                        transform.position += dir * speed * Time.deltaTime;
                    }*/
                }
            }


            Vector3 right = new Vector3(0, 1, 0);
            transform.rotation = Quaternion.LookRotation(dir, right);
            //transform.forward = dir.normalized;
        }
    }
    /* public void xuanzhaun() {
         float x;
         float y;
         float z;
         x = transform.position.x + 1;
         y = (transform.position.y * PE.y - x * PE.x + transform.position.x * PE.x) / PE.y;
         z = transform.position.z;
         Vector3 vd = new Vector3(x, y, z);
         Vector3 v = vd.normalized;
         dir = v;
     }*/

    IEnumerator WaitForTimelineToFinish()
    {

        timelineDuration = (float)playableDirector.duration;
        //playerObject.canMove = false;
        yield return new WaitForSeconds(timelineDuration);
        //playerObject.canMove = true;


        /*if (!playTimelineOnlyOnce)
        {
            triggerZoneObject.SetActive(true);
        }
        else if (playTimelineOnlyOnce)
        {
            playerInZone = false;
        }

        timelinePlaying = false;*/

    }
    public void zuhechong(GameObject P1, GameObject P2, GameObject P3, GameObject P4,GameObject P5) {
        if (chongwaiteTime1 > 0)
        {
            chongwaiteTime1 -= Time.deltaTime;
        }
        else if (chongwaiteTime1 <= 0 && chongwaiteTime2 > 0)
        {
            chongwaiteTime2 -= Time.deltaTime;
            chong(P1);
        }
        else if (chongwaiteTime2 <= 0 && chongwaiteTime3 > 0)
        {
            chongwaiteTime3 -= Time.deltaTime;
            chong(P2);
        }
        else if (chongwaiteTime3 <= 0 && chongwaiteTime4 > 0)
        {
            chongwaiteTime4 -= Time.deltaTime;
            chong(P3);
        }
        else if (chongwaiteTime4 <= 0 && chongwaiteTime5 > 0)
        {
            chongwaiteTime5 -= Time.deltaTime;
            chong(P4);
        }
        else if (chongwaiteTime5 <= 0 && chongwaiteTime6 > 0)
        {
            chongwaiteTime6 -= Time.deltaTime;
            chong(P5);
        }
    }

    public void chong2(Vector3 p1,Vector3 p2) {
        dir = ((p1 - p2).normalized + new Vector3(0.2f,0.1f,0.1f)).normalized;
        speed = 30f;
        transform.position += dir * speed * Time.deltaTime;
    }

    public float lianxufloat(int max,int min,int i) {

        if (i == 1)
        {
            print(m);
            if (m >= max)
            {
                lo = true;
            }
            if (m <= min)
            {
                lo = false;
            }
            if (lo == false)
            {
                fanhuizhi += floatspeed;
                m += floatspeed;
                return fanhuizhi;
            }
            else
            {
                fanhuizhi -= floatspeed;
                m -= floatspeed;
                return fanhuizhi;
            }
        }
        else {

            return 0;
        }
    }
    public void zxgongzhuan() {
        /*this.transform.LookAt(Player.transform);

        this.transform.Rotate(new Vector3(0, -90, 0));*/
        
        angled += (angularSpeed * Time.deltaTime) % 360;
        float posX = aroundRadius * Mathf.Sin(angled * Mathf.Deg2Rad);
        float posZ = aroundRadius * Mathf.Cos(angled * Mathf.Deg2Rad);

        transform.position = new Vector3(posX, 0, posZ) /*+ Player.transform.position*/ + Player.transform.up * lianxufloat(20,-20,1);
        print(lianxufloat(10, -10, 1));
        print(angled);
        print(Player.transform.up * lianxufloat(20, -20, 1));
    }

    public void xygongzhuan() {
        angled += (angularSpeed * Time.deltaTime) % 360;
        float posX = aroundRadius * Mathf.Sin(angled * Mathf.Deg2Rad);
        float posY = aroundRadius * Mathf.Cos(angled * Mathf.Deg2Rad);

        transform.position = new Vector3(posX, posY, 0) + Player.transform.position;
    }

    public void zygongzhuan() {
        angled += (angularSpeed * Time.deltaTime) % 360;
        float posZ = aroundRadius * Mathf.Sin(angled * Mathf.Deg2Rad);
        float posY = aroundRadius * Mathf.Cos(angled * Mathf.Deg2Rad);

        transform.position = new Vector3(0, posY, posZ) + Player.transform.position ;
    }

    public void xyzgongzhuan1() {
        /*System.Random rd = new System.Random();
        aroundRadius = rd.Next(10, 40);*/
        angled += (angularSpeed * Time.deltaTime) % 180;
        float posX = aroundRadius* Mathf.Sin(angled * Mathf.Deg2Rad);
        float posY = aroundRadius * Mathf.Cos(angled * Mathf.Deg2Rad);
        float posZ = aroundRadius * Mathf.Sin(angled * Mathf.Deg2Rad);
        transform.position = new Vector3(posX, posY, posZ) + Player.transform.position;
    }
    public void changemodeaction() {


        if (num == 0)
        {
            xygongzhuan();
        }
        else if (num == 1)
        {
            zxgongzhuan();
        }
        else if (num == 2)
        {
            zygongzhuan();
        }
        else if (num == 3)
        {
            zuhechong(Point1, Point2, Point3, Point4, Center);
        }
        else if (num == 4)
        {
            z();
        }
        else if (num == 5) {
            folow();
        }
    }

    public void chong(GameObject gameObject) {
        dir = (gameObject.transform.position - transform.position).normalized;
        objdis = Vector3.Distance(gameObject.transform.position, transform.position); ;
        speed = 20f;
        if (objdis < 0.5) {
            speed = 0;
        }
        print(objdis);
        transform.position += speed * dir * Time.deltaTime;
    }
    public float jilu() {
        if (once == false) {
            num = Dis;
            once = true;
        }
        return num;
    }
    public float jiluAn() {
        if (once == false)
        {
            num = chushiangle;
            once = true;
        }
        return num;
    }
    public void z() {
        dir = new Vector3(0, 0, 1);
        speed = 7f;
        transform.position += dir * speed * Time.deltaTime;
    }
    public void y() {
        dir = new Vector3(0, 1, 0);
        speed = 7f;
        transform.position += dir * speed * Time.deltaTime;
    }
    public void x()
    {
        dir = new Vector3(1, 0, 0);
        speed = 7f;
        transform.position += dir * speed * Time.deltaTime;
    }
    public void fz() {
        dir = new Vector3(0, 0, -1);
        speed = 7f;
        transform.position += dir * speed * Time.deltaTime;
    }
    public void fy() {
        dir = new Vector3(0, -1, 0);
        speed = 7f;
        transform.position += dir * speed * Time.deltaTime;
    }
    public void fx()
    {
        dir = new Vector3(-1, 0, 0);
        speed = 7f;
        transform.position += dir * speed * Time.deltaTime;
    }
    public void folow() {
        dir = PE;
        speed = 9;
        transform.position += dir * speed * Time.deltaTime;
    }

    public bool isOut() {

        if (transform.position.y >= Y.transform.position.y)
        {
            by = true;
        }
        if (transform.position.y < Y.transform.position.y)
        {
            by = false;
        }
        if (transform.position.y >= fY.transform.position.y)
        {
            bfy = false;
        }
        if (transform.position.y < fY.transform.position.y)
        {
            bfy = true;
        }

        if (transform.position.z >= Z.transform.position.z)
        {
            bz = true;
        }
        if (transform.position.z < Z.transform.position.z)
        {
            bz = false;
        }
        if (transform.position.z >= fZ.transform.position.z)
        {
            bfz = false;
        }
        if (transform.position.z < fZ.transform.position.z)
        {
            bfz = true;
        }

        if (transform.position.x >= X.transform.position.x)
        {
            bx = true;
        }
        if (transform.position.x < X.transform.position.x)
        {
            bx = false;
        }
        if (transform.position.x >= fX.transform.position.x)
        {
            bfx = false;
        }
        if (transform.position.x < fX.transform.position.x)
        {
            bfx = true;
        }

        if (by || bfy || bz || bfz || bx || bfx)
        {
            return true;
        }
        else {
            return false;
        }
    }
}
