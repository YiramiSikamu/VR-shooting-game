using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;

namespace Valve.VR.Extras
{
    public class shoot : MonoBehaviour
    {
        public Transform firpoint;
        public Transform firpoint2;
        public Transform firpoint_mid;
        public int change = 1;
        public Transform player;

        public float shootingRate = 1f; //Time interval between firing bullets
        private float shootCooldown;
        public float shieldCD = 60f;
        private float shieldCooldown;
        public float yumefuyinCD = 30f;
        private float yumefuyinCooldown;
        public GameObject target;
        public Transform container;
        public int rota = 240;//旋转初始速度
        private Transform V;
        public MyUIManager MUM;
        public Valve.VR.Extras.GunSaberShift GSS;

        public shexian Shexian;
        public Transform controller;
        SteamVR_Behaviour_Pose pose;
        public SteamVR_Action_Boolean action_2 = SteamVR_Input.GetBooleanAction("Trigger");
        public GameObject behaviourR;

        private float gongsu;
        public GameObject uigongsu;

        public AudioSource audiosource;
        public AudioClip shootSound;
        // Start is called before the first frame update
        void Start()
        {
            yumefuyinCooldown = 0f;
            shieldCooldown = 0f;
            shootCooldown = 0f;
            V = GameObject.FindGameObjectWithTag("MainCamera").transform;
            firpoint_mid = GameObject.FindGameObjectWithTag("MainCamera").transform;
            //firpoint = GameObject.FindGameObjectWithTag("MainCamera").transform;
            pose = behaviourR.GetComponent<SteamVR_Behaviour_Pose>();
        }

        private void PlayAudio(AudioClip ac)
        {
            audiosource.PlayOneShot(ac);
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            gongsu = 1 / shootingRate;
            string a = gongsu.ToString();
            uigongsu.GetComponent<TMP_Text>().text = a;
            if (action_2.GetState(pose.inputSource))
            {

            }
            else if (action_2.GetStateUp(pose.inputSource))
            {

            }

            if (shootCooldown > 0)
            {
                shootCooldown -= Time.deltaTime;
            }

            if (yumefuyinCooldown > 0)
            {
                yumefuyinCooldown -= Time.deltaTime;
            }

            if (shieldCooldown > 0)
            {
                shieldCooldown -= Time.deltaTime;
            }
            if (CanAttack&&GSS.isGun)
            {

                if (action_2.GetState(pose.inputSource))
                {
                    PlayAudio(shootSound);
                    var temp = CreatBullet(Quaternion.AngleAxis(-40f, controller.transform.right) *- controller.transform.up, "Prefabs/bullet_self", controller);

                    temp.transform.LookAt(player);
                    if (Shexian.isEnemy/*(Screen.width / 3) < pos.x && pos.x < (Screen.width / 3 * 2) && pos.y > (Screen.height / 3) && pos.y < (Screen.height / 3 * 2) && pos.z > 0*/)
                        {
                            temp.GetComponent<bullet>().isfollowMode = true;
                        }



                    shootCooldown = shootingRate;

                }
            }
            if (MUM.skill1)
            {
                if (CanDefend/*Input.GetKeyDown("e")*/)
                {
                    GameObject shield = (GameObject)Resources.Load("Prefabs/shield");
                    shield = Instantiate(shield);
                    shield.GetComponent<shieldMove>().dir = V.forward;
                    shield.transform.position = V.position + V.forward * 5f;
                    shield.transform.localRotation = V.localRotation;
                    shieldCooldown = shieldCD;
                    MUM.skill1 = false;
                }
                else
                {
                    MUM.skill1 = false;
                }
            }
            if (MUM.skill2)
            {
                if (CanFuyin/*Input.GetKeyDown("q")*/)
                {
                    yumefuyinCooldown = yumefuyinCD;
                    StartCoroutine(yumefuyin(2f));
                    MUM.skill2 = false;
                }
                else
                {
                    MUM.skill2 = false;
                }

            }


        }
        public GameObject CreatBullet(Vector3 dir, string bulletname, Transform firpoint)
        {
            GameObject bullet = (GameObject)Resources.Load(bulletname);
            bullet = Instantiate(bullet);
            bullet.GetComponent<bullet>().dir = dir;
            bullet.transform.position = firpoint.transform.position;

            return bullet;
        }
        public bool CanAttack
        {
            get
            {
                return shootCooldown <= 0f;
            }
        }
        public bool CanDefend
        {
            get
            {
                return shieldCooldown <= 0f;
            }
        }
        public bool CanFuyin
        {
            get
            {
                return yumefuyinCooldown <= 0f;
            }
        }

        IEnumerator yumefuyin(float secend)
        {
            GameObject[] temp = new GameObject[6];
            Vector3 bulletDir = firpoint.transform.up;
            Quaternion rota = Quaternion.AngleAxis(-60, firpoint.transform.forward);
            for (int i = 0; i < 6; i++)
            {
                temp[i] = CreatBullet(bulletDir, "Prefabs/bullet_skill", firpoint_mid);
                if (i % 3 == 0)
                {
                    temp[i].GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/M_Skill1_Red");
                    temp[i].GetComponent<TrailRenderer>().material = Resources.Load<Material>("Material/M_Skill1_Red");
                }
                if (i % 3 == 1)
                {
                    temp[i].GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/M_Skill1_Blue");
                    temp[i].GetComponent<TrailRenderer>().material = Resources.Load<Material>("Material/M_Skill1_Blue");
                }
                if (i % 3 == 2)
                {
                    temp[i].GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/M_Skill1_Green");
                    temp[i].GetComponent<TrailRenderer>().material = Resources.Load<Material>("Material/M_Skill1_Green");
                }

                container.transform.position = controller.transform.position;
                //container.transform.rotation = controller.transform.rotation;
                temp[i].transform.parent = container.transform;
                temp[i].GetComponent<bullet>().speed = 3f;
                bulletDir = rota * bulletDir;
            }
            yield return new WaitForSeconds(secend);//扩散阶段

            for (int i = 0; i < 6; i++)//取消旋转阶段的拖尾
            {
                temp[i].GetComponent<TrailRenderer>().enabled = false;
            }
            Coroutine coroutine = StartCoroutine(ContainerRotate());//加速旋转携程

            yield return new WaitForSeconds(0.5f);//加速旋转时间

            StopCoroutine(coroutine);//停止加速旋转

            Coroutine coroutine2 = StartCoroutine(ContainerRotate2());//减速旋转携程

            yield return new WaitForSeconds(0.5f);//减速旋转时间

            StopCoroutine(coroutine2);//停止减速旋转

            for (int i = 0; i < 6; i++)//开启拖尾
            {
                temp[i].GetComponent<TrailRenderer>().enabled = true;
            }

            for (int i = 0; i < 6; i++)//追踪阶段
            {
                temp[i].GetComponent<bullet>().isfollowMode = true;
                temp[i].GetComponent<bullet>().speed = 20f;
                StartCoroutine(BigChange(temp[i]));
                yield return new WaitForSeconds(0.2f);//分步追踪
            }

        }

        private IEnumerator ContainerRotate()//加速
        {
            rota = 240;//初始速度
            while (true)
            {
                yield return new WaitForSeconds(0.01f);
                container.transform.Rotate(0, 0, rota * Time.deltaTime);
                rota += 30;//加速度
            }
        }

        private IEnumerator ContainerRotate2()//减速携程
        {
            //int rota = 240;//初始速度
            while (true)
            {
                yield return new WaitForSeconds(0.01f);
                container.transform.Rotate(0, 0, rota * Time.deltaTime);
                rota -= 30;//加速度
            }
        }

        private IEnumerator BigChange(GameObject temp)
        {

            while (temp && temp.transform.localScale.x <= 8)
            {
                yield return new WaitForSeconds(0.01f);
                temp.transform.localScale *= 1.01f;
            }
        }

    }
}
