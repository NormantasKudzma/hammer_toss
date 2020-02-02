using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeController : MonoBehaviour
{
    public float m_SmallShakeDuration = 0.1f;
    public float m_SmallShakeStrength = 0.04f;

    public float m_ViolentShakeDuration = 0.15f;
    public float m_ViolentShakeStrength = 0.8f;

    private GameObject m_Camera;
    private Vector3 m_OrigPos;
    private float m_DurationLeft;
    private float m_Strength;

    // Use this for initialization
    void Start()
    {
        m_Camera = ((Camera)FindObjectOfType(typeof(Camera))).gameObject;
        m_OrigPos = m_Camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_DurationLeft > 0.0f)
        {
            m_DurationLeft -= Time.deltaTime;

            Vector2 rnd = Random.insideUnitCircle;
            m_Camera.transform.position = m_OrigPos + new Vector3(rnd.x * m_Strength, rnd.y * m_Strength, 0.0f);

            if (m_DurationLeft <= 0.0f)
            {
                m_Camera.transform.position = m_OrigPos;
            }
        }
    }

    public void Shake(float duration, float strength)
    {
        if (m_DurationLeft > duration)
        {
            return;
        }

        m_DurationLeft = duration;
        m_Strength = strength;
    }

    public void SmallShake()
    {
        Shake(m_SmallShakeDuration, m_SmallShakeStrength);
    }

    public void ViolentShake()
    {
        Shake(m_ViolentShakeDuration, m_ViolentShakeStrength);
    }
}
