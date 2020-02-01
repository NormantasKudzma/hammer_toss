using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poof : MonoBehaviour
{
    public float m_Duration = 1.0f;
    public float m_ScaleSpeed = 1.1f;
    
    private float m_Growtime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, Math.Max(m_Duration, 0.01f));
        
        m_Growtime = m_Duration * 0.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var s = transform.localScale;
        s *= m_ScaleSpeed;
        transform.localScale = s;

        if (m_Growtime > 0.0f)
        {
            m_Growtime -= Time.fixedDeltaTime;
            if (m_Growtime <= 0.0f)
            {
                m_ScaleSpeed = 1.0f / m_ScaleSpeed;
            }
        }
    }
}
