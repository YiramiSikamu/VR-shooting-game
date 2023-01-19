using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHp : MonoBehaviour
{
    public int Hp;
    private int MaxHp;
    public BulletHurt Bullet;
    public PlayerBulletHurt PlayerBulletHurt;
    public Valve.VR.Extras.shoot shoot;
    public bool lo;
    //public Cinemachine.CinemachineImpulseSource CIS;
    private bool by;
    public GameObject Y;
    public float jianxuetime;
    public AudioClip daoju;
    public GameObject baojing;
    //public GameObject HPUI;
    public bool isdead;

    protected AudioSource m_AudioSource;
    public GameObject uihp;
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = this.transform.GetComponent<AudioSource>();
        jianxuetime = 8f;
        Hp = 48;
        MaxHp = Hp;
        lo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOut())
        {
            baojing.SetActive(true);
        }
        else {
            baojing.SetActive(false);
        }
        if (isOut() && jianxuetime > 0)
        {
            jianxuetime -= Time.deltaTime;
        }
        if (jianxuetime <= 0) {
            Hp--;
            jianxuetime = 8f;
        }
        /*if (Hp <= 6) {
            HPUI.GetComponent<Image>().color = new Color(HPUI.GetComponent<Image>().color.r, HPUI.GetComponent<Image>().color.g, HPUI.GetComponent<Image>().color.b,(1-Hp/12f));
        }*/
        string a = Hp.ToString();
        uihp.GetComponent<TMP_Text>().text = a;
        if (Hp <= 0) {
            isdead = true;
        }
    }
    private void PlayAudio(AudioClip ac,float vo)
    {
        if (ac == null)
        {
            //Debug.LogError(this.name + ":audioClip is Null !");
        }
        this.m_AudioSource.PlayOneShot(ac);
        m_AudioSource.volume = vo;
    }
    public float GetHealthRate() {
        return (float)Hp / (float)MaxHp;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet")) {
            Hp -= Bullet.hurt;
            other.gameObject.GetComponent<Bullet>().Recycle();
            if (Hp <= 0) {
                lo = true;
            }
        }
        if (other.CompareTag("HurtUp")) {
            PlayerBulletHurt.Hurt += 1;
            Destroy(other.gameObject);
            this.PlayAudio(this.daoju,0.3f);
        }
        if (other.CompareTag("AtkSpeedUp")) {
            shoot.shootingRate -= 0.02f;
            Destroy(other.gameObject);
            this.PlayAudio(this.daoju, 0.3f);
        }
        if (other.CompareTag("HpUp")&&Hp < 48)
        {
            Hp += 1;
            Destroy(other.gameObject);
            this.PlayAudio(this.daoju, 0.3f);
        }
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
        if (by /*|| bfy || bz || bfz || bx || bfx*/)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
