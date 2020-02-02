﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fixable : MonoBehaviour
{
    public GameObject Counter;
    public string m_NextLevel;
    public GameObject m_HitEffect;
    public Sprite m_FixedSprite;

    public GameObject m_FixedObject;
    public GameObject m_BrokenObject;

    private float m_TimeUntilNextLevel = 3.0f;
    private float m_TimeUntilRepaired = 0.3f;
    private bool m_Countdown = false;

    private ShakeController m_SceenShaker;
    private HammerCounter m_Counter;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(m_NextLevel != null, "Missing next level!!");
        Debug.Assert(SceneManager.GetSceneByName(m_NextLevel) != null, "Scene with name " + m_NextLevel + " Does not exist!!");
        
        m_SceenShaker = gameObject.AddComponent<ShakeController>();
        m_Counter = Counter.GetComponent<HammerCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Countdown)
        {
            if (m_TimeUntilNextLevel > 0.0f)
            {
                m_TimeUntilNextLevel -= Time.deltaTime;
                if (m_TimeUntilNextLevel <= 0.0f)
                {
                    SceneManager.LoadScene(m_NextLevel);
                }
            }

            if (m_TimeUntilRepaired > 0.0f)
            {
                m_TimeUntilRepaired -= Time.deltaTime;
                if (m_TimeUntilRepaired <= 0.0f)
                {
                    Repair();
                }
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
        ShowPoof();
    }

    void Repair()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && m_FixedSprite != null)
        {
            spriteRenderer.sprite = m_FixedSprite;
        }

        if (m_FixedObject != null)
        {
            m_FixedObject.SetActive(true);
        }
        if (m_BrokenObject != null)
        {
            m_BrokenObject.SetActive(false);
        }
        if (m_Counter != null)
        {
            if (HammerCounter.CurrentCount < 3)
            {
                m_Counter.IncreaseOne();
            }
        }
    }

    void ShowPoof()
    {
        if (m_HitEffect)
        {
            Instantiate(m_HitEffect, transform);
        }

        m_SceenShaker.ViolentShake();
    }
}
