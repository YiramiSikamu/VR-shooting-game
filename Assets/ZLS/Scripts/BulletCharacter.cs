using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class BulletCharacter : MonoBehaviour
{
    public Vector3 dir;
    public float speed;
    public bool isMove;
    bool isBallModePlay;
    public bool isfollowMode = false;
    private float lifeTime = 0.0f;            // 生命期
    private float MaximumVelocity = 30.0f;
    private float MaximumLifeTime = 8.0f;
    private float AcceleratedVeocity = 0f;
    private float AccelerationPeriod = 0.5f;
    private float MaximumRotationSpeed = 240f;
    private float CurrentVelocity = 7f;   // 当前速度
    public GameObject target;
    public Vector3 right;

    void Start()
    {
        isMove = true;
        target = GameObject.Find("Cube");

        //right = new Vector3(0, 0, 0);
        //transform.rotation = Quaternion.LookRotation(dir, right);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            if (isfollowMode)
            {
                FollowMode(target);
            }
            else
            {
                BulletMove();
                right = new Vector3(0,1,0);

                //transform.forward = dir.normalized;
                transform.rotation = Quaternion.LookRotation(dir, right);
            }
        }

    }

    public void BulletMove()
    {
        //Debug.Log("Use +=");
        Profiler.BeginSample("Use += To Move");
        transform.position += dir * speed * Time.deltaTime;
    }

    /// <summary>
    /// 动态变换移动方向的移动模式
    /// </summary>
    /// <param name="endTime">移动结束时间</param>
    /// <param name="dirChangeTime"><方向转变时间</param>
    /// <param name="angle">方向改变的角度</param>
    /// <returns></returns>
    public IEnumerator DirChangeMoveMode(float endTime, float dirChangeTime, float angle)
    {
        float time = 0;
        bool isRotate = true;
        isBallModePlay = true;
        while (isBallModePlay)
        {
            time += Time.deltaTime;
            transform.position += speed * dir * Time.deltaTime;
            if (time >= dirChangeTime && isRotate)
            {
                isRotate = false;
                StartCoroutine(BulletRotate(angle));
            }

            yield return null;
        }
    }

    /// <summary>
    /// 弹幕动态改变移动方向
    /// </summary>
    IEnumerator BulletRotate(float angle)
    {
        while (isBallModePlay)
        {
            Quaternion tempQuat = Quaternion.AngleAxis(angle, Vector3.forward);
            dir = tempQuat * dir;
            yield return new WaitForSeconds(0.2f);
        }
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
        float angle = Vector3.Angle(transform.forward, offset);

        // 根据最大旋转速度，计算转向目标共计需要的时间
        float needTime = angle / (MaximumRotationSpeed * (CurrentVelocity / MaximumVelocity));

        // 如果角度很小，就直接对准目标
        if (needTime < 0.001f)
        {
            transform.forward = offset;
        }
        else
        {
            // 当前帧间隔时间除以需要的时间，获取本次应该旋转的比例。
            transform.forward = Vector3.Slerp(transform.forward, offset, deltaTime / needTime).normalized;
        }

        // 如果当前速度小于最高速度，则进行加速
        if (CurrentVelocity < MaximumVelocity)
            CurrentVelocity += deltaTime * AcceleratedVeocity;

        // 朝自己的前方位移
        transform.position += transform.forward * CurrentVelocity * deltaTime;

    }
    
}
