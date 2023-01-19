using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool timetodie = false;
    public float lifeTime;
    public bool isFollow = false;
    public bool abc = false;
    // Use this for initialization
    void Start()
    {
        lifeTime = 10f;
    }

    // Update is called once per frame

    /// <summary>
    /// 3秒后自动回收到对象池
    /// </summary>
    /// <returns></returns>
    IEnumerator lifeCounter()
    {
        yield return new WaitForSeconds(lifeTime);
        timetodie = true;
        if (!isFollow)
        {
            ObjectPool.GetInstance().RecycleObj(gameObject);
        }
        else if (isFollow)
        {
            yield return new WaitForSeconds(1000f);
            ObjectPool.GetInstance().RecycleObj(gameObject);
        }
        
    }
    public void Recycle()
    {
        transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        ObjectPool.GetInstance().RecycleObj(gameObject);
        timetodie = false;
        
    }
    private void OnEnable()
    {
        StartCoroutine(lifeCounter());
    }
}
