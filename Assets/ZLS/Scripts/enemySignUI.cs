using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySignUI : MonoBehaviour
{
    public Transform sign;
    public Transform nowTarget;
    Transform target;
    Vector3 prePos = Vector3.zero;
    public float checkTime = 0.01f;
    public Transform player;
    public Vector3 scale;
    public bool issuo;

    public void SetGuid(Transform _target)
    {
        target = _target;
    }
    // Start is called before the first frame update
    void Start()
    {
        issuo = false;
        scale = sign.localScale;
        SetGuid(nowTarget);
        sign.gameObject.SetActive(false);
        StartCoroutine(TrakerGuider());
    }
    private IEnumerator TrakerGuider()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkTime);
            SetGuid();
        }
    }
    // Update is called once per frame
    private void SetGuid()
    {
        if (target)
        {
            var distance = Vector3.Distance(target.transform.position, player.transform.position);
            //var pos = Camera.main.WorldToScreenPoint(target.transform.position);
            var pos = Camera.main.WorldToViewportPoint(target.transform.position);
            
            if (distance > 6 && distance < 70)
            {
                if (0 < pos.x && pos.x < Screen.width && pos.y > 0 && pos.y < Screen.height && pos.z > 0)
                {
                    sign.transform.position = pos;
                    sign.localScale = scale / 64 * (64-distance + 6);
                    sign.gameObject.SetActive(true);
                    issuo = true;
                }
                else
                {
                    sign.gameObject.SetActive(false);
                    issuo = false;
                }
                
            }
            else
            {
                sign.gameObject.SetActive(false);
                issuo = false;
            }
            
        }
    }
}
