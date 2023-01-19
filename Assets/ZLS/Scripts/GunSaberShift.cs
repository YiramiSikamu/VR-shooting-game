using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace Valve.VR.Extras
{
    public class GunSaberShift : MonoBehaviour
    {
        public bool isGun;
        public bool isSaber;
        SteamVR_Behaviour_Pose pose;
        public SteamVR_Action_Vector2 action = SteamVR_Input.GetVector2Action("xuanzhuan");
        public SteamVR_Action_Boolean action_2 = SteamVR_Input.GetBooleanAction("isTouch");
        public GameObject behaviourR;
        public GameObject VFX_saber;
        public GameObject VFX_saber_01;
        public GameObject VFX_gun;
        float oldTouch;
        float newTouch;
        public HandHaptic handHaptic;

        public AudioSource m_AudioSource;
        public AudioClip Clip;
        public AudioClip Gun;


        // Start is called before the first frame update
        void Start()
        {
            pose = behaviourR.GetComponent<SteamVR_Behaviour_Pose>();
        }
        private void PlayAudio(AudioClip ac)
        {
            m_AudioSource.PlayOneShot(ac);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            newTouch = action.GetAxis(pose.inputSource).y;
            if (action_2.GetStateDown(pose.inputSource))
            {
                oldTouch = action.GetAxis(pose.inputSource).y;
            }
            if (action_2.GetState(pose.inputSource))
            {
                if (newTouch - oldTouch > 0.3&&!isSaber)
                {
                    PlayAudio(Clip);
                    VFX_saber.transform.position = transform.position;
                    VFX_saber.transform.rotation = transform.rotation;

                    VFX_saber.SetActive(true);
                    VFX_saber_01.SetActive(true);
                    VFX_gun.SetActive(false);
                    
                   
                    isSaber = true;
                    isGun = false;
                    //StartCoroutine(wait(10f));
              
                    handHaptic.vibrating(0.1f, 220, 0.5f, SteamVR_Input_Sources.RightHand);

                }
                else if(newTouch - oldTouch <-0.3&&!isGun)
                {
                    PlayAudio(Gun);
                    VFX_saber.SetActive(false);
                    VFX_saber_01.SetActive(false);
                    VFX_gun.SetActive(true);
                    isSaber = false;
                    isGun = true;
                }
            }
            
        }
        IEnumerator wait(float second)
        {
            yield return new WaitForSeconds(second);
        }
    }
}

