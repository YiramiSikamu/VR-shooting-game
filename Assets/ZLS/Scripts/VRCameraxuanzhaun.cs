using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace Valve.VR.Extras
{
    public class VRCameraxuanzhaun : MonoBehaviour
    {
        SteamVR_Behaviour_Pose pose;
        public SteamVR_Action_Vector2 action = SteamVR_Input.GetVector2Action("xuanzhuan");
        public SteamVR_Action_Boolean action_2 = SteamVR_Input.GetBooleanAction("isTouch");
        public SteamVR_Action_Boolean action_3 = SteamVR_Input.GetBooleanAction("Back");
        public GameObject behaviourL;

        public bool Active;     //这个条件是对接VR里面的是否触碰了触摸板
        private bool islock;    //此条件是用来辅助获取oldTouch

        private bool isTouch;   //此条件是用来辅助获取oldTouch
        private float oldTouch; //获取刚触摸时的位置
        private float newTouch; //实时获取触摸的位置
        private float offset;   //计算oldTouch和newTouch的插值
        public GameObject Player;

        private float x;        //测试数据
                                // Start is called before the first frame update
        void Start()
        {
            islock = false;
            pose = behaviourL.GetComponent<SteamVR_Behaviour_Pose>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            x = action.GetAxis(pose.inputSource).x;
            newTouch = x;
            if (action_2.GetStateDown(pose.inputSource)&&!action_3.GetState(pose.inputSource))
            {    //触摸时执行一次，并将isTouch变为true
                oldTouch = x;
                //print(1);
            }
            if (action_2.GetState(pose.inputSource) && !action_3.GetState(pose.inputSource))
            {   //触摸时更新newTouch
                offset = oldTouch - newTouch;
                float AngleFactor = -offset * 30f;
                Player.transform.Rotate(0, AngleFactor, 0);

                oldTouch = newTouch;
            }
        }
    }
}

