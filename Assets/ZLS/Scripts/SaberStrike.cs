using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using TMPro;
public class SaberStrike : MonoBehaviour
{
    public Valve.VR.Extras.GunSaberShift GSS;
    public HandHaptic handHaptic;
    public int Count;
    public GameObject uiCount;
    public GameObject ballDie;
    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GSS.isSaber)
        {
            transform.localScale = new Vector3(transform.localScale.x, 0.015f, transform.localScale.z);
        }
        if (!GSS.isSaber)
        {
            transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (GSS.isSaber&&other.gameObject.tag.Equals("EnemyBullet"))
        {
            handHaptic.vibrating(0.1f, 150, 0.5f, SteamVR_Input_Sources.RightHand);
            other.gameObject.GetComponent<Bullet>().Recycle();
            ballDie = (GameObject)Resources.Load("Prefabs/VFX_balldie");
            if (other.gameObject.GetComponent<BulletCharacter>().isfollowMode)
            {
                ballDie = Instantiate(ballDie, other.gameObject.transform.position, other.gameObject.transform.rotation);
                ballDie.transform.localScale = ballDie.transform.localScale * 3;
            }
            ballDie = Instantiate(ballDie, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Destroy(ballDie, 2f);
            Count++;
        }
        string a = Count.ToString();
        uiCount.GetComponent<TMP_Text>().text = a;
    }
}
