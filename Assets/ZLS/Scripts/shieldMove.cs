using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldMove : MonoBehaviour
{
    public Vector3 dir;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(0.04f, 0.04f, 0);
        }

        
    }
    public void Move()
    {

        transform.position += dir * speed * Time.deltaTime;
    }
    IEnumerator lifeCounter()
    {
        yield return new WaitForSeconds(3f);
        Recycle();
        //ObjectPool.GetInstance().RecycleObj(gameObject);
    }
    public void Recycle()
    {
        //ObjectPool.GetInstance().RecycleObj(gameObject);
        Destroy(transform.gameObject);
    }
    private void OnEnable()
    {
        StartCoroutine(lifeCounter());
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet")) {
            Destroy(other.gameObject);
        }
    }
}
