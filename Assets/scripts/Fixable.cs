using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fixable : MonoBehaviour
{
    public string m_NextLevel;
    public GameObject m_HitEffect;
    public Sprite m_FixedSprite;

    public GameObject m_FixedObject;
    public GameObject m_BrokenObject;

    private float m_TimeUntilNextLevel = 3.0f;
    private float m_TimeUntilRepaired = 0.3f;
    private bool m_Countdown = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(m_NextLevel != null, "Missing next level!!");
        Debug.Assert(SceneManager.GetSceneByName(m_NextLevel) != null, "Scene with name " + m_NextLevel + " Does not exist!!");
        
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
    }

    void ShowPoof()
    {
        if (m_HitEffect)
        {
            Instantiate(m_HitEffect, transform);
        }
    }
}
