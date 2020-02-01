using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fixable : MonoBehaviour
{
    public GameObject m_NextLevel;
    public GameObject m_HitEffect;
    public Sprite m_FixedSprite;

    private float m_TimeUntilNextLevel = 3.0f;
    private bool m_Countdown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Countdown)
        {
            m_TimeUntilNextLevel -= Time.deltaTime;
            if (m_TimeUntilNextLevel <= 0.0f)
            {
                // STUB
                Debug.Log("Run next level now");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        m_Countdown = true;
        // STUB
        // start collision effect
        // show fixed object
    }
}
