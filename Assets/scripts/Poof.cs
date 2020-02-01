using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poof : MonoBehaviour
{
    public float m_Duration = 1.0f;
    public float m_ScaleSpeed = 1.1f;

    public float m_StartAlpha = 0.7f;
    public float m_EndAlpha = 0.7f;

    private float m_Growtime;
    private float m_AlphaSpeed;
    private SpriteRenderer m_SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, Math.Max(m_Duration, 0.01f));
        
        m_Growtime = m_Duration * 0.5f;
        m_AlphaSpeed = (1.0f - m_StartAlpha) / m_Growtime;

        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        var color = m_SpriteRenderer.color;
        color.a = m_StartAlpha;
        m_SpriteRenderer.color = color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var s = transform.localScale;
        s *= m_ScaleSpeed;
        transform.localScale = s;

        var color = m_SpriteRenderer.color;
        color.a += m_AlphaSpeed * Time.fixedDeltaTime;
        m_SpriteRenderer.color = color;

        if (m_Growtime > 0.0f)
        {
            m_Growtime -= Time.fixedDeltaTime;
            if (m_Growtime <= 0.0f)
            {
                m_ScaleSpeed = 1.0f / m_ScaleSpeed;
                m_AlphaSpeed = -((1.0f - m_EndAlpha) / (m_Duration * 0.5f));
            }
        }
    }
}
