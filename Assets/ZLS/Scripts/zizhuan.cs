using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zizhuan : MonoBehaviour
{

    public float RotateSpeed;//旋转速度

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * RotateSpeed, Space.Self);
    }
}
