using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

namespace Valve.VR.Extras
{

    public class CharacterMove : MonoBehaviour
    {
        public Transform controller;
        public float speed;
        public Vector3 forward;
        public Vector3 right;
        public Vector3 up;
        public bool ismove1;
        public bool ismove2;
        public Transform VRcamera;
        private Vector3 lastMove;
        public bool smooth;

        private Vector3 charaRight;
        private Vector3 charaUp;
        private Vector3 charaForward;
        SteamVR_Behaviour_Pose pose;
        public SteamVR_Action_Boolean action_1 = SteamVR_Input.GetBooleanAction("GrabGrip");

        public SteamVR_Action_Boolean action_2 = SteamVR_Input.GetBooleanAction("Trigger");

        public SteamVR_Action_Boolean action_3 = SteamVR_Input.GetBooleanAction("UI");
        public SteamVR_Action_Boolean action_4 = SteamVR_Input.GetBooleanAction("Back");
        public GameObject behaviourL;

        //public SteamVR_Action_Vector2 action_4 = SteamVR_Input.GetVector2Action("Teleport");

        // Use this for initialization
        void Start()
        {
            charaUp = transform.up;
            charaRight = transform.right;
            charaForward = transform.forward;
            pose = behaviourL.GetComponent<SteamVR_Behaviour_Pose>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {

            Vector3 cross1 = Vector3.Cross(charaRight, controller.right);

            if (controller.localEulerAngles.z > 220&& controller.localEulerAngles.z<330)
            {
                float scale = (330f-controller.localEulerAngles.z) / 50f;
                right = VRcamera.right*scale;
            }
            else if (controller.localEulerAngles.z < 120&& controller.localEulerAngles.z>25)
            {
                float scale = (controller.localEulerAngles.z - 25f) / 50f;
                right = -VRcamera.right*scale;
            }
            else
            {
                right = Vector3.zero;
            }
            if (controller.localEulerAngles.x>10&& controller.localEulerAngles.x<90)
            {
                up = -charaUp;

            }
            else if(controller.localEulerAngles.x>270&& controller.localEulerAngles.x < 320)
            {
                up = charaUp;
            }
            else
            {
                up = Vector3.zero;
            }
           
            Vector3 cross2 = Vector3.Cross(charaUp, controller.forward);
            //if (Vector3.Angle(controller.up, charaUp) > 80 && Vector3.Angle(controller.up, charaUp) < 140)
            //{
            //    if (cross2.x > 0)
            //    {
            //        up = transform.up;
            //    }
            //    else if (cross2.x < 0)
            //    {
            //        up = -transform.up;
            //    }
                
            //}
            //else
            //{
            //    up = Vector3.zero;
            //}
           /* if (Vector3.Angle(controller.up, charaUp) > 100)
            {
                up = VRcamera.up;
            }
            else if (Vector3.Angle(controller.up, charaUp)>20&& Vector3.Angle(controller.up, charaUp)<80)
            {
                up = -VRcamera.up;
            }
            else
            {
                up = Vector3.zero;
            }*/

            //print(Vector3.Angle(controller.right, charaRight));
     
            if (action_1.GetStateDown(pose.inputSource))
            {
                ismove2 = true;
                smooth = false;
                forward = Vector3.zero;
            }
            else if (action_1.GetStateUp(pose.inputSource))
            {
                smooth = true;
                lastMove = right + up;
                lastMove.Normalize();
                /*if (!ismove1)
                {
                    if (speed > 0)
                    {
                        transform.position += lastMove * speed * Time.deltaTime;
                        speed -= 0.04f;
                    }
                    
                }*/
                ismove2 = false;

            }

            if (action_2.GetState(pose.inputSource))
            {
                smooth = false;
                ismove1 = true;
                forward = VRcamera.forward;
            }
            else if (action_2.GetStateUp(pose.inputSource))
            {
                lastMove = VRcamera.forward + right + up;
                lastMove.Normalize();
                smooth = true;
                
                /*if (!ismove2)
                {
                    if (speed > 0)
                    {
                        transform.position += lastMove * speed * Time.deltaTime;
                        speed -= 0.04f;
                    }

                }*/
                ismove1 = false;
                
                forward = Vector3.zero;


            }
            else if (action_4.GetState(pose.inputSource))
            {
                smooth = false;
                ismove1 = true;
                forward = -VRcamera.forward;
            }
            else if (action_4.GetStateUp(pose.inputSource))
            {
                lastMove = -VRcamera.forward + right + up;
                lastMove.Normalize();
                smooth = true;

                /*if (!ismove2)
                {
                    if (speed > 0)
                    {
                        transform.position += lastMove * speed * Time.deltaTime;
                        speed -= 0.04f;
                    }

                }*/
                ismove1 = false;

                forward = Vector3.zero;


            }

            if (action_3.GetStateDown(pose.inputSource))
            {
               
            }
            else if (action_3.GetStateUp(pose.inputSource))
            {
               
            }
            if (ismove1||ismove2)
            {
                speed = 12;
                Vector3 dir = forward + up + right;
                if(forward != Vector3.zero||up!=Vector3.zero)
                {
                    dir.Normalize();
                }
                transform.position += dir * speed * Time.deltaTime;
            }
            if (smooth)
            {
                if (speed > 0)
                {
                    transform.position += lastMove * speed * Time.deltaTime;
                    speed -= 0.2f;
                }
                if (speed < 0)
                {
                    smooth = false;
                }
            }
           
        }
    }
}
