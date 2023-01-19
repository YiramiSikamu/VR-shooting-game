using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyGameMode : MonoBehaviour
{
    //public BulletCharacter bulletTemplate;
    public Transform firPoint;
    public List<GameObject> tempBullets;
    public Queue<GameObject> bulletQueue;
    public int maxRecycle;
    public int recycleCount;

    public GameObject Anime;
    public moving Move;
    void Start()
    {
        tempBullets = new List<GameObject>();
        bulletQueue = new Queue<GameObject>();
        maxRecycle = 100;

        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        recycleCount = 0;
        if (bulletQueue.Count > 0)
        {
            while (recycleCount < maxRecycle)
            {
                if(bulletQueue.Count <= 0)
                {
                    break;
                }
                if(bulletQueue.Peek().GetComponent<Bullet>().timetodie == true)
                {
                    bulletQueue.Dequeue().GetComponent<Bullet>().Recycle();
                    recycleCount++;
                }
                else
                {
                    break;
                }

            }
        }
        */
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            StartCoroutine(eight());

            yield return new WaitForSeconds(6f);
            StartCoroutine(FirRound(2, 8, 8, firPoint.transform.position));
            StartCoroutine(FirRound(2, 8, 8, firPoint.transform.position + new Vector3(10, -10, 10)));
            StartCoroutine(FirRound(2, 8, 8, firPoint.transform.position + new Vector3(-10, 10, 10)));
            StartCoroutine(FirRound(2, 8, 8, firPoint.transform.position + new Vector3(10, 10, -10)));
            StartCoroutine(FirRound(2, 8, 8, firPoint.transform.position + new Vector3(-10, -10, 10)));
            StartCoroutine(FirRound(2, 8, 8, firPoint.transform.position + new Vector3(-10, 10, -10)));
            StartCoroutine(FirRound(2, 8, 8, firPoint.transform.position + new Vector3(10, -10, -10)));
            StartCoroutine(FirRound(2, 8, 8, firPoint.transform.position + new Vector3(-10, -10, -10)));
            StartCoroutine(FirRound(2, 8, 8, firPoint.transform.position + new Vector3(10, 10, 10)));

            yield return new WaitForSeconds(5f);
            StartCoroutine(FirRoundGroup(2, 9, 16));
            StartCoroutine(zuantou(2));
            StartCoroutine(zuantou(5));

            yield return new WaitForSeconds(7f);
            StartCoroutine(FireBallBulle());

            yield return new WaitForSeconds(6f);
            StartCoroutine(Test(1, 4, 24, 45));
            StartCoroutine(Test(2, 2, 24, 0));

            yield return new WaitForSeconds(8f);
            StartCoroutine(Test4(10, 6, firPoint.position));
            StartCoroutine(Test4(10, 6, firPoint.position + new Vector3(10, -10, 10)));
            StartCoroutine(Test4(10, 6, firPoint.position + new Vector3(-10, 10, 10)));
            StartCoroutine(Test4(10, 6, firPoint.position + new Vector3(10, 10, -10)));
            //StartCoroutine(Test4(12, 10, firPoint.position + new Vector3(-10, -10, 5)));
            StartCoroutine(Test4(10, 6, firPoint.position + new Vector3(10, -10, -10)));
            StartCoroutine(Test4(10, 6, firPoint.position + new Vector3(-10, 10, -10)));
            

            yield return new WaitForSeconds(4f);
            StartCoroutine(zuantou(1));
            StartCoroutine(zuantou(2));
            StartCoroutine(zuantou(3));
            StartCoroutine(zuantou(4));
            StartCoroutine(zuantou(5));
            StartCoroutine(zuantou(6));

            yield return new WaitForSeconds(2f);
            StartCoroutine(Test8(firPoint.position, 5, 10));

            yield return new WaitForSeconds(3f);
            StartCoroutine(Test7(1, 4, 36, 0));

            yield return new WaitForSeconds(2f);
            StartCoroutine(Test9());

            yield return new WaitForSeconds(3f);
            StartCoroutine(followBullet());
            yield return new WaitForSeconds(1f);
            StartCoroutine(followBullet());
            yield return new WaitForSeconds(1f);
            StartCoroutine(followBullet());
        }
    }
    
   /* private void OnGUI()
    {
        if (GUI.Button(new Rect(20, 20, 50, 50), "1"))
        {
            StartCoroutine(eight());
        }

        if (GUI.Button(new Rect(20, 70, 50, 50), "2"))
        {
            StartCoroutine(FirRound(2, 8, 8, firPoint.transform.position));
            StartCoroutine(FirRound(2, 8, 8, firPoint.transform.position + new Vector3(10, -10, 10)));
            StartCoroutine(FirRound(2, 8, 8, firPoint.transform.position + new Vector3(-10, 10, 10)));
            StartCoroutine(FirRound(2, 8, 8, firPoint.transform.position + new Vector3(10, 10, -10)));
            StartCoroutine(FirRound(2, 8, 8, firPoint.transform.position + new Vector3(-10, -10, 10)));
            StartCoroutine(FirRound(2, 8, 8, firPoint.transform.position + new Vector3(-10, 10, -10)));
            StartCoroutine(FirRound(2, 8, 8, firPoint.transform.position + new Vector3(10, -10, -10)));
            StartCoroutine(FirRound(2, 8, 8, firPoint.transform.position + new Vector3(-10, -10, -10)));
            StartCoroutine(FirRound(2, 8, 8, firPoint.transform.position + new Vector3(10, 10, 10)));
        }

        if (GUI.Button(new Rect(20, 120, 50, 50), "3"))
        {

            StartCoroutine(FirRoundGroup(2, 9, 16));
            StartCoroutine(zuantou(2));
            StartCoroutine(zuantou(5));
        }

        if (GUI.Button(new Rect(20, 170, 50, 50), "4"))
        {

            StartCoroutine(FireBallBulle());
        }

        if (GUI.Button(new Rect(20, 220, 50, 50), "5"))
        {
            StartCoroutine(Test(1, 4, 24, 45));
            StartCoroutine(Test(2, 2, 24, 0));
        }
        if (GUI.Button(new Rect(70, 20, 50, 50), "6"))
        {
            StartCoroutine(Test4(10, 6, firPoint.position));
            StartCoroutine(Test4(10, 6, firPoint.position + new Vector3(10, -10, 10)));
            StartCoroutine(Test4(10, 6, firPoint.position + new Vector3(-10, 10, 10)));
            StartCoroutine(Test4(10, 6, firPoint.position + new Vector3(10, 10, -10)));
            //StartCoroutine(Test4(12, 10, firPoint.position + new Vector3(-10, -10, 5)));
            StartCoroutine(Test4(10, 6, firPoint.position + new Vector3(10, -10, -10)));
            StartCoroutine(Test4(10, 6, firPoint.position + new Vector3(-10, 10, -10)));
            StartCoroutine(Test4(10, 6, firPoint.position + new Vector3(-10, -10, -10)));
            StartCoroutine(Test4(10, 6, firPoint.position + new Vector3(10, 10, 10)));

        }
        if (GUI.Button(new Rect(70, 70, 50, 50), "7"))
        {
            StartCoroutine(zuantou(1));
            StartCoroutine(zuantou(2));
            StartCoroutine(zuantou(3));
            StartCoroutine(zuantou(4));
            StartCoroutine(zuantou(5));
            StartCoroutine(zuantou(6));
        }
        if (GUI.Button(new Rect(70, 120, 50, 50), "8"))
        {
            StartCoroutine(Test9());
        }
        if (GUI.Button(new Rect(70, 170, 50, 50), "9"))
        {
            //StopAllCoroutines();
            //ClearBulletsList();
            //StartCoroutine(Test7(1, 4, 36, 0));
        }
        if (GUI.Button(new Rect(70, 220, 50, 50), "10"))
        {
            StartCoroutine(followBullet());
            //StopAllCoroutines();
            //ClearBulletsList();
            //StartCoroutine(Test9());
        }
    }*/
    
    /// <summary>
    /// 发射散弹
    /// </summary>
    /// <returns></returns>
    IEnumerator FirRoundGroup(int dir, int fircount, int seccount)
    {
        Vector3 rotavector = Vector3.zero;
        Vector3 bulletDir = Vector3.zero;
        if (dir == 1)
        {
            bulletDir = firPoint.transform.up;
            rotavector = firPoint.transform.forward;
        }
        if (dir == 2)
        {
            bulletDir = firPoint.transform.forward;
            rotavector = firPoint.transform.right;
        }
        if (dir == 3)
        {
            bulletDir = firPoint.transform.right;
            rotavector = firPoint.transform.up;
        }

        Quaternion rotateQuate = Quaternion.AngleAxis(360 / fircount, rotavector);//使用四元数制造绕Z轴旋转45度的旋转
        List<GameObject> bullets = new List<GameObject>();       //装入开始生成的8个弹幕
        for (int i = 0; i < fircount; i++)
        {
            var tempBullet = CreatBullet(bulletDir, firPoint.transform.position, "Bullet_Boss");
            tempBullet.GetComponent<BulletCharacter>().speed = 10f;
            tempBullet.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/Green");
            bulletDir = rotateQuate * bulletDir; //生成新的子弹后，让发射方向旋转45度，到达下一个发射方向
            bullets.Add(tempBullet);
        }
        yield return new WaitForSeconds(1.0f);   //1秒后在生成多波弹幕
        for (int i = 0; i < bullets.Count; i++)
        {
            bullets[i].GetComponent<BulletCharacter>().speed = 0; //弹幕停止移动
            StartCoroutine(FirRound(dir, 18, 1, bullets[i].transform.position));//通过之前弹幕的位置，生成多波多方向的圆形弹幕
        }
    }

    /// <summary>
    /// 发射圆形弹幕
    /// </summary>
    /// <returns></returns>
    IEnumerator FirRound(int dir, int count, int number, Vector3 creatPoint)
    {
        Vector3 rotavector = Vector3.zero;
        Vector3 bulletDir = Vector3.zero;
        if (dir == 1)
        {
            bulletDir = firPoint.transform.up;
            rotavector = firPoint.transform.forward;
        }
        if (dir == 2)
        {
            bulletDir = firPoint.transform.forward;
            rotavector = firPoint.transform.right;
        }
        if (dir == 3)
        {
            bulletDir = firPoint.transform.right;
            rotavector = firPoint.transform.up;
        }

        Quaternion rotateQuate = Quaternion.AngleAxis(360 / count, rotavector);//使用四元数制造绕Z轴旋转10度的旋转

        for (int i = 0; i < number; i++)    //发射波数
        {
            for (int j = 0; j < count; j++)
            {
                var temp = CreatBullet(bulletDir, creatPoint, "Bullet_Boss");
                temp.GetComponent<BulletCharacter>().speed = 6f;
                temp.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/Yellow");
                bulletDir = rotateQuate * bulletDir; //让发射方向旋转10度，到达下一个发射方向

            }
            yield return new WaitForSeconds(0.2f); //协程延时，0.5秒进行下一波发射
        }
        yield return null;
    }

    /// <summary>
    /// 发射涡轮型弹幕
    /// </summary>
    /// <returns></returns>
    IEnumerator FireTurbine()
    {
        Vector3 bulletDir = firPoint.transform.up;      //发射方向
        Quaternion rotateQuate = Quaternion.AngleAxis(20, firPoint.transform.forward);//使用四元数制造绕Z轴旋转20度的旋转
        float radius = 0.6f;        //生成半径
        float distance = 0.2f;      //每生成一次增加的距离
        for (int i = 0; i < 18; i++)
        {
            Vector3 firePoint = firPoint.transform.position + bulletDir * radius;   //使用向量计算生成位置
            //StartCoroutine(FirRound(1, firePoint));     //在算好的位置生成一波圆形弹幕
            yield return new WaitForSeconds(0.05f);      //延时较小的时间（为了表现效果），计算下一步
            bulletDir = rotateQuate * bulletDir;        //发射方向改变
            radius += distance;     //生成半径增加
        }
    }

    /// <summary>
    /// 发射球形子弹
    /// </summary>
    /// <returns></returns>
    IEnumerator FireBallBulle()
    {
        Vector3 bulletDir = firPoint.transform.up;      //发射方向
        Quaternion rotateQuate = Quaternion.AngleAxis(10, firPoint.transform.forward);//使用四元数制造绕Z轴旋转20度的旋转
        float distance = 1.0f;
        for (int j = 0; j < 8; j++)
        {
            for (int i = 0; i < 36; i++)
            {
                Vector3 creatPoint = firPoint.transform.position + bulletDir * distance;
                var tempBullet = CreatBullet(bulletDir, creatPoint, "Bullet_Boss");
                tempBullet.GetComponent<BulletCharacter>().isMove = false;
                tempBullet.GetComponent<BulletCharacter>().speed = 20f;
                tempBullet.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/Purple");
                StartCoroutine(tempBullet.GetComponent<BulletCharacter>().DirChangeMoveMode(10.0f, 0.4f, 15));
                bulletDir = rotateQuate * bulletDir;
            }
            yield return new WaitForSeconds(0.2f);
        }

        yield return null;
    }
    //花型弹幕
    IEnumerator Test(int dir, int slipcount, int count, int firAngle) //dir=1为前后(up) dir=2为上下(right) dir=3为左右(forward)
                                                                      //slipcount为发射出的条数
                                                                      //count为每波子弹的数量
                                                                      //firAngle为初始偏移角度
    {
        Vector3 bulletDir = Vector3.zero;
        Vector3 rotavector = Vector3.zero;
        Quaternion left30;
        Quaternion right30;
        Quaternion RightRota;
        Quaternion LeftRota;
        if (dir == 1)
        {
            bulletDir = Quaternion.AngleAxis(firAngle, firPoint.transform.forward) * -firPoint.transform.up;
            rotavector = firPoint.transform.forward;
        }
        if (dir == 2)
        {
            bulletDir = Quaternion.AngleAxis(firAngle, firPoint.transform.right) * -firPoint.transform.forward;
            rotavector = firPoint.transform.right;
        }
        if (dir == 3)
        {
            bulletDir = Quaternion.AngleAxis(firAngle, firPoint.transform.up) * -firPoint.transform.right;
            rotavector = firPoint.transform.up;
        }
        left30 = Quaternion.AngleAxis(-30, rotavector);
        right30 = Quaternion.AngleAxis(30, rotavector);
        RightRota = Quaternion.AngleAxis(180 / count, rotavector); //使用四元数制造2个旋转，分别是绕Z轴朝左右旋转30度
        LeftRota = Quaternion.AngleAxis(-180 / count, rotavector);

        Vector3 bulletDir2 = right30 * bulletDir;
        bulletDir = left30 * bulletDir;
        Quaternion rota = Quaternion.AngleAxis(360 / slipcount, rotavector);
        for (int i = 0; i < count; i++)     //散弹发射次数
        {
            for (int n = 0; n < slipcount; n++)
            {
                var temp = CreatBullet(bulletDir, firPoint.transform.position, "Bullet_Boss");
                temp.GetComponent<BulletCharacter>().speed = 10f;
                temp.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/Green");
                var tempBullet = CreatBullet(bulletDir2, firPoint.transform.position, "Bullet_Boss");
                tempBullet.GetComponent<BulletCharacter>().speed = 10f;
                tempBullet.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/Blue");
                bulletDir = rota * bulletDir;
                bulletDir2 = rota * bulletDir2;
            }
            bulletDir = RightRota * bulletDir;
            bulletDir2 = LeftRota * bulletDir2;
            yield return new WaitForSeconds(0.2f); //协程延时，0.5秒进行下一波发射
        }
    }

    //随机弧线弹幕
    IEnumerator Test4(int count, int number, Vector3 creatPoint)//number为发射波数,count为每波子弹数量
    {
        Vector3 bulletDir = firPoint.transform.up;
        //使用四元数制造绕Z轴旋转10度的旋转

        for (int i = 0; i < number; i++)
        {
            Quaternion upRandom = Quaternion.AngleAxis(Random.Range(0, 360), firPoint.transform.up);
            Quaternion rightRandom = Quaternion.AngleAxis(Random.Range(0, 360), firPoint.transform.right);
            Quaternion forwardRandom = Quaternion.AngleAxis(Random.Range(0, 360), firPoint.transform.forward);
            bulletDir = upRandom * rightRandom * forwardRandom * bulletDir;
            Quaternion rotateQuate = Quaternion.AngleAxis(10, upRandom * rightRandom * forwardRandom * firPoint.transform.forward);
            for (int j = 0; j < count; j++)
            {
                var tempBullet = CreatBullet(bulletDir, creatPoint, "Bullet_Star");
                if (i % 2 != 0)
                {
                    tempBullet.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/Yellow");
                }
                else
                {
                    tempBullet.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/Blue");
                }
                bulletDir = rotateQuate * bulletDir; //让发射方向旋转10度，到达下一个发射方向
            }
            yield return new WaitForSeconds(0.5f); //协程延时，0.5秒进行下一波发射
        }
        yield return null;
    }
    //钻头弹幕
    IEnumerator zuantou(int p)//p = 1 forward ,p = 2 right,p = 3 up
    {
        Vector3 dir = Vector3.zero;
        if (p == 1)
        {
            dir = firPoint.transform.forward;
        }
        else if (p == 2)
        {
            dir = firPoint.transform.right;
        }
        else if (p == 3)
        {
            dir = firPoint.transform.up;
        }
        else if (p == 4)
        {
            dir = -firPoint.transform.forward;
        }
        else if (p == 5)
        {
            dir = -firPoint.transform.right;
        }
        else if (p == 6)
        {
            dir = -firPoint.transform.up;
        }
        var temp = CreatBullet(dir, firPoint.transform.position, "Bullet_Boss");
        temp.GetComponent<BulletCharacter>().speed = 15;
        temp.GetComponent<Bullet>().lifeTime = 0.9f;
        temp.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/purple");
        Quaternion rota = Quaternion.AngleAxis(20, temp.transform.forward); ;
        Quaternion rota120 = Quaternion.AngleAxis(120, temp.transform.forward); ;
        Vector3 bulletDir = Vector3.zero;
        if (p == 1)
        {
            rota = Quaternion.AngleAxis(20, temp.transform.forward);
            rota120 = Quaternion.AngleAxis(120, temp.transform.forward);
            bulletDir = temp.transform.up;
        }
        else if (p == 2)
        {
            rota = Quaternion.AngleAxis(20, temp.transform.right);
            rota120 = Quaternion.AngleAxis(120, temp.transform.right);
            bulletDir = temp.transform.up;
        }
        else if (p == 3)
        {
            rota = Quaternion.AngleAxis(20, temp.transform.up);
            rota120 = Quaternion.AngleAxis(120, temp.transform.up);
            bulletDir = temp.transform.forward;
        }
        else if (p == 4)
        {
            rota = Quaternion.AngleAxis(20, -temp.transform.forward);
            rota120 = Quaternion.AngleAxis(120, -temp.transform.forward);
            bulletDir = temp.transform.up;
        }
        else if (p == 5)
        {
            rota = Quaternion.AngleAxis(20, -temp.transform.right);
            rota120 = Quaternion.AngleAxis(120, -temp.transform.right);
            bulletDir = temp.transform.up;
        }
        else if (p == 6)
        {
            rota = Quaternion.AngleAxis(20, -temp.transform.up);
            rota120 = Quaternion.AngleAxis(120, -temp.transform.up);
            bulletDir = temp.transform.forward;
        }
        for (int i = 0; i < 30; i++)
        {
            var temp1 = CreatBullet(bulletDir, temp.transform.position, "Bullet_Boss");
            temp1 = CreatBullet(rota120 * bulletDir, temp.transform.position, "Bullet_Boss");
            temp1 = CreatBullet(rota120 * rota120 * bulletDir, temp.transform.position, "Bullet_Boss");
            bulletDir = rota * bulletDir;

            yield return new WaitForSeconds(0.03f);
        }
    }
    //二级跟踪弹幕
    IEnumerator Test6(Vector3 creatPoint)//number为发射波数,count为每波子弹数量
    {

        Vector3 bulletDir = firPoint.transform.forward;
        //使用四元数制造绕Z轴旋转10度的旋转

        List<GameObject> bullets = new List<GameObject>();       //装入开始生成的8个弹幕
        for (int i = 0; i < 5; i++)
        {
            var tempBullet = CreatBullet(Vector3.zero, creatPoint, "Bullet_Boss");
            creatPoint.x++;
            tempBullet.GetComponent<BulletCharacter>().speed = 0;
            bullets.Add(tempBullet);
        }
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < bullets.Count; i++)
        {
            bullets[i].GetComponent<BulletCharacter>().isfollowMode = true;
            //bullets[i].speed = 5; 

        }
        yield return null;
    }
    //周身条形旋转弹幕
    IEnumerator Test7(int dir, int slipcount, int count, int firAngle) //dir=1为前后(up) dir=2为上下(right) dir=3为左右(forward)
                                                                       //slipcount为发射出的条数
                                                                       //count为每波子弹的数量
                                                                       //firAngle为初始偏移角度
    {
        Vector3 bulletDir = Vector3.zero;
        Vector3 rotavector = Vector3.zero;

        Quaternion RightRota;
        Quaternion LeftRota;
        if (dir == 1)
        {
            bulletDir = Quaternion.AngleAxis(firAngle, firPoint.transform.forward) * -firPoint.transform.up;
            rotavector = firPoint.transform.forward;
        }
        if (dir == 2)
        {
            bulletDir = Quaternion.AngleAxis(firAngle, firPoint.transform.right) * -firPoint.transform.forward;
            rotavector = firPoint.transform.right;
        }
        if (dir == 3)
        {
            bulletDir = Quaternion.AngleAxis(firAngle, firPoint.transform.up) * -firPoint.transform.right;
            rotavector = firPoint.transform.up;
        }

        RightRota = Quaternion.AngleAxis(180 / count, rotavector);
        LeftRota = Quaternion.AngleAxis(-180 / count, rotavector);


        Quaternion rota = Quaternion.AngleAxis(10, rotavector);
        for (int i = 0; i < count; i++)     //发射次数
        {
            for (int n = 0; n < slipcount; n++)
            {
                var temp = CreatBullet(Quaternion.AngleAxis(360 / slipcount * n, rotavector) * rota * bulletDir, firPoint.transform.position, "Bullet_Boss");
                temp.GetComponent<BulletCharacter>().speed = 15f;
                temp.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/Purple");
            }
            bulletDir = rota * bulletDir;
            yield return new WaitForSeconds(0.1f); //协程延时，0.5秒进行下一波发射
        }
    }
    //球形弹幕
    IEnumerator Test8(Vector3 creatPoint, int highAngle, int paralAngle)//number为发射波数,count为每波子弹数量
    {
        Quaternion forwardRota = Quaternion.AngleAxis(-highAngle, firPoint.transform.right);
        Vector3 bulletDir = Quaternion.AngleAxis(paralAngle, firPoint.transform.up) * forwardRota * firPoint.transform.forward;
        Quaternion upRota = Quaternion.AngleAxis(10, firPoint.transform.up);

        //使用四元数制造绕Z轴旋转10度的旋转


        List<GameObject> bullets = new List<GameObject>();       //装入开始生成的8个弹幕
        for (int i = 0; i < 36; i++)
        {
            var tempBullet = CreatBullet(bulletDir, creatPoint, "Bullet_Boss");
            bulletDir = upRota * bulletDir;
            tempBullet.GetComponent<BulletCharacter>().speed = 25;
            if (i % 2 != 0)
            {
                tempBullet.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/Blue");
            }
            else
            {
                tempBullet.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/Purple");
            }

            bullets.Add(tempBullet);
        }
        yield return new WaitForSeconds(0.15f);   //1秒后在生成多波弹幕

        for (int i = 0; i < bullets.Count; i++)
        {
            bullets[i].GetComponent<BulletCharacter>().speed = 10;
        }

    }
    IEnumerator Test9()//number为发射波数,count为每波子弹数量
    {
        for (int n = 0; n < 6; n++)
        {
            StartCoroutine(Test8(firPoint.transform.position, n * 15, n * 10));
            yield return new WaitForSeconds(0.05f);
        }

    }
    IEnumerator eight()
    {
        int count = 0;
        GameObject Animation = Instantiate(Anime, firPoint.transform.position, firPoint.transform.rotation);
        Destroy(Animation, 5);
        yield return new WaitForSeconds(2.2f);

        //BulletCharacter[] temp = new BulletCharacter[8];
        GameObject[] temp = new GameObject[8];

        temp[0] = CreatBullet(new Vector3(1, 0, 0), new Vector3(firPoint.transform.position.x - 16f, firPoint.transform.position.y + 8f, firPoint.transform.position.z), "Bullet_Boss");
        temp[1] = CreatBullet(new Vector3(0, 1, 0), new Vector3(firPoint.transform.position.x - 8f, firPoint.transform.position.y - 16f, firPoint.transform.position.z), "Bullet_Boss");
        temp[2] = CreatBullet(new Vector3(-1, 0, 0), new Vector3(firPoint.transform.position.x + 16f, firPoint.transform.position.y - 8f, firPoint.transform.position.z), "Bullet_Boss");
        temp[3] = CreatBullet(new Vector3(0, -1, 0), new Vector3(firPoint.transform.position.x + 8f, firPoint.transform.position.y + 16f, firPoint.transform.position.z), "Bullet_Boss");
        temp[4] = CreatBullet(new Vector3(1, 1, 0), new Vector3(firPoint.transform.position.x - 16f, firPoint.transform.position.y - 6.4f, firPoint.transform.position.z), "Bullet_Boss");
        temp[5] = CreatBullet(new Vector3(1, -1, 0), new Vector3(firPoint.transform.position.x - 6.4f, firPoint.transform.position.y + 16f, firPoint.transform.position.z), "Bullet_Boss");
        temp[6] = CreatBullet(new Vector3(-1, -1, 0), new Vector3(firPoint.transform.position.x + 16f, firPoint.transform.position.y + 6.4f, firPoint.transform.position.z), "Bullet_Boss");
        temp[7] = CreatBullet(new Vector3(-1, 1, 0), new Vector3(firPoint.transform.position.x + 6.4f, firPoint.transform.position.y - 16f, firPoint.transform.position.z), "Bullet_Boss");

        for (int i = 0; i <= 7; i++)
        {
            temp[i].GetComponent<BulletCharacter>().speed = 80f;
            temp[i].GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/Purple");
        }
          while (temp[0] != null&&count<20)
            {
                for (int i = 0; i < 7; i++)
                {
                    for (int n = 0; n < 8; n++)
                    {
                        float x, y, z;
                        do
                        {
                            x = Random.Range(-1f, 1f);
                            y = Random.Range(-1f, 1f);
                            z = Random.Range(-1f, 1f);
                        } while (x == 0 || y == 0 || z == 0);

                        CreatBullet(new Vector3(x, y, z), temp[n].transform.position, "Bullet_Boss");

                    }
                }
            count++;
            yield return new WaitForSeconds(0.08f);
            }
        
    }
    
    IEnumerator followBullet()
    {
        GameObject[] temp = new GameObject[5];

        for (int i = 0; i < 5; i++)
        {
            temp[i] = CreatBullet( Quaternion.AngleAxis(Random.Range(0,360f),firPoint.forward) * firPoint.up, firPoint.position, "Bullet_Boss");
            temp[i].GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/Shader Graphs_dayu_1");
            temp[i].GetComponent<BulletCharacter>().speed = 5f;
            temp[i].GetComponent<Bullet>().isFollow = true;
            temp[i].transform.localScale = temp[i].transform.localScale * 6;
            //temp.GetComponent<BulletCharacter>().isfollowMode = true;
            yield return new WaitForSeconds(0.7f);
        }
        for(int i = 0; i < 5; i++)
        {
            temp[i].GetComponent<BulletCharacter>().isfollowMode = true;
            
            yield return new WaitForSeconds(0.7f);
        }
        
    }
    //public BulletCharacter CreatBullet(Vector3 dir,Vector3 creatPoint)
    //{
    //    //Quaternion right30 = Quaternion.AngleAxis(180, Vector3.forward);
    //    BulletCharacter bulletCharacter = Instantiate(bulletTemplate, creatPoint, Quaternion.identity);
    //    bulletCharacter.gameObject.SetActive(true);
    //    bulletCharacter.dir = dir;
    //    tempBullets.Add(bulletCharacter);
    //    return bulletCharacter;
    //}
    public GameObject CreatBullet(Vector3 dir, Vector3 creatPoint, string bulletname)
    {
        //this.PlayAudio(this.shootAudio);
        //Quaternion right30 = Quaternion.AngleAxis(180, Vector3.forward)
        GameObject bulletCharacter = ObjectPool.GetInstance().GetObj(bulletname);

        //bulletCharacter.GetComponent<TrailRenderer>().enabled = true ;
        //bulletCharacter.gameObject.SetActive(true);
        bulletCharacter.transform.localRotation = new Quaternion(0, 0, 0, 1);
        bulletCharacter.GetComponent<BulletCharacter>().dir = dir;
        bulletCharacter.transform.position = creatPoint;
        bulletCharacter.GetComponent<BulletCharacter>().speed = 3f;
        bulletCharacter.GetComponent<BulletCharacter>().isfollowMode = false;
        //tempBullets.Add(bulletCharacter);
        //bulletQueue.Enqueue(bulletCharacter);
        return bulletCharacter;
    }


    /// <summary>
    /// 清空子弹列表
    /// </summary>
    public void ClearBulletsList()
    {
        if (tempBullets.Count > 0)
        {
            for (int i = (tempBullets.Count - 1); i >= 0; i--)
            {
                Destroy(tempBullets[i]);
            }
        }

        tempBullets.Clear();

    }

}
