using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Vector3 dir;
    public float speed = 30f;
    public bool timetodie = false;
    public bool isfollowMode = false;
    private float lifeTime = 0.0f;            // 生命期
    private float MaximumVelocity = 50f;
    private float MaximumLifeTime = 8.0f;
    private float AcceleratedVeocity = 5f;
    private float AccelerationPeriod = 0f;
    private float MaximumRotationSpeed = 360f;
    public float CurrentVelocity = 30f;   // 当前速度
    public GameObject target;
    public Transform firpoint;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("BOSS");
    }

    // Update is called once per frame
    void Update()
    {

        if (isfollowMode)
        {
            FollowMode(target);
        }
        else
        {
            BulletMove();
        }
    }
    public void BulletMove()
    {

        transform.position += dir * speed * Time.deltaTime;
    }
    IEnumerator lifeCounter()
    {
        yield return new WaitForSeconds(10f);
        timetodie = true;
        Recycle();
        //ObjectPool.GetInstance().RecycleObj(gameObject);
    }
    public void Recycle()
    {
        //ObjectPool.GetInstance().RecycleObj(gameObject);
        Destroy(transform.gameObject);
        timetodie = false;
    }
    private void OnEnable()
    {
        StartCoroutine(lifeCounter());
    }
    public void FollowMode(GameObject Target)
    {
        float deltaTime = Time.deltaTime;
        lifeTime += deltaTime;



        // 计算朝向目标的方向偏移量，如果处于上升期，则忽略目标
        Vector3 offset =
            ((lifeTime < AccelerationPeriod) && (Target != null))
            ? Vector3.up
            : (Target.transform.position - transform.position).normalized;

        // 计算当前方向与目标方向的角度差
        float angle = Vector3.Angle(dir, offset);

        // 根据最大旋转速度，计算转向目标共计需要的时间
        float needTime = angle / (MaximumRotationSpeed * (CurrentVelocity / MaximumVelocity));

        // 如果角度很小，就直接对准目标
        if (needTime < 0.001f)
        {
            dir = offset;
            transform.LookAt(target.transform);
        }
        else
        {
            // 当前帧间隔时间除以需要的时间，获取本次应该旋转的比例。
            dir = Vector3.Slerp(dir, offset, deltaTime / needTime).normalized;
            transform.LookAt(target.transform);
        }

        // 如果当前速度小于最高速度，则进行加速
        if (CurrentVelocity < MaximumVelocity)
            CurrentVelocity += deltaTime * AcceleratedVeocity;

        // 朝自己的前方位移

        transform.position += dir * CurrentVelocity * deltaTime;

    }



}
