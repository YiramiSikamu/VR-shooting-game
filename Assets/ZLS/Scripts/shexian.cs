using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shexian : MonoBehaviour
{
    public Transform m_StartPos;

    //public GameObject go_Point;
    private LineRenderer m_LineRender;

    public bool isEnemy;
    private void Awake()
    {
        m_LineRender = GetComponent<LineRenderer>();
    }

    private void DrawLine(Vector3 startPos, Vector3 endPos, Color color) {
        m_LineRender.positionCount = 2;
        m_LineRender.SetPosition(0, startPos);
        m_LineRender.SetPosition(1, endPos);
        m_LineRender.startWidth = 0.1f;
        m_LineRender.endWidth = 0.1f;
        m_LineRender.material.color = color;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(m_StartPos.position, Quaternion.AngleAxis(-40f, m_StartPos.transform.right) * -m_StartPos.transform.up, out hit, 1000, 1 << LayerMask.NameToLayer("Boss")))
        {
            isEnemy = true;
            DrawLine(m_StartPos.position, hit.point, Color.green);
        }
        else if(Physics.Raycast(m_StartPos.position, Quaternion.AngleAxis(-40f, m_StartPos.transform.right) * -m_StartPos.transform.up, out hit, 1000, 1 << LayerMask.NameToLayer("Default")))
        {
            isEnemy = false;
            DrawLine(m_StartPos.position, hit.point, Color.red);
        }
    }
}
