using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldTransform : MonoBehaviour
{
    public bool cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cube)
        {
            if (transform.localScale.y < 20)
            {
                transform.localScale += new Vector3(0.05f, 0.15f, 0);
            }
            
        }
        else if (!cube)
        {
            if (transform.localScale.x < 20)
            {
                transform.localScale += new Vector3(0.15f, 0.05f, 0);
            }
        }
    }
}
