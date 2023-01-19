using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Valve.VR.Extras {
    public class TestVR : MonoBehaviour
    {
        SteamVR_Behaviour_Pose pose;
        public SteamVR_Action_Vector2 action = SteamVR_Input.GetVector2Action("xuanzhuan");
        public SteamVR_Action_Boolean action_2 = SteamVR_Input.GetBooleanAction("isTouch");
        public GameObject behaviourL;
        // Start is called before the first frame update
        void Start()
        {
            pose = behaviourL.GetComponent<SteamVR_Behaviour_Pose>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (action_2.GetState(pose.inputSource))
                print(action.GetAxis(pose.inputSource));
        }
    }
}

