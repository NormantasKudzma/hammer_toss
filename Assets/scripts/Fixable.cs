﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fixable : MonoBehaviour
{
    public string m_NextLevel;
    public GameObject m_HitEffect;
    public Sprite m_FixedSprite;

    private float m_TimeUntilNextLevel = 3.0f;
    private bool m_Countdown = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(m_NextLevel != null, "Missing next level!!");
        Debug.Assert(m_FixedSprite != null, "Missing fixed sprite!!");
        Debug.Assert(SceneManager.GetSceneByName(m_NextLevel) != null, "Scene with name " + m_NextLevel + " Does not exist!!");
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
                SceneManager.LoadScene(m_NextLevel);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (m_Countdown)
        {
            return;
        }

        m_Countdown = true;

        Debug.Log("You fixed this thing! Will run next level soon");
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = m_FixedSprite;
    }
}
