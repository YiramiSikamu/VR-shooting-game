using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHp : MonoBehaviour
{
    public float Hp;
    private float MaxHp;
    public PlayerBulletHurt playerBulletHurt;
    private float Damage;
    //public GameObject Bar;
    public GameObject impactwave_1;
    public GameObject impactwave_2;
    private bool hurt;
    public BulletHurt bulletHurt;
    public AudioClip baozha;
    public AudioClip baozha2;
    public AudioSource PlayerAudio;

    protected AudioSource m_AudioSource;
    public GameObject uiBossHp;

    public bool dead;
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = transform.GetComponent<AudioSource>();
        Hp = 100;
        MaxHp = Hp;
        Damage = 0;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            dead = true;
            //print("Win");
            gameObject.SetActive(false);
        }
        if (Damage >=15) {
            ItemRandomDrop();
            Damage = 0;
        }
        /*if (GetHealthRate() < 1)
        {
            Bar.SetActive(true);
        }*/
        if (Hp <= 75)
        {
            bulletHurt.hurt = 2;
        }
        if (Hp <= 50)
        {
            bulletHurt.hurt = 2;
        }
        if (Hp <= 20)
        {
            bulletHurt.hurt = 4;
        }
        if (Hp <= 5)
        {
            bulletHurt.hurt = 8;
        }
        string a = Hp.ToString();
        uiBossHp.GetComponent<TMP_Text>().text = a;
    }
    private void PlayAudio(AudioClip ac,float vo)
    {
        m_AudioSource.PlayOneShot(ac);
        m_AudioSource.volume = vo;

    }
    public float GetHealthRate()
    {
        return (float)Hp / (float)MaxHp;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            
            PlayAudio(baozha2,0.3f);
            Hp -= playerBulletHurt.Hurt;
            GameObject impac = Instantiate(impactwave_1,transform);

            Destroy(impac, 2f);
            Destroy(other.gameObject);
            if (Damage < 50) {
                Damage += playerBulletHurt.Hurt;
            }
        }
        if (other.CompareTag("PlayerSkillBullet")) {
            PlayAudio(baozha2,0.3f);
            Hp -= 5;
            Destroy(other.gameObject);
            GameObject impac = Instantiate(impactwave_2,transform);
            Destroy(impac, 2f);
            if (Damage < 50) {
                Damage += playerBulletHurt.Hurt;
            }
        }
    }
    public void ItemRandomDrop()
    {
        GameObject hpUp = (GameObject)Resources.Load("Prefabs/HpUp");
        GameObject DamageUp = (GameObject)Resources.Load("Prefabs/DamageUp");
        GameObject AtkSpeedUp = (GameObject)Resources.Load("Prefabs/AtkSpeedUp");
        int num = Random.Range(1, 8);
        float offset = 0;
        for (int i = 0; i < num; i++)
        {

            float item = Random.Range(0f, 1f);
            if (item < 0.5)
            {
                hpUp = Instantiate(hpUp);
                hpUp.transform.position = new Vector3(gameObject.transform.position.x + offset, gameObject.transform.position.y, gameObject.transform.position.z);

                offset += 0.6f;
            }
            else if (item >= 0.5 && item < 0.8)
            {
                DamageUp = Instantiate(DamageUp);
                DamageUp.transform.position = new Vector3(gameObject.transform.position.x + offset, gameObject.transform.position.y, gameObject.transform.position.z);
                offset += 0.6f;
            }

            else if (item >= 0.8 && item <= 1)
            {
                AtkSpeedUp = Instantiate(AtkSpeedUp);
                AtkSpeedUp.transform.position = new Vector3(gameObject.transform.position.x + offset, gameObject.transform.position.y, gameObject.transform.position.z);
                offset += 0.6f;
            }
        }
    }
}
