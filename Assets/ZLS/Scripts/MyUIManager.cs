using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Valve.VR.Extras {
    public class MyUIManager : MonoBehaviour
    {
        public GameObject Object1;
        public GameObject Object2;
        public GameObject skillUI;
        public GameObject mawaru;
        public HandHaptic handHaptic;
        public GameObject yinyangyu;

        private bool isShow;
        private bool skillActive;
        private bool skillA;
        private bool skillB;
        public bool skill1;
        public bool skill2;
        public bool vibra = true;
        //public bool skillUIdes;

        public Transform controller;
        SteamVR_Behaviour_Pose pose;
        public SteamVR_Action_Boolean action_1 = SteamVR_Input.GetBooleanAction("GrabGrip");
        public SteamVR_Action_Boolean action_2 = SteamVR_Input.GetBooleanAction("Trigger");
        public SteamVR_Action_Boolean action_3 = SteamVR_Input.GetBooleanAction("UI");
        public GameObject behaviourR;

        private Vector3 oldAngle;
        private Vector3 newAngle;
        private float oldAngleZ;
        private float skillSpeed;
        private float scale;
        public float rotateCount;

        public AudioSource audiosource;
        public AudioClip skill;
        public AudioClip select;

        // Start is called before the first frame update
        void Start()
        {
            //skillUIdes = false;
            isShow = false;
            skillActive = false;
            skillA = false;
            skillB = false;
            pose = behaviourR.GetComponent<SteamVR_Behaviour_Pose>();
            skillSpeed = 0.1f;
            scale = 2f;
        }
        private void PlayAudio(AudioClip ac)
        {
            audiosource.PlayOneShot(ac);
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            //skillUI.transform.position = controller.position;
            //mawaru.transform.position = controller.position;
            if (action_1.GetStateDown(pose.inputSource))
            {
                //skillUI.transform.localEulerAngles = new Vector3(skillUI.transform.localEulerAngles.x, controller.localEulerAngles.y,controller.localEulerAngles.z);
                //skillUI.transform.localEulerAngles = controller.localEulerAngles;
                isShow = true;
                oldAngle = controller.localEulerAngles;
                oldAngleZ = controller.localEulerAngles.z;
                if (oldAngleZ > 0 && oldAngleZ < 180)
                {
                    oldAngleZ += 360f;
                }
                PlayAudio(skill);
                //mawaru = Resources.Load<GameObject>("Prefabs/mawaru");
                //skillUIdes = false;
                //mawaru = Instantiate(mawaru);
                //mawaru.transform.position = skillUI.transform.position;
                //mawaru.transform.localEulerAngles = new Vector3(mawaru.transform.localEulerAngles.x, controller.localEulerAngles.y, controller.localEulerAngles.z);
                //mawaru.transform.localEulerAngles = controller.localEulerAngles;
                //mawaru.transform.parent = skillUI.transform;

                mawaru.SetActive(true);
            }
            else if (action_1.GetStateUp(pose.inputSource))
            {
                if (skillA)
                {
                    skill1 = true;
                }
                else if (skillB)
                {
                    skill2 = true;
                }
                isShow = false;
                newAngle = controller.localEulerAngles;
                oldAngleZ += 1000f;

                //Destroy(mawaru);
                //skillUIdes = true;
                mawaru.SetActive(false);

            }

            if (action_2.GetState(pose.inputSource))
            {

            }
            else if (action_2.GetStateUp(pose.inputSource))
            {

            }

            if (action_3.GetStateDown(pose.inputSource))
            {

            }
            else if (action_3.GetStateUp(pose.inputSource))
            {

            }

            //print(controller.localEulerAngles);

            /////////////////////////////////////////////////////////////////////////


            if (isShow)
            {
                //print(Object1.transform.localScale.x);
                if (Object1.transform.localScale.x < scale)     //检测
                {
                    Object1.transform.localScale += new Vector3(skillSpeed, skillSpeed, skillSpeed);
                    Object2.transform.localScale += new Vector3(skillSpeed, skillSpeed, skillSpeed);
                    yinyangyu.transform.Rotate(new Vector3(0, 0, 18f));
                }
                if (Object1.transform.localScale.x >= scale)
                {
                    skillActive = true;
                }
            }
            if (isShow == false && skillA)
            {
                skillActive = false;
                if (Object1.transform.localScale.x > 0)
                {
                    Object1.transform.localScale = Vector3.zero;
                    Object2.transform.localScale = Vector3.zero;
                    //Object2.transform.localScale -= new Vector3(0.01f, 0.02f, 0.02f);
                }
                skillA = false;
            }
            if (isShow == false && skillB)
            {
                skillActive = false;
                if (Object2.transform.localScale.x > 0)
                {
                    Object1.transform.localScale = Vector3.zero;
                    //Object1.transform.localScale -= new Vector3(0.01f, 0.02f, 0.02f);
                    Object2.transform.localScale = Vector3.zero;
                }
                skillB = false;
            }
            if (isShow == false && skillA == false && skillB == false)
            {
                skillActive = false;
                if (Object1.transform.localScale.x > 0)
                {
                    Object1.transform.localScale -= new Vector3(skillSpeed, skillSpeed, skillSpeed);
                    //Object2.transform.localScale = Vector3.zero;
                    Object2.transform.localScale -= new Vector3(skillSpeed, skillSpeed, skillSpeed);
                    yinyangyu.transform.Rotate(new Vector3(0, 0, -18f));
                }
            }

            


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (((oldAngleZ - controller.localEulerAngles.z) > 30) && ((oldAngleZ - controller.localEulerAngles.z) < 180) && skillA == false)
            {
                if (vibra)
                {
                    handHaptic.vibrating(0.1f, 150, 0.5f, SteamVR_Input_Sources.RightHand);
                    vibra = false;
                }
                skillB = true;
                Object2.transform.localScale = new Vector3(scale + 0.2f, scale + 0.2f, scale + 0.2f);
                
                /*if (Object2.transform.localScale.x <= scale+0.1f)
                {
                    Object2.transform.localScale += new Vector3(skillSpeed, skillSpeed, skillSpeed);
                }*/
            }
            else if (((oldAngleZ - controller.localEulerAngles.z) < 330) && ((oldAngleZ - controller.localEulerAngles.z) > 180) && skillB == false)
            {
                if (vibra)
                {
                    handHaptic.vibrating(0.1f, 150, 0.5f, SteamVR_Input_Sources.RightHand);
                    vibra = false;
                }
                skillA = true;
                Object1.transform.localScale = new Vector3(scale + 0.2f, scale + 0.2f, scale + 0.2f);
               
                /*if (Object1.transform.localScale.x <= scale+0.1f)
                {
                    Object1.transform.localScale += new Vector3(skillSpeed, skillSpeed, skillSpeed);
                }*/
            }
            else if(skillA||skillB){
                if (skillB)
                {
                    Object2.transform.localScale = new Vector3(scale, scale, scale);
                    /*if (Object2.transform.localScale.x > scale)
                    {
                        Object2.transform.localScale -= new Vector3(skillSpeed, skillSpeed, skillSpeed);
                    }*/
                    if (Object2.transform.localScale.x <= scale)
                    {
                        skillB = false;
                    }
                }
                if (skillA)
                {
                    Object1.transform.localScale = new Vector3(scale, scale, scale);
                    /*if (Object1.transform.localScale.x > scale)
                    {
                        Object1.transform.localScale -= new Vector3(skillSpeed, skillSpeed, skillSpeed);
                    }*/
                    if (Object1.transform.localScale.x <= scale)
                    {
                        skillA = false;
                    }
                }

            }
            else
            {
                vibra = true;
            }

            
        }
    }

}
