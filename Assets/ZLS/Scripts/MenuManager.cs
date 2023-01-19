using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Valve.VR.Extras
{
    public class MenuManager : MonoBehaviour
    {
        public Transform controller;
        SteamVR_Behaviour_Pose pose;
        public SteamVR_Action_Boolean action_3 = SteamVR_Input.GetBooleanAction("UI");
        public SteamVR_Action_Vector2 action = SteamVR_Input.GetVector2Action("xuanzhuan");
        public SteamVR_Action_Boolean action_2 = SteamVR_Input.GetBooleanAction("isTouch");
        public SteamVR_Action_Boolean action_1 = SteamVR_Input.GetBooleanAction("back");
        public GameObject behaviourL;

        public GameObject MM;
        public GameObject LM;
        public GameObject RM;
        public GameObject ui1;
        public GameObject ui2;
        public GameObject ui3;
        public GameObject GC;
        public GameObject GE;
        public GameObject DGC;
        public GameObject DGE;
        public GameObject WGC;
        public GameObject WGE;
        private int i;

        public bool isPause;
        private bool c;
        private bool e;
        private bool uiActive;
        private bool iszhuan;
        private bool uishow;
        private bool canPause;
        private bool uiislock;

        public bool isshang = true;

        private bool menuOn = false;
        float oldTouch;
        float newTouch;

        public AudioClip uiclip;
        public AudioClip uixuanze;
        public AudioClip uishouhui;
        protected AudioSource m_AudioSource;

        public BossHp Boss;
        public PlayerHp Player;
        public GameObject uiwin;
        public GameObject uidead;
        // Start is called before the first frame update
        void Start()
        {
            c = true;
            e = false;
            i = 1;
            pose = behaviourL.GetComponent<SteamVR_Behaviour_Pose>();
            uishow = false;
            canPause = false;
            m_AudioSource = transform.GetComponent<AudioSource>();
        }
        private void PlayAudio(AudioClip ac, float vo)
        {
            m_AudioSource.PlayOneShot(ac);
            m_AudioSource.volume = vo;

        }
        // Update is called once per frame
        void Update()
        {
            if (Boss.dead) {
                uiwin.SetActive(true);
            }
            if (Player.isdead) {
                uidead.SetActive(true);
                Time.timeScale = 0f;
            }
            //print(i % 2);
            /*if (action_3.GetStateDown(pose.inputSource))
            {
                if (  !canPause)
                {
                    isPause = false;
                    Time.timeScale = 1f;
                }
                if (canPause)
                {
                    isPause = true;
                    Time.timeScale = 0f;
                }

            }*/
            /*if (action_3.GetStateDown(pose.inputSource)) {
                i++;
            }*/
            if (action_3.GetStateDown(pose.inputSource)/*Input.GetKeyDown("n")*/ && canPause == false&&!isPause)
            {
                isPause = true;
                Time.timeScale = 0f;
                PlayAudio(uiclip, 1f);
            }
            if (action_3.GetStateDown(pose.inputSource)/*Input.GetKeyDown("m")*/ && canPause&&isPause)
            {
                isPause = false;
                Time.timeScale = 1f;
                PlayAudio(uishouhui, 1f);
            }
            /*else if (action_3.GetStateUp(pose.inputSource))
            {
                
            }*/


            if (isPause)
            {
                if (uiislock)
                {
                    LM.transform.position = MM.transform.position;
                    RM.transform.position = MM.transform.position;
                    MM.transform.eulerAngles = new Vector3(0, 0, 0);
                    LM.transform.eulerAngles = new Vector3(0, 0, 0);
                    RM.transform.eulerAngles = new Vector3(0, 0, 0);
                    uiislock = false;
                }

                if (MM.GetComponentInChildren<Image>().fillAmount < 1)
                {
                    uishow = false;
                    MM.GetComponentInChildren<Image>().fillAmount += 0.1f;
                    LM.GetComponentInChildren<Image>().fillAmount += 0.1f;
                    RM.GetComponentInChildren<Image>().fillAmount += 0.1f;
                }
                else
                {
                    uishow = true;
                }
                if (RM.transform.localPosition.x < 0.92f  && uishow)
                {
                    //print(456456);
                    iszhuan = false;
                    LM.transform.localPosition -= new Vector3(0.04f, -0.003f, 0.016f);
                    RM.transform.localPosition += new Vector3(0.04f, 0.003f, -0.016f);
                }
                if (uishow && RM.transform.localPosition.x >= 0.92f)
                {
                    //print("890");
                    iszhuan = true;
                }
                //print(iszhuan);
                if (MM.transform.eulerAngles.x < 22f && iszhuan)
                {
                    
                    //print(123);
                    MM.transform.Rotate(1f, 0f, 0f);
                    LM.transform.Rotate(1f, -2f, 0f);
                    RM.transform.Rotate(1f, 2f, 0f);
                }
                if (MM.transform.eulerAngles.x >= 22f)
                {
                    canPause = true;
                    if (ui1.transform.localScale.x < 1) {
                        ui1.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                        ui2.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                        ui3.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
            }
            else {
                
                uiislock = true;
                if (ui1.transform.localScale.x > 0)
                {
                    ui1.transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
                    ui2.transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
                    ui3.transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
                }
                else {
                    if (MM.GetComponentInChildren<Image>().fillAmount > 0)
                    {
                        MM.GetComponentInChildren<Image>().fillAmount -= 0.1f;
                        LM.GetComponentInChildren<Image>().fillAmount -= 0.1f;
                        RM.GetComponentInChildren<Image>().fillAmount -= 0.1f;
                    }
                    else
                    {
                        canPause = false;
                    }
                }

            }

            newTouch = action.GetAxis(pose.inputSource).y;
            if (action_2.GetStateDown(pose.inputSource))
            {
                oldTouch = action.GetAxis(pose.inputSource).y;
            }
            if (action_2.GetState(pose.inputSource))
            {
                if (newTouch - oldTouch > 0.3&&!isshang && (isPause || Boss.dead || Player.isdead))
                {

                    c = true;
                    e = false;
                    PlayAudio(uixuanze, 1f);
                    isshang = true;
                }
                else if (newTouch - oldTouch < -0.3&&isshang && (isPause || Boss.dead || Player.isdead))
                {
                    c = false;
                    e = true;
                    PlayAudio(uixuanze, 1f);
                    isshang = false;
                }
            }

            if (c)
            {
                GC.transform.localScale = new Vector3(1.1f, 1.1f, 1f);
                GE.transform.localScale = new Vector3(1f, 1f, 1f);
                DGC.transform.localScale = new Vector3(1.1f, 1.1f, 1f);
                DGE.transform.localScale = new Vector3(1f, 1f, 1f);
                WGC.transform.localScale = new Vector3(1.1f, 1.1f, 1f);
                WGE.transform.localScale = new Vector3(1f, 1f, 1f);

            }
            else {
                GE.transform.localScale = new Vector3(1.1f, 1.1f, 1f);
                GC.transform.localScale = new Vector3(1f, 1f, 1f);
                DGE.transform.localScale = new Vector3(1.1f, 1.1f, 1f);
                DGC.transform.localScale = new Vector3(1f, 1f, 1f);
                WGE.transform.localScale = new Vector3(1.1f, 1.1f, 1f);
                WGC.transform.localScale = new Vector3(1f, 1f, 1f);
            }

            if (action_1.GetStateDown(pose.inputSource) && c && !Boss.dead && !Player.isdead) {
                isPause = false;
                Time.timeScale = 1f;
            }
            if (action_1.GetStateDown(pose.inputSource) && c && Boss.dead)
            {
                /*isPause = false;
                Time.timeScale = 1f;*/
                SceneManager.LoadScene("VRGame");
            }
            if (action_1.GetStateDown(pose.inputSource) && c && Player.isdead) {
                Time.timeScale = 1f;
                print(1);
                SceneManager.LoadScene(0);
            }
            if (action_1.GetStateDown(pose.inputSource) && e) {
                Application.Quit();
            }
        }
    }
}
